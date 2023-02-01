using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sales.ApplicationCore.Interfaces;
using Sales.Infrastructure.Contexts;
using Sales.Infrastructure.Repositories;

namespace Sales.Infrastructure
{
    public static class DependencyInjection
    {
        
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
 
            services.AddDbContext<SalesContext>(opt => opt.UseInMemoryDatabase("DataSource=:memory:"));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAccessRepository, AccessRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();

            return services;
        }
    }
}
