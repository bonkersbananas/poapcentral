using Microsoft.EntityFrameworkCore;

namespace backend.api.DataAccess
{
    public class PoapCentralDbContext : DbContext
    {
        public PoapCentralDbContext(DbContextOptions<PoapCentralDbContext> options) : base(options)
        {
        }

        // public DbSet<Event> Events { get; set; }
        // public DbSet<Poap> Poaps { get; set; }
    }
}
