using SAT242516005.Data;
namespace SAT242516005.Models.UnitOfWorks;

public class UnitOfWork
{
    private readonly ApplicationDbContext _db;
    public UnitOfWork(ApplicationDbContext db) => _db = db;

    public async Task<int> Kaydet() => await _db.SaveChangesAsync();
}