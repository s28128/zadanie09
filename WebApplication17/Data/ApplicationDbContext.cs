using Microsoft.EntityFrameworkCore;
using WebApplication17.Models;

namespace WebApplication17.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Lekarz> Lekarze { get; set; }
        public DbSet<Pacjent> Pacjenci { get; set; }
        public DbSet<Recepta> Recepty { get; set; }
        public DbSet<Lek> Leki { get; set; }
        public DbSet<ReceptaLek> ReceptaLeki { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Recepta>()
                .HasOne(r => r.Pacjent)
                .WithMany(p => p.Recepty)
                .HasForeignKey(r => r.PacjentId);

            modelBuilder.Entity<Recepta>()
                .HasOne(r => r.Lekarz)
                .WithMany(l => l.Recepty)
                .HasForeignKey(r => r.LekarzId);

            modelBuilder.Entity<ReceptaLek>()
                .HasKey(rl => new { rl.ReceptaId, rl.LekId });

            modelBuilder.Entity<ReceptaLek>()
                .HasOne(rl => rl.Recepta)
                .WithMany(r => r.ReceptaLeki)
                .HasForeignKey(rl => rl.ReceptaId);

            modelBuilder.Entity<ReceptaLek>()
                .HasOne(rl => rl.Lek)
                .WithMany(l => l.ReceptaLeki)
                .HasForeignKey(rl => rl.LekId);
        }
    }
}