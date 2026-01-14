using SAT242516005.Data;
using SAT242516005.Data.Abstract;
using SAT242516005.Models.Providers;

namespace SAT242516005.Data.Concrete
{
    public class UnitOfWork : IMyDbModel_UnitOfWork
    {
        private readonly MyDbContext _db;
        private IVardiyaProvider _vardiyaProvider = null!;

        public UnitOfWork(MyDbContext db)
        {
            _db = db;
        }

 
        public IVardiyaProvider Vardiyalar => _vardiyaProvider ??= new VardiyaProvider(_db);

        public async Task<int> SaveAsync()
        {
            return await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}