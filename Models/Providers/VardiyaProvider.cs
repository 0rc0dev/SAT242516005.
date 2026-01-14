using Microsoft.EntityFrameworkCore;
using SAT242516005.Data;
using SAT242516005.Models.MyDbModels;
using SAT242516005.Models.MyDbModels.Entities;

namespace SAT242516005.Models.Providers
{
    public class VardiyaProvider : IVardiyaProvider
    {
        private readonly MyDbContext _db;
        public VardiyaProvider(MyDbContext db) { _db = db; }

        public async Task<List<Vardiya>> GetListeAsync() =>
            await _db.Vardiyalar.Include(x => x.Doktor).OrderByDescending(x => x.Tarih).ToListAsync();

        public async Task<List<Doktor>> GetDoktorlarAsync() => await _db.Doktorlar.ToListAsync();

        public async Task VardiyaEkleAsync(VardiyaEkleModel model)
        {
            // Veritabanı tip uyuşmazlığını engellemek için TimeSpan kullanıyoruz
            var start = model.BaslangicSaati?.ToTimeSpan() ?? TimeSpan.Zero;
            var end = model.BitisSaati?.ToTimeSpan() ?? TimeSpan.Zero;

            // Direkt SQL yazarak Stored Procedure'ün tip hatalarını bypass ediyoruz
            await _db.Database.ExecuteSqlRawAsync(
                "INSERT INTO Vardiyalar (DoktorId, Tarih, BaslangicSaati, BitisSaati) VALUES ({0}, {1}, {2}, {3})",
                model.DoktorId, model.Tarih, start, end);
        }

        public async Task VardiyaSilAsync(int id)
        {
            var v = await _db.Vardiyalar.FindAsync(id);
            if (v != null) { _db.Vardiyalar.Remove(v); await _db.SaveChangesAsync(); }
        }

        public async Task AddDoktorAsync(Doktor d) => await _db.Doktorlar.AddAsync(d);
        public async Task UpdateDoktorAsync(Doktor d) { _db.Doktorlar.Update(d); await Task.CompletedTask; }
        public async Task DeleteDoktorAsync(int id)
        {
            var d = await _db.Doktorlar.FindAsync(id);
            if (d != null) _db.Doktorlar.Remove(d);
        }
    }
}