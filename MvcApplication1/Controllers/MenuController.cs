using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class MenuController : Controller
    {
        //
        // GET: /Menu/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Top()
        {
            return View();
        }

        public ActionResult Left()
        {
            return View();
        }

        public ActionResult Right()
        {
            return View();
        }

        public ActionResult Bottom()
        {
            return View();
        }
    }
}
