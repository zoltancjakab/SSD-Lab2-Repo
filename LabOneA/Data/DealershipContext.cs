using LabOneA.Models;
using Microsoft.EntityFrameworkCore;

namespace LabOneA.Data
{
    public class DealershipContext : DbContext
    {
        public DealershipContext (DbContextOptions<DealershipContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Member> Members { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Car>()
                .HasIndex(u => u.VIN)
                .IsUnique();
        }


        public DbSet<Dealership> Dealership { get; set; }
    }
}
