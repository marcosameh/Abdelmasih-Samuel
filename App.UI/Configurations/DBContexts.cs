using AppCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace App.UI.Configurations
{
    public static class DBContexts
    {

        public static IServiceCollection AddDBContexts(this IServiceCollection services, IConfiguration Configuration)
        {


            services.Configure<DatabaseOptions>(Configuration.GetSection("DatabaseOptions"));
            services.AddDbContext<AppCoreContext>(
              (serviceProvider, dbContextOptionsBuilder) =>
                {
                    var databaseOptions = serviceProvider.GetService<IOptions<DatabaseOptions>>()!.Value;
                    dbContextOptionsBuilder.UseSqlServer(Configuration.GetConnectionString("AppCore"), sqlServerAction =>
                {
                    sqlServerAction.EnableRetryOnFailure(databaseOptions.MaxRetryCount);
                    sqlServerAction.CommandTimeout(databaseOptions.CommandTimeout);                 
                });
                    dbContextOptionsBuilder.EnableDetailedErrors(databaseOptions.EnableDetailedErrors);
                    dbContextOptionsBuilder.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
                   
                });

            return services;
        }
    }
}
