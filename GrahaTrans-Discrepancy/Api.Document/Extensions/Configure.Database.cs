using Microsoft.EntityFrameworkCore;

namespace App.Api.Extensions
{
    public static partial class ConfigureExtensions
    {

        public static void DatabaseContext(this IServiceCollection services, IConfiguration config)
        {
            var defaultConnection = config.GetConnectionString("DefaultConnection");
            var dbContextSetting = config.GetSection("ConnectionStrings");
            services.Configure<Repository.Config.DbContextSettings>(dbContextSetting);
            services.AddDbContext<Entities.Data.EfDbContext>(o =>
            {
                o.UseSqlServer(defaultConnection,
                                    serverDbContextOptionsBuilder =>
                                    {
                                        var minutes = (int)TimeSpan.FromMinutes(10).TotalSeconds;
                                        serverDbContextOptionsBuilder.CommandTimeout(minutes);
                                        serverDbContextOptionsBuilder.EnableRetryOnFailure();
                                    });
            });
        }
    }
}
