using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Web.Routing;
using MvcApplication1.Models;

namespace MvcApplication1.Common
{
    public class LoginAuthorize:AuthorizeAttribute
    {

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            //httpContext.Response.Write("我是AuthorizeCode<br/>");

            
            if (!string.IsNullOrEmpty(httpContext.Session["AdminUser"] as string))
            {
                var r = httpContext.Session["Roles"] as string;
                if (r == Roles)
                {
                    return true;
                }

            }
            if (string.IsNullOrEmpty(httpContext.Session["AdminUser"] as string))
            {
                if (httpContext.Request.Cookies["Admin"] != null)
                {
                    string User = httpContext.Request.Cookies["Admin"]["User"];
                    string Pwd = httpContext.Request.Cookies["Admin"]["pwd"];
                    if (User == null || Pwd == null)
                    {
                        return false;
                    }
                    User = DESEncrypt.Decrypt(User);
                    YiLiaoContext db=new YiLiaoContext();
                    var model = db.UsersModels.Where(s => s.UserName.Contains(User) && s.UserPassword.Contains(Pwd));
                    int i = model.Count();

                    if (i > 0)
                    {
                        var m = model.First();
                        if (m.Limit.Contains("admin"))
                        {
                            httpContext.Session["AdminUser"] = m.UserName;
                            httpContext.Session["Roles"] = m.Limit;
                            return true;
                        }
                    }
                }
            }
            
            //return base.AuthorizeCore(httpContext);
            return false;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string[] strArr = new[] { "qiantai", "login", "upload" };
            string str =filterContext.RouteData.Values["controller"].ToString();
            if (!strArr.Contains(str.ToLower()))
            {
                //判断是否管理员
                if (!AuthorizeCore(filterContext.HttpContext))
                {
                    //不是
                    filterContext.HttpContext.Response.Redirect("/login");
                }                
            }

            //base.OnAuthorization(filterContext);

            //filterContext.HttpContext.Response.Write("我是OnAuthorization<br/>");
        }
    }
}