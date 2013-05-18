using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcApplication1.Models;
using MvcApplication1.Common;

namespace MvcApplication1
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //注册全局过滤器
            filters.Add(new LoginAuthorize(){Roles = "admin"});
            //filters.Add(new AdminFilterAttribute(){Message = "全局"});
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                "Login", // 路由名称
                "{controller}/{action}/{id}", // 带有参数的 URL
                new { controller = "qiantai", action = "Index", id = UrlParameter.Optional }, // 参数默认值
                new { controller = @"login|Upload" }//匹配
            );

            routes.MapRoute(
                "Admin", 
                "admin/{controller}/{action}/{id}",
                new{controller="Menu",action="index",id=UrlParameter.Optional},
                new { controller = @"Doctors|Health|HospitalImages|MedicaTech|Menu|MessageInfo|News|Readers|SinglePage|Users" }
            );

            routes.MapRoute(
                "Default", // 路由名称
                "{action}/{id}", // 带有参数的 URL
                new { controller = "qiantai", action = "Index", id = UrlParameter.Optional }, // 参数默认值
                new { controller = @"qiantai" }//匹配
            );
        }

        protected void Application_Start()
        {
            System.Data.Entity.Database.SetInitializer<YiLiaoContext>(new YiLiaoInitializer());

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}