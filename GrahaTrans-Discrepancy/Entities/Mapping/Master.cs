using Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Data
{
    public partial class EfDbContext
    {
        private void Master_Mapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.HasKey(e => e.BuyerId).HasName("PK__trBuyer__4B81C1CA91413C7C");

                entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<BuyerCategory>(entity =>
            {
                entity.HasKey(e => e.BuyerCategoryId).HasName("PK__trBuyerC__645C6D0C8296D0D7");

                entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Condition>(entity =>
            {
                entity.HasKey(e => e.ConditionId).HasName("PK__trCondit__37F5C0EFBC09B381");

                entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId).HasName("PK__trEmploy__AF2DBA7975920D76");

                entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<OutType>(entity =>
            {
                entity.HasKey(e => e.OutTypeId).HasName("PK__trOutTyp__93BFD9E4B3F9FE8F");

                entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.HasKey(e => e.PaymentMethodId).HasName("PK__trPaymen__DC31C1F30D704795");

                entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => e.ProductCategoryId).HasName("PK__trProduc__3224ECEE4F32424C");

                entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ProductItem>(entity =>
            {
                entity.HasKey(e => e.ProductId).HasName("PK__trProduc__B40CC6EDDC267CC0");

                entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.SupplierId).HasName("PK__trSuppli__4BE66694D2525284");

                entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<UnitType>(entity =>
            {
                entity.HasKey(e => e.UnitId).HasName("PK__trUnitTy__44F5EC953F7AF942");

                entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(e => e.VehicleId).HasName("PK__trVehicl__476B54B2495520D5");

                entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.HasKey(e => e.WarehouseId).HasName("PK__trWareho__2608AFD962905368");

                entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            });
        }
    }
}
