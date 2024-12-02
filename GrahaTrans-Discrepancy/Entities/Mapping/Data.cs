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
        private void Data_Mapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdjusmentStock>(entity =>
            {
                entity.HasKey(e => e.AdjusmentStockId).HasName("PK__td_Adjus__6743F8CC64964C6B");

                entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<BadStockIn>(entity =>
            {
                entity.HasKey(e => e.BadStockId).HasName("PK__td_BadSt__B4352618A7772BB1");

                entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
                entity.Property(e => e.QtyOut).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<BadStockOut>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__td_BadSt__3214EC271C04C5EF");

                entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.InvoiceId).HasName("PK__td_Invoi__D796AAD5ED01DD7F");

                entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<MovementStock>(entity =>
            {
                entity.HasKey(e => e.MovementId).HasName("PK__td_Movem__D182246660D2FB46");

                entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<ProductIn>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__td_Produ__3214EC2767AB039B");

                entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<ProductOut>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__td_Produ__3214EC27564CBABF");

                entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<SalesOrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderDetailId).HasName("PK__td_Sales__D3B9D30C04626EF7");

                entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<SalesOrderHeader>(entity =>
            {
                entity.HasKey(e => e.OrderHeaderId).HasName("PK__td_Sales__4BEA0BF4F9ED0B98");

                entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            });
        }
    }
}
