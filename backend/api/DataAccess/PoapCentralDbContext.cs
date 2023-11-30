using System.Data;
using api.Models;
using backend.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Npgsql;
using Dapper;

namespace backend.api.DataAccess
{
    class PoapCentralDbContext : DbContext
    {
        private DbSettings dbSettings;
        public PoapCentralDbContext(DbContextOptions<PoapCentralDbContext> options) : base(options)
        {
        }

        // public async Task Init()
        // {
        //     //await _initDatabase();
        //     // await _initTables();
        // }

        // private async Task _initTables()
        // {
        //     // create tables if they don't exist
        //     using var connection = CreateConnection();
        //     await _initPoaps();

        //     async Task _initPoaps()
        //     {
        //         var sql = """
        //         CREATE TABLE IF NOT EXISTS Users (
        //             Id SERIAL PRIMARY KEY,
        //             Url VARCHAR,
        //             Status VARCHAR,
        //             ImageUrl VARCHAR,
        //             Title VARCHAR,
        //             Description VARCHAR
        //             );
        //     """;
        //         await connection.ExecuteAsync(sql);
        //     }
        // }

        //public DbSet<Event> Events { get; set; }
        // public DbSet<Poap> Poaps => Set<Poap>();
    }
}
