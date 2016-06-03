using Model.RBAC;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mapping.RBAC
{
    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        /// <summary>
        /// 实体类、数据表关系配置——角色信息
        /// </summary>
        public RoleConfiguration()
        {
            RoleConfigurationAppend();
        }
        void RoleConfigurationAppend()
        {
            this.HasMany(r => r.Users).WithMany(u => u.Roles);
            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
