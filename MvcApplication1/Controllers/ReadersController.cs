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
    public class ReadersController : Controller
    {
        private YiLiaoContext db = new YiLiaoContext();

        //
        // GET: /Readers/

        public ViewResult Index(int? page)
        {
            var reader = from s in db.ReadersModels
                         select s;

            reader = reader.OrderByDescending(s => s.ReaderID);

            int pageSize = 20;
            int pageNumber = (page ?? 1);

            var readerlist = new PagedList.StaticPagedList<ReadersModels>(reader.ToPagedList(pageNumber, pageSize),
                                                                          pageNumber, pageSize, reader.Count());
            return View(readerlist);
        }

        //
        // GET: /Readers/Details/5

        public ViewResult Details(int id)
        {
            ReadersModels readersmodels = db.ReadersModels.Find(id);
            return View(readersmodels);
        }

        //
        // GET: /Readers/Create

        public ActionResult Create()
        {
            CommonMethod com = new CommonMethod();
            ViewBag.sexlist = new SelectList(com.Sexlist());
            return View();
        } 

        //
        // POST: /Readers/Create

        [HttpPost]
        public ActionResult Create(ReadersModels readersmodels)
        {
            if (ModelState.IsValid)
            {
                db.ReadersModels.Add(readersmodels);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(readersmodels);
        }
        
        //
        // GET: /Readers/Edit/5
 
        public ActionResult Edit(int id)
        {
            ReadersModels readersmodels = db.ReadersModels.Find(id);
            CommonMethod com = new CommonMethod();
            ViewBag.sexlist = new SelectList(com.Sexlist(), readersmodels.Sex);
            return View(readersmodels);
        }

        //
        // POST: /Readers/Edit/5

        [HttpPost]
        public ActionResult Edit(ReadersModels readersmodels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(readersmodels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(readersmodels);
        }

        //
        // GET: /Readers/Delete/5
 
        public ActionResult Delete(int id)
        {
            ReadersModels readersmodels = db.ReadersModels.Find(id);
            db.ReadersModels.Remove(readersmodels);
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