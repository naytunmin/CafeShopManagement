using CafeShopMgmt.Application.Interface.Persistence;
using CafeShopMgmt.Infrastructure.Data;
using CafeShopMgmt.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;

namespace CafeShopMgmt.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInjectionPersistence(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ICafeShopRepository, CafeShopRepository>();

            return services;
        }
    }
}
