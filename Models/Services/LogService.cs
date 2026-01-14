using SAT242516005.Data;
using SAT242516005.Models.MyDbModels.Entities;

public class LogService
{
    private readonly MyDbContext _db;

    public LogService(MyDbContext db)
    {
        _db = db;
    }

    public async Task LogYazAsync(string islem, string detay)
    {
        var log = new Log
        {
            Islem = islem,
            Detay = detay,
            Tarih = DateTime.Now
        };

        _db.Logs.Add(log);
        await _db.SaveChangesAsync();
    }
}
