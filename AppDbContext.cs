using Microsoft.EntityFrameworkCore;
using TodoneAPI.EntityConfigurations;

namespace TodoneAPI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Todo> Todo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.ApplyConfiguration(new TodoEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
