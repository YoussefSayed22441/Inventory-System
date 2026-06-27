using Inventory_System.Infrastructure.Data;
using Inventory_System.Infrastructure.Identity;
using Inventory_System.Infrastructure.Interfaces;
using Inventory_System.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddScoped<IProductSupplierRepo, ProductSupplierRepo>();
            services.AddScoped<INotificationRepo, NotificationRepo>();
            services.AddScoped<IStockHistoryRepo, StockHistoryRepo>();

            //Connect To DB
            services.AddDbContext<InventoryDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // user settings
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
            })
           .AddEntityFrameworkStores<InventoryDbContext>()
           .AddDefaultTokenProviders();


            return services;
        }
    }
}
