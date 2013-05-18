using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Common;

namespace MvcApplication1.Controllers
{
    //[AdminFilter(Message = "Action0")]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        [LoginAuthorize]
        //[AdminFilter(Message = "Action1")]
        public ActionResult Index()
        {
            HttpContext.Response.Write("Action正在执行...<br/>");
            //return Content("正在返回Result...<br/>");
            return View();
        }

    }
}
