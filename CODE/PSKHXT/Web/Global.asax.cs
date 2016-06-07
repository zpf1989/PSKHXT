using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Web.Extension;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //让所有从客户端发送到iis的HTTP请求全部都要经过UrlRoutingModule模块进行路由规则判断的话
            RouteTable.Routes.RouteExistingFiles = true;
            //注册视图引擎
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
            ViewEngines.Engines.Add(new WebFormViewEngine());
            //注册所有区域
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //autofac注册
            RegisterAutofacForSingle.RegisterAutofac();

            //数据库初始化设置（暂不启用）
            //DatabaseInitializer.Initialize();
        }
    }
}
