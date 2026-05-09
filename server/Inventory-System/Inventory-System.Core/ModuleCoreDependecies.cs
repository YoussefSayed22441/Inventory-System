using FluentValidation;
using Inventory_System.Core.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Core
{
    public static class ModuleCoreDependecies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection Service)
        {
            Service.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            });

            Service.AddAutoMapper(_ => { }, Assembly.GetExecutingAssembly());

            Service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return Service;
        }
    }
}
