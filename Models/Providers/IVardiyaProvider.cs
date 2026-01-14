using SAT242516005.Data;
using SAT242516005.Models.MyDbModels;

namespace SAT242516005.Models.Providers
{
    public interface IVardiyaProvider
    {
        Task<List<Vardiya>> GetListeAsync();
        Task<List<Doktor>> GetDoktorlarAsync();
        Task VardiyaEkleAsync(VardiyaEkleModel model);
        Task VardiyaSilAsync(int id);

        Task AddDoktorAsync(Doktor doktor);
        Task UpdateDoktorAsync(Doktor doktor);
        Task DeleteDoktorAsync(int id);
    }
}