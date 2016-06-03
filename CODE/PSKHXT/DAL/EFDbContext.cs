using DAL.Mapping.RBAC;
using Model.RBAC;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EFDbContext : DbContext
    {
        public EFDbContext()
            : base("default") { }
        public EFDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString) { }

        public EFDbContext(DbConnection existingConnection)
            : base(existingConnection, true) { }

        public DbSet<User> Users { get; set; }

        public DbSet<UserGroup> UserGroups { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<Module> Modules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //移除一对多的级联删除约定，【想要级联删除可以在 EntityTypeConfiguration<TEntity>的实现类中进行控制,级联删除是在WithMany返回的对象中设定的。】
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //移除一对一的级联删除约定
            //modelBuilder.Conventions.Remove<OneToOneConstraintIntroductionConvention>();
            //移除多对多的级联删除约定
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new PermissionConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new ModuleConfiguration());
            modelBuilder.Configurations.Add(new UserGroupConfiguration());

            //base.OnModelCreating(modelBuilder);
        }
    }
}
