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
    public class HealthController : Controller
    {
        private YiLiaoContext db = new YiLiaoContext();

        //
        // GET: /Health/

        public ViewResult Index(string searchString, int? page)
        {
            //return View(db.HealthModels.ToList());
            var model = from s in db.HealthModels
                       select s;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(s => s.HealthHead.ToUpper().Contains(searchString.ToUpper()) || s.HealthTypeName.ToUpper().Contains(searchString.ToUpper()));
            }

            model = model.OrderByDescending(s => s.PubDate);

            int pageSize = 20;
            int pageNumber = (page ?? 1);

            var List = new StaticPagedList<HealthModels>(model.ToPagedList(pageNumber, pageSize), pageNumber, pageSize,
                                                           model.Count());
            return View(List);
        }

        //
        // GET: /Health/Details/5

        public ViewResult Details(int id)
        {
            HealthModels healthmodels = db.HealthModels.Find(id);
            return View(healthmodels);
        }

        //
        // GET: /Health/Create

        public ActionResult Create()
        {
            CommonMethod com=new CommonMethod();
            ViewBag.list = new SelectList(com.HealthList());
            return View();
        } 

        //
        // POST: /Health/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(HealthModels healthmodels)
        {
            if (ModelState.IsValid)
            {
                db.HealthModels.Add(healthmodels);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }
            CommonMethod com = new CommonMethod();
            ViewBag.list = new SelectList(com.HealthList());
            return View(healthmodels);
        }
        
        //
        // GET: /Health/Edit/5
 
        public ActionResult Edit(int id)
        {
            HealthModels healthmodels = db.HealthModels.Find(id);
            CommonMethod com = new CommonMethod();
            ViewBag.list = new SelectList(com.HealthList(),healthmodels.HealthTypeName);
            return View(healthmodels);
        }

        //
        // POST: /Health/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(HealthModels healthmodels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(healthmodels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            CommonMethod com = new CommonMethod();
            ViewBag.list = new SelectList(com.HealthList(), healthmodels.HealthTypeName);
            return View(healthmodels);
        }

        //
        // GET: /Health/Delete/5
 
        public ActionResult Delete(int id)
        {
            HealthModels healthmodels = db.HealthModels.Find(id);
            db.HealthModels.Remove(healthmodels);
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