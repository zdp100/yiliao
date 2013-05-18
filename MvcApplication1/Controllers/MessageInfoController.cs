using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{ 
    public class MessageInfoController : Controller
    {
        private YiLiaoContext db = new YiLiaoContext();

        //
        // GET: /MessageInfo/

        public ViewResult Index()
        {
            var messageinfomodels = db.MessageInfoModels.Include(m => m.Users);
            return View(messageinfomodels.ToList());
        }

        //
        // GET: /MessageInfo/Details/5

        public ViewResult Details(int id)
        {
            MessageInfoModels messageinfomodels = db.MessageInfoModels.Find(id);
            return View(messageinfomodels);
        }

        //
        // GET: /MessageInfo/Create

        public ActionResult Create()
        {
            ViewBag.userId = new SelectList(db.UsersModels, "UserID", "UserName");
            return View();
        } 

        //
        // POST: /MessageInfo/Create

        [HttpPost]
        public ActionResult Create(MessageInfoModels messageinfomodels)
        {
            if (ModelState.IsValid)
            {
                db.MessageInfoModels.Add(messageinfomodels);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.userId = new SelectList(db.UsersModels, "UserID", "UserName", messageinfomodels.userId);
            return View(messageinfomodels);
        }
        
        //
        // GET: /MessageInfo/Edit/5
 
        public ActionResult Edit(int id)
        {
            MessageInfoModels messageinfomodels = db.MessageInfoModels.Find(id);
            ViewBag.userId = new SelectList(db.UsersModels, "UserID", "UserName", messageinfomodels.userId);
            return View(messageinfomodels);
        }

        //
        // POST: /MessageInfo/Edit/5

        [HttpPost]
        public ActionResult Edit(MessageInfoModels messageinfomodels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(messageinfomodels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userId = new SelectList(db.UsersModels, "UserID", "UserName", messageinfomodels.userId);
            return View(messageinfomodels);
        }

        //
        // GET: /MessageInfo/Delete/5
 
        public ActionResult Delete(int id)
        {
            MessageInfoModels messageinfomodels = db.MessageInfoModels.Find(id);
            db.MessageInfoModels.Remove(messageinfomodels);
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