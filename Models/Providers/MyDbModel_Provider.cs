using Microsoft.EntityFrameworkCore;
using SAT242516005.Data;

namespace SAT242516005.Models.Providers
{
    public class VardiyaProvider
    {
        private readonly ApplicationDbContext _db;

        public VardiyaProvider(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Vardiya>> GetirTümVardiyalar()
        {
            return await _db.Vardiyalar.Include(v => v.Doktor).ToListAsync();
        }

        public async Task Ekle(Vardiya yeniVardiya)
        {
            _db.Vardiyalar.Add(yeniVardiya);
            await _db.SaveChangesAsync();
        }

        public async Task Sil(int id)
        {

            var vardiya = await _db.Vardiyalar.FindAsync(id);
            if (vardiya != null)
            {
                _db.Vardiyalar.Remove(vardiya);
                await _db.SaveChangesAsync();
            }
        }
    }
}