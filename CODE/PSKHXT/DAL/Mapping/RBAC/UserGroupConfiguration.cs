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
    /// 实体类、数据表关系配置——用户组
    /// </summary>
    public class UserGroupConfiguration : EntityTypeConfiguration<UserGroup>
    {
        public UserGroupConfiguration()
        {
            UserGroupConfigurationAppend();
        }
        void UserGroupConfigurationAppend()
        {
            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasMany(g => g.Users).WithMany(u => u.UserGroups);
            this.HasMany(g => g.Roles).WithMany(r => r.UserGroups);
        }
    }
}
