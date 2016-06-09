using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac.Integration.Mvc;
using System.Reflection;
using System.Web.Mvc;
using Infrastructure;
using BLL.RBAC;
using IBLL.RBAC;
using DAL;
using System.Data.Entity;
using IDAL;
using DAL.Repositories;
using IDAL.RBAC;

namespace Web.Extension.Autofac
{
    public static class RegisterAutofacForSingle
    {
        public static void RegisterAutofac()
        {
            ContainerBuilder builder = new ContainerBuilder();
            //开启了Controller的依赖注入功能,
            //这里使用Autofac提供的RegisterControllers扩展方法来对程序集中所有的Controller一次性的完成注册
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            //开启了Filter的依赖注入功能，
            //为过滤器使用属性注入必须在容器创建之前调用RegisterFilterProvider方法，
            //并将其传到AutofacDependencyResolver
            builder.RegisterFilterProvider();

            #region IOC注册区域
            //倘若需要默认注册所有的，请这样写（主要参数需要修改）
            //var baseType = typeof(IDependency);
            //var asssemblys = AppDomain.CurrentDomain.GetAssemblies().ToList();
            //builder.RegisterControllers(asssemblys.ToArray());
            //builder.RegisterAssemblyTypes(asssemblys.ToArray())
            //    .Where(t => baseType.IsAssignableFrom(t) && t != baseType)
            //    .AsImplementedInterfaces().InstancePerMatchingLifetimeScope();

            //注册一个接口多个实现并定义多个Name的情况需要使用的Helper类
            builder.RegisterType<AutofacHelper>().As<IAutofacHelper>().InstancePerHttpRequest();

            RegisterForRBAC(builder);

            #endregion

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        /// <summary>
        /// 权限控制相关注册
        /// </summary>
        /// <param name="builder"></param>
        private static void RegisterForRBAC(ContainerBuilder builder)
        {
            builder.RegisterType<AccountService>().As<IAccountService>().InstancePerHttpRequest();
            builder.RegisterType<ModuleService>().As<IModuleService>().InstancePerHttpRequest();
            builder.RegisterType<RoleService>().As<IRoleService>().InstancePerHttpRequest();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerHttpRequest();
            builder.RegisterType<UserGroupService>().As<IUserGroupService>().InstancePerHttpRequest();
            builder.RegisterType<PermissionService>().As<IPermissionService>().InstancePerHttpRequest();
            builder.RegisterType<EFDbContext>().As<DbContext>().InstancePerHttpRequest();
            builder.RegisterType<EFUnitOfWork>().As<IUnitOfWork>().InstancePerHttpRequest();

            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerHttpRequest();
            builder.RegisterType<UserGroupRepository>().As<IUserGroupRepository>().InstancePerHttpRequest();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>().InstancePerHttpRequest();
            builder.RegisterType<PermissionRepository>().As<IPermissionRepository>().InstancePerHttpRequest();
            builder.RegisterType<ModuleRepository>().As<IModuleRepository>().InstancePerHttpRequest();
        }
    }
}