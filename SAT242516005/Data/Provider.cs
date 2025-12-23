using SAT242516005.Models;
using System.Collections.Generic;
using System.Linq;

namespace SAT242516005.Data
{
    public interface IProvider
    {
        List<Doktor> GetAllDoktorlar();
        List<Hasta> GetAllHastalar();
        List<Vardiya> AllVardiyalar { get; }
    }

    public class Provider : IProvider
    {
        private readonly MyDbContext _context;

        public Provider(MyDbContext context)
        {
            _context = context;
        }

        public List<Doktor> GetAllDoktorlar() => _context.Doktorlar.ToList();
        public List<Hasta> GetAllHastalar() => _context.Hastalar.ToList();
        public List<Vardiya> AllVardiyalar => _context.Vardiyalar.ToList();
    }
}
