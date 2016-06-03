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
    /// 实体类、数据表关系配置——模块
    /// </summary>
    public class ModuleConfiguration : EntityTypeConfiguration<Module>
    {
        public ModuleConfiguration()
        {
            ModuleConfigurationAppend();
        }
        /// <summary>
        /// 额外的数据映射
        /// </summary>
        void ModuleConfigurationAppend()
        {
            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasOptional(c => c.ParentModule).WithMany(c => c.ChildModules).HasForeignKey(d => d.ParentId);
        }
    }
}
