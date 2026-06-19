using Inventory_System.Infrastructure.Data;
using Inventory_System.Infrastructure.Interfaces;
using Inventory_System.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
       
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));

            services.AddScoped<ISupplierRepo,SupplierRepo>();
            services.AddScoped<IProductRepo, ProductRepo>();


            //Connect To DB
            services.AddDbContext<InventoryDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
     
            return services;
        }
    }
}
