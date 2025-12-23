using Microsoft.EntityFrameworkCore;
using SAT242516005.Models;

namespace SAT242516005.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Doktor> Doktorlar { get; set; }
        public DbSet<Hasta> Hastalar { get; set; }
        public DbSet<Vardiya> Vardiyalar { get; set; }
    }
}
