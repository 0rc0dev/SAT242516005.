using Microsoft.EntityFrameworkCore;

namespace SAT242516005.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Doktor> Doktorlar { get; set; }
        public DbSet<Hasta> Hastalar { get; set; }
        public DbSet<Vardiya> Vardiyalar { get; set; }
        public DbSet<Log> Loglar { get; set; }

        public DbSet<Doktor> Doktor => Doktorlar;
        public DbSet<Hasta> Hasta => Hastalar;
        public DbSet<Vardiya> Vardiya => Vardiyalar;

        public async Task LogYaz(string islem, string detay)
        {
            Loglar.Add(new Log { Islem = islem, Detay = detay, Tarih = DateTime.Now, Kullanici = "Admin" });
            await SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Doktor>().ToTable("Doktor");
            modelBuilder.Entity<Hasta>().ToTable("Hasta");
            modelBuilder.Entity<Vardiya>().ToTable("Vardiya");
        }
    }
}