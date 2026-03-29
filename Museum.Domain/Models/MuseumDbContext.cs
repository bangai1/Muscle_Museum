using Microsoft.EntityFrameworkCore;

namespace Museum_Domain.Models
{
    public class MuseumDbContext : DbContext
    {
        public MuseumDbContext(DbContextOptions<MuseumDbContext> options) : base(options)
        {

        }

        public DbSet<Ticket> Tickets { get; set; } = null!;
        public DbSet<Visitor> Visitors { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ticket>()
                .Property(t => t.Price)
                .HasColumnType("int");

        }
    }
}