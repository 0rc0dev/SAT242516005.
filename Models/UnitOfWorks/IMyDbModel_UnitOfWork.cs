using SAT242516005.Models.Providers;

namespace SAT242516005.Data.Abstract
{
    public interface IMyDbModel_UnitOfWork : IDisposable
    {
   
        IVardiyaProvider Vardiyalar { get; }

        Task<int> SaveAsync(); 
    }
}