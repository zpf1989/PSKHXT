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
    /// <summary>
    /// 实体类、数据表关系配置——权限
    /// </summary>
    public class PermissionConfiguration : EntityTypeConfiguration<Permission>
    {
        public PermissionConfiguration()
        {
            PermissionConfigurationAppend();
        }
        /// <summary>
        /// 额外的数据映射
        /// </summary>
        void PermissionConfigurationAppend()
        {
            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasMany(r => r.Roles).WithMany(u => u.Permissions);
            this.HasRequired(c => c.Module).WithMany(c => c.Permissions).HasForeignKey(d => d.ModuleId); ;
        }
    }
}
