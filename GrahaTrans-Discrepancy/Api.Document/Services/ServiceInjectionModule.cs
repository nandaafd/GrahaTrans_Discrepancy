
namespace App.Api.Services
{
    public static class ServiceInjectionModule
    {
        public static IServiceCollection InjectServices(this IServiceCollection services)
        {
            services.AddTransient<ProductCategory.ImsProductCategoryService, ProductCategory.msProductCategoryService>();
            return services;
        }
    }
}
