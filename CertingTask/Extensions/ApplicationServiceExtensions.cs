using CertingTask.Data;
using CertingTask.Helpers;
using CertingTask.Interfaces;
using CertingTask.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CertingTask.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEmployeeContext, EmployeeContext>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<DataContext>(options =>
             options.UseSqlServer(
                 config.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
