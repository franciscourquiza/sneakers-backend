using BeIceProyect.Server.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BeIceProyect.Server
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Sneaker> Sneakers { get; set; }
        public DbSet<Clothe> Clothes { get; set; }
        public DbSet<Cap> Caps { get; set; }
        public DbSet<SneakersSize> SneakersSizes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación Uno a Muchos (Una zapatilla tiene varios talles)
            modelBuilder.Entity<SneakersSize>()
                .HasOne(ss => ss.Sneaker)
                .WithMany(s => s.Sizes)
                .HasForeignKey(ss => ss.SneakerId);
        }
    }
}
