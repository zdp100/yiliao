using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using MvcApplication1.Common;

namespace MvcApplication1.Controllers
{
    public class LoginController : Controller
    {
        YiLiaoContext db=new YiLiaoContext();
        //
        // GET: /Login/

        public ActionResult Index()
        {
            if (isLogin())
            {
                return RedirectToAction("Index", "Menu");
            }
            return View();
        }

        public bool isLogin()
        {
            if (Session["Roles"] == "admin")
            {
                return true;
            }
            else if (string.IsNullOrEmpty(Session["AdminUser"] as string))
            {
                if (Request.Cookies["Admin"] != null)
                {
                    string User = Request.Cookies["Admin"]["User"];
                    string Pwd = Request.Cookies["Admin"]["pwd"];
                    if (User == null || Pwd == null)
                    {
                        return false;
                    }
                    User = DESEncrypt.Decrypt(User);
                    var model = db.UsersModels.Where(s => s.UserName.Contains(User) && s.UserPassword.Contains(Pwd));
                    int i = model.Count();

                    if (i > 0)
                    {
                        var m = model.First();
                        if (m.Limit.Contains("admin"))
                        {
                            Session["AdminUser"] = m.UserName;
                            Session["Roles"] = m.Limit;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        [HttpPost]
        public ActionResult Index(UsersModels model,string DropExpiration)
        {
            if (isLogin())
            {
                return RedirectToAction("Index", "Menu");
            }
            
            string pwd = DESEncrypt.Encrypt(model.UserPassword);
            var user = db.UsersModels.Where(s => s.UserName.Contains(model.UserName) && s.UserPassword.Contains(pwd));

            int i = user.Count();
            
            if (i>0 )
            {
                string roles = user.First().Limit;
                if (roles.Contains("admin"))
                {
                    Session["AdminUser"] = model.UserName;
                    Session["Roles"] = roles;
                    int num = -1;
                    if (DropExpiration == "None")
                    {
                        num = -1;
                    }
                    else if (DropExpiration == "Day")
                    {
                        num = 1;
                    }
                    else if (DropExpiration == "Month")
                    {
                        num = 30;
                    }
                    else if (DropExpiration == "Year")
                    {
                        num = 365;
                    }
      

      
                    HttpCookie cookie = new HttpCookie("Admin");
                    cookie.Values.Add("User",DESEncrypt.Encrypt(model.UserName));
                    cookie.Values.Add("pwd", DESEncrypt.Encrypt(model.UserPassword));
                    cookie.Expires = DateTime.Now.AddDays(num);

                    Response.Cookies.Add(cookie);
                    return Redirect("/admin");             
                }
                else
                {
                    List<string> list=new List<string>();
                    list.Add("此树是我栽，此路是我开，要想过此门，乖乖交钱来");
                    list.Add("没权限，请出示身份证");
                    list.Add("运气不足，进不去，去淘宝买运气卡充充运气");
                    list.Add("权限不足，无法登入");
                    Random rd=new Random();
                    int j = rd.Next(0, 4);

                    ModelState.AddModelError("", list[j]);
                    return View();
                }
            }
            else
                ModelState.AddModelError("","用户名或密码不正确！");
            return View();
        }

        

        public ActionResult logout()
        {
            Session["AdminUser"] = null;
            Response.Cookies["Admin"].Expires=DateTime.Now.AddDays(-1);
            return RedirectToAction("Index", "Login");
            //return View();
        }

    }
}
