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
        private void Users_Mapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleId).HasName("PK__tuRole__8AFACE3A34D74B39");

                entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<RoleAccess>(entity =>
            {
                entity.HasKey(e => e.RoleAccessId).HasName("PK__tuRoleAc__C1244FB488FAAFE4");

                entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<RoleMappingGroup>(entity =>
            {
                entity.HasKey(e => e.GroupId).HasName("PK__tuRoleMa__149AF30A366C55B5");

                entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId).HasName("PK__tuUser__1788CCACEFAA970C");

                entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            });
        }
    }
}
