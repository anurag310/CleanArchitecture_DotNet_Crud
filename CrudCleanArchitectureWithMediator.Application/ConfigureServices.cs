using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CrudCleanArchitectureWithMediator.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationService (this IServiceCollection services)
        {

            // register our mapper dependency
            services.AddAutoMapper(Assembly.GetExecutingAssembly());/// Register some dependency
            services.AddMediatR(ctg =>
            {
                ctg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services; 
        }
    }
}
