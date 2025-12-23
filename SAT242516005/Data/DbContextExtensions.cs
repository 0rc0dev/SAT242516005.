using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SAT242516005.Data
{
    public static class DbContextExtensions
    {
        public static IServiceCollection AddMyDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MyDbContext>(options =>
                options.UseSqlServer(connectionString));
            return services;
        }
    }
}
