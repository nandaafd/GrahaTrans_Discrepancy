using Microsoft.Extensions.DependencyInjection;
using Entities.Domain;
namespace App.Repository
{
    public static class RepositoryInjectionModule
    {
        public static IServiceCollection InjectPersistence(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Entities.Domain.AdjusmentStock>, Repository<Entities.Domain.AdjusmentStock>>();
            services.AddTransient<IRepository<Entities.Domain.Buyer>, Repository<Entities.Domain.Buyer>>();
            services.AddTransient<IRepository<Entities.Domain.BuyerCategory>, Repository<Entities.Domain.BuyerCategory>>();
            services.AddTransient<IRepository<Entities.Domain.Condition>, Repository<Entities.Domain.Condition>>();
            services.AddTransient<IRepository<Entities.Domain.Employee>, Repository<Entities.Domain.Employee>>();
            services.AddTransient<IRepository<Entities.Domain.OutType>, Repository<Entities.Domain.OutType>>();
            services.AddTransient<IRepository<Entities.Domain.PaymentMethod>, Repository<Entities.Domain.PaymentMethod>>();
            services.AddTransient<IRepository<Entities.Domain.ProductCategory>, Repository< Entities.Domain.ProductCategory>>();
            services.AddTransient<IRepository<Entities.Domain.ProductItem>, Repository<Entities.Domain.ProductItem>>();
            services.AddTransient<IRepository<Entities.Domain.Supplier>, Repository<Entities.Domain.Supplier>>();
            services.AddTransient<IRepository<Entities.Domain.UnitType>, Repository<Entities.Domain.UnitType>>();
            services.AddTransient<IRepository<Entities.Domain.Vehicle>, Repository<Entities.Domain.Vehicle>>();
            services.AddTransient<IRepository<Entities.Domain.Warehouse>, Repository<Entities.Domain.Warehouse>>();
            services.AddTransient<IRepository<Entities.Domain.Role>, Repository<Entities.Domain.Role>>();
            services.AddTransient<IRepository<Entities.Domain.RoleAccess>, Repository<Entities.Domain.RoleAccess>>();
            services.AddTransient<IRepository<Entities.Domain.RoleMappingGroup>, Repository<Entities.Domain.RoleMappingGroup>>();
            services.AddTransient<IRepository<Entities.Domain.User>, Repository<Entities.Domain.User>>();
            services.AddTransient<IRepository<Entities.Domain.BadStockIn>, Repository<Entities.Domain.BadStockIn>>();
            services.AddTransient<IRepository<Entities.Domain.BadStockOut>, Repository<Entities.Domain.BadStockOut>>();
            services.AddTransient<IRepository<Entities.Domain.Invoice>, Repository<Entities.Domain.Invoice>>();
            services.AddTransient<IRepository<Entities.Domain.MovementStock>, Repository<Entities.Domain.MovementStock>>();
            services.AddTransient<IRepository<Entities.Domain.ProductIn>, Repository<Entities.Domain.ProductIn>>();
            services.AddTransient<IRepository<Entities.Domain.ProductOut>, Repository<Entities.Domain.ProductOut>>();
            services.AddTransient<IRepository<Entities.Domain.ProductPriceRequest>, Repository<Entities.Domain.ProductPriceRequest>>();
            services.AddTransient<IRepository<Entities.Domain.SalesOrderDetail>, Repository<Entities.Domain.SalesOrderDetail>>();
            services.AddTransient<IRepository<Entities.Domain.SalesOrderHeader>, Repository<Entities.Domain.SalesOrderHeader>>();
            services.AddTransient<IRepository<Entities.Domain.VMResponse>, Repository<Entities.Domain.VMResponse>>();

            services.AddScoped<IDbContextFactory, DbContextFactory>();
            return services;
        }
    }
}
