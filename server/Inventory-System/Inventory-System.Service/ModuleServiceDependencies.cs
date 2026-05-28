using Inventory_System.Service.Abstracts;
using Inventory_System.Service.Implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection Service)
        {
            Service.AddScoped<ICategoryService, CategoryService>();
            Service.AddScoped<ISupplierService, SupplierService>();
            Service.AddScoped<IProductService, ProductService>();

            return Service;
        }
    }
}
