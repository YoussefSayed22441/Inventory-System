<<<<<<< Updated upstream

=======
using Inventory_System.Core;
>>>>>>> Stashed changes
using Inventory_System.Infrastructure;
using Inventory_System.Core;
using Inventory_System.Service;
<<<<<<< Updated upstream
=======
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
>>>>>>> Stashed changes

namespace Inventory_System.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            // ✅ Swagger with Bearer Auth
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Inventory-System.API", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter: Bearer {your token}"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            // ✅ Dependency Injections
            builder.Services.AddInfrastructureDependencies(builder.Configuration)
                .AddCoreDependencies()
                .AddServiceDependencies();

            var app = builder.Build();

<<<<<<< Updated upstream
            // Configure the HTTP request pipeline.
=======
            // ✅ Seed Roles & Users
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                await RoleSeed.SeedRoleAsync(roleManager);
                await AppIdentityDbContextSeed.SeedUserAsync(userManager);
            }

>>>>>>> Stashed changes
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
<<<<<<< Updated upstream

=======
            app.UseAuthentication();
>>>>>>> Stashed changes
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}