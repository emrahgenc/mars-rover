using Microsoft.EntityFrameworkCore;

namespace MarsRover.Infrastructure.Persistancy
{
    public class MarsRoverDbContext : DbContext
    {
        public MarsRoverDbContext(DbContextOptions<MarsRoverDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
