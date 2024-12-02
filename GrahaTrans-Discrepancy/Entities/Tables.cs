using Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Data
{
    public partial class EfDbContext
    {
        public virtual DbSet<AdjusmentStock> TdAdjusmentStock { get; set; }

        public virtual DbSet<BadStockIn> TdBadStockIn { get; set; }

        public virtual DbSet<BadStockOut> TdBadStockOut { get; set; }

        public virtual DbSet<Invoice> TdInvoice { get; set; }

        public virtual DbSet<MovementStock> TdMovementStock { get; set; }

        public virtual DbSet<ProductIn> TdProductIn { get; set; }

        public virtual DbSet<ProductOut> TdProductOut { get; set; }
        public virtual DbSet<ProductPriceRequest> TdProductPriceRequest { get; set; }

        public virtual DbSet<SalesOrderDetail> TdSalesOrderDetail { get; set; }

        public virtual DbSet<SalesOrderHeader> TdSalesOrderHeader { get; set; }

        public virtual DbSet<Buyer> TrBuyer { get; set; }

        public virtual DbSet<BuyerCategory> TrBuyerCategory { get; set; }

        public virtual DbSet<Condition> TrCondition { get; set; }

        public virtual DbSet<Employee> TrEmployee { get; set; }

        public virtual DbSet<OutType> TrOutType { get; set; }

        public virtual DbSet<PaymentMethod> TrPaymentMethod { get; set; }

        public virtual DbSet<ProductCategory> TrProductCategory { get; set; }

        public virtual DbSet<ProductItem> TrProductItem { get; set; }

        public virtual DbSet<Supplier> TrSupplier { get; set; }

        public virtual DbSet<UnitType> TrUnitType { get; set; }

        public virtual DbSet<Vehicle> TrVehicle { get; set; }

        public virtual DbSet<Warehouse> TrWarehouse { get; set; }
        public virtual DbSet<Role> TuRole { get; set; }

        public virtual DbSet<RoleAccess> TuRoleAccess { get; set; }

        public virtual DbSet<RoleMappingGroup> TuRoleMappingGroup { get; set; }

        public virtual DbSet<User> TuUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Data_Mapping(modelBuilder);
            Users_Mapping(modelBuilder);
            Master_Mapping(modelBuilder);
        }
    }
}
