using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using SAT242516005.Models.MyDbModels.Entities;

namespace SAT242516005.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options) { }

        public DbSet<Doktor> Doktorlar { get; set; }
        public DbSet<Hasta> Hastalar { get; set; }
        public DbSet<Vardiya> Vardiyalar { get; set; }
        public DbSet<Log> Logs { get; set; }

        // =========================
        // STORED PROCEDURE METODU
        // =========================
        public async Task VardiyaEkle_SP(
            int doktorId,
            DateTime tarih,
            TimeSpan baslangic,
            TimeSpan bitis)
        {
            await Database.ExecuteSqlRawAsync(
                "EXEC VardiyaEkle @DoktorId, @Tarih, @BaslangicSaati, @BitisSaati",
                new SqlParameter("@DoktorId", doktorId),
                new SqlParameter("@Tarih", tarih),
                new SqlParameter("@BaslangicSaati", baslangic),
                new SqlParameter("@BitisSaati", bitis)
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doktor>(e =>
            {
                e.ToTable("Doktor");
                e.HasKey(x => x.DoktorId);
            });

            modelBuilder.Entity<Hasta>(e =>
            {
                e.ToTable("Hasta");
                e.HasKey(x => x.HastaId);
            });

            modelBuilder.Entity<Vardiya>(e =>
            {
                e.ToTable("Vardiya");
                e.HasKey(x => x.VardiyaId);

                e.HasOne(x => x.Doktor)
                 .WithMany(d => d.Vardiyalar)
                 .HasForeignKey(x => x.DoktorId);

                e.HasIndex(x => new { x.DoktorId, x.Tarih });
            });

            modelBuilder.Entity<Log>(e =>
            {
                e.ToTable("Logs_Table");
                e.HasKey(x => x.LogId);
            });
        }
    }
}
