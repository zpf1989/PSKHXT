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
    /// 实体类、数据表关系配置——用户信息
    /// </summary>
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            UserConfigurationAppend();
        }
        void UserConfigurationAppend()
        {
            this.HasKey(c => c.Id);
            this.Property(c => c.UserName).HasColumnName("UserName").HasMaxLength(20);
            this.Property(c => c.Password).HasMaxLength(32);
            this.Property(c => c.TrueName).HasMaxLength(20);
            this.Property(c => c.Email).HasMaxLength(50);
            this.Property(c => c.Address).HasMaxLength(300);

            //this.ToTable("User");
            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
