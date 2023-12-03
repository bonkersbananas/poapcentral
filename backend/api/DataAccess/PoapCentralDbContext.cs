using backend.api.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace backend.api.DataAccess
{
    public class PoapCentralDbContext : DbContext
    {
        public DbSet<Poap> Poaps { get; set; }
        //public DbSet<Event> Events { get; set; }

        public PoapCentralDbContext(DbContextOptions<PoapCentralDbContext> options) : base(options)
        {
        }

        public async Task Init()
        {
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTIONSTRING");
            var originalBuilder = new NpgsqlConnectionStringBuilder(connectionString);
            var builder = new NpgsqlConnectionStringBuilder(connectionString) { Database = "postgres" };

            using var connection = new NpgsqlConnection(builder.ConnectionString);
            await connection.OpenAsync();

            string? databaseName = originalBuilder.Database;
            if (databaseName == null)
            {
                throw new Exception("Database name not found in connection string");
            }
            bool databaseExists;
            using (var command = new NpgsqlCommand($"SELECT 1 FROM pg_database WHERE datname = '{databaseName}'", connection))
            {
                databaseExists = await command.ExecuteScalarAsync() != null;
            }

            Console.WriteLine($"Database exists = {databaseExists}");

            if (!databaseExists)
            {
                try
                {
                    using (var createCommand = new NpgsqlCommand($"CREATE DATABASE {databaseName}", connection))
                    {
                        await createCommand.ExecuteNonQueryAsync();
                    }

                    Console.WriteLine($"Created db {databaseName}");
                }
                catch (PostgresException ex)
                {
                    // Ignore the error if the database already exists
                    if (ex.SqlState != "42P04")
                    {
                        throw;
                    }
                }
            }

            connection.ChangeDatabase(databaseName);

            var tableName = "poaps";
            using (var checkTableCommand = new NpgsqlCommand($"SELECT 1 FROM pg_tables WHERE tablename = '{tableName}'", connection))
            {
                var tableExists = await checkTableCommand.ExecuteScalarAsync() != null;

                if (!tableExists)
                {
                    using (var createTableCommand = new NpgsqlCommand($"CREATE TABLE {tableName} (id varchar(255) NOT NULL, url varchar(255) NULL DEFAULT NULL, status varchar(255) NOT NULL, image_url varchar(255) NULL DEFAULT NULL, title varchar(255) NULL DEFAULT NULL, description varchar(255) NULL DEFAULT NULL, PRIMARY KEY (id))", connection))
                    {
                        await createTableCommand.ExecuteNonQueryAsync();
                        Console.WriteLine($"Created table {tableName}");
                    }
                }
            }
        }
    }
}
