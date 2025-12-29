using Microsoft.EntityFrameworkCore;
using SAT242516005.Data;

namespace SAT242516005.Models.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Doktor> Doktorlar { get; set; }
        public DbSet<Hasta> Hastalar { get; set; }
        public DbSet<Vardiya> Vardiyalar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doktor>(e =>
            {
                e.ToTable("Doktor");
                e.HasKey(x => x.DoktorId);

                e.Property(x => x.Ad).HasMaxLength(50).IsRequired();
                e.Property(x => x.Soyad).HasMaxLength(50).IsRequired();
                e.Property(x => x.Brans).HasMaxLength(50).IsRequired();
            });

            modelBuilder.Entity<Hasta>(e =>
            {
                e.ToTable("Hasta");
                e.HasKey(x => x.HastaId);

                e.Property(x => x.Ad).HasMaxLength(50).IsRequired();
                e.Property(x => x.Soyad).HasMaxLength(50).IsRequired();
            });

            modelBuilder.Entity<Vardiya>(e =>
            {
                e.ToTable("Vardiya");
                e.HasKey(x => x.VardiyaId);

                e.HasOne(x => x.Doktor)
                 .WithMany(d => d.Vardiyalar)
                 .HasForeignKey(x => x.DoktorId)
                 .OnDelete(DeleteBehavior.NoAction);

                e.HasIndex(x => new { x.DoktorId, x.Tarih }); // INDEX (hocanın istediği)
            });
        }
    }
}
