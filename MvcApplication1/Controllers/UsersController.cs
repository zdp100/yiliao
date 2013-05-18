using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Common;
using MvcApplication1.Models;
using PagedList;

namespace MvcApplication1.Controllers
{ 
    public class UsersController : Controller
    {
        private YiLiaoContext db = new YiLiaoContext();

        //
        // GET: /Users/

        public ViewResult Index(int? page)
        {
            var user = from s in db.UsersModels
                       select s;

            user = user.OrderByDescending(s => s.UserID);
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            var userlist = new StaticPagedList<UsersModels>(user.ToPagedList(pageNumber, pageSize), pageNumber, pageSize,
                                                            user.Count());
            return View(userlist);
        }

        //
        // GET: /Users/Details/5

        public ViewResult Details(int id)
        {
            UsersModels usersmodels = db.UsersModels.Find(id);
            return View(usersmodels);
        }

        //
        // GET: /Users/Create

        public ActionResult Create()
        {
            CommonMethod com=new CommonMethod();
            ViewBag.sexlist = new SelectList(com.Sexlist());
            return View();
        } 

        //
        // POST: /Users/Create

        [HttpPost]
        public ActionResult Create(UsersModels usersmodels)
        {
            if (ModelState.IsValid)
            {
                usersmodels.UserPassword = DESEncrypt.Encrypt(usersmodels.UserPassword);
                db.UsersModels.Add(usersmodels);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(usersmodels);
        }
        
        //
        // GET: /Users/Edit/5
 
        public ActionResult Edit(int id)
        {
            UsersModels usersmodels = db.UsersModels.Find(id);
            usersmodels.UserPassword = DESEncrypt.Decrypt(usersmodels.UserPassword);
            CommonMethod com = new CommonMethod();
            ViewBag.sexlist = new SelectList(com.Sexlist(), usersmodels.Sex);
            return View(usersmodels);
        }

        //
        // POST: /Users/Edit/5

        [HttpPost]
        public ActionResult Edit(UsersModels usersmodels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usersmodels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usersmodels);
        }

        //
        // GET: /Users/Delete/5
 
        public ActionResult Delete(int id)
        {
            UsersModels usersmodels = db.UsersModels.Find(id);
            db.UsersModels.Remove(usersmodels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}