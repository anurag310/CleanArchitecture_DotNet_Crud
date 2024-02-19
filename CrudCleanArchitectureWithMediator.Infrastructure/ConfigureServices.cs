using AutoMapper;
using CrudCleanArchitectureWithMediator.Domain.Repository;
using CrudCleanArchitectureWithMediator.Infrastructure.Data;
using CrudCleanArchitectureWithMediator.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCleanArchitectureWithMediator.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureService
            (this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<BlogDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection") ?? 
                    throw new InvalidOperationException("Connection String not found"));
            });
            services.AddTransient<IblogRepository, BlogRepository>();
            return services;
        }
    }
}
