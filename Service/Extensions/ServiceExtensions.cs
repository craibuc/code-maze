using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {
            });
        }

        //public static void ConfigureSqliteContext(this IServiceCollection services, IConfiguration config)
        //{
        //    var connectionString = config.GetConnectionString("Database");
        //    services.AddDbContext<RepositoryContext>(options => options.UseSqlite(connectionString));
        //}

        //public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        //{
        //    services.AddScoped<IUnitOfWork, UnitOfWork>();
        //}

    }
}
