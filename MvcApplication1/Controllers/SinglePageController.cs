using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using MvcApplication1.Common;

namespace MvcApplication1.Controllers
{ 
    public class SinglePageController : Controller
    {
        private YiLiaoContext db = new YiLiaoContext();

        //
        // GET: /SinglePage/

        public ViewResult Index(string id)
        {
            var SinglePage = from s in db.SinglePageModels
                                 select s;
            if (id == "就医指南" || id == "医院文化")
            {
                SinglePage = SinglePage.Where(s => s.Type.Contains(id)).OrderBy(s => s.ID);
            }
            else 
            {
                SinglePage = SinglePage.Where(s => s.Type.Contains("就医指南")).OrderBy(s => s.ID);
            }
            ViewBag.strType = id;
            return View(SinglePage.ToList());
        }

        //
        // GET: /SinglePage/Details/5

        public ViewResult Details(int id)
        {
            SinglePageModels singlepagemodels = db.SinglePageModels.Find(id);
            return View(singlepagemodels);
        }

        //
        // GET: /SinglePage/Create

        public ActionResult Create()
        {
            ViewBag.Typtlist =new SelectList(new CommonMethod().SinglePageList());
            return View();
        } 

        //
        // POST: /SinglePage/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(SinglePageModels singlepagemodels)
        {
            ViewBag.Typtlist = new CommonMethod().SinglePageList();
            if (ModelState.IsValid)
            {
                db.SinglePageModels.Add(singlepagemodels);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(singlepagemodels);
        }
        
        //
        // GET: /SinglePage/Edit/5
 
        public ActionResult Edit(int id)
        {
            SinglePageModels singlepagemodels = db.SinglePageModels.Find(id);
            ViewBag.Typtlist =new SelectList(new CommonMethod().SinglePageList(),singlepagemodels.Type);
            return View(singlepagemodels);
        }

        //
        // POST: /SinglePage/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(SinglePageModels singlepagemodels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(singlepagemodels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(singlepagemodels);
        }

        //
        // GET: /SinglePage/Delete/5
 
        public ActionResult Delete(int id)
        {
            SinglePageModels singlepagemodels = db.SinglePageModels.Find(id);
            return View(singlepagemodels);
        }

        //
        // POST: /SinglePage/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            SinglePageModels singlepagemodels = db.SinglePageModels.Find(id);
            db.SinglePageModels.Remove(singlepagemodels);
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