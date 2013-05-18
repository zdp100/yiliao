using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using MvcApplication1.Common;
using PagedList;

namespace MvcApplication1.Controllers
{ 
    public class MedicaTechController : Controller
    {
        private YiLiaoContext db = new YiLiaoContext();

        //
        // GET: /MedicaTech/

        public ViewResult Index(string searchString, int? page)
        {
            var MedicalTech = from s in db.MedicalTechModels
                       select s;
            if (!string.IsNullOrEmpty(searchString))
            {
                MedicalTech = MedicalTech.Where(s => s.Title.ToUpper().Contains(searchString.ToUpper()) || s.Type.ToUpper().Contains(searchString.ToUpper()));
            }

            MedicalTech = MedicalTech.OrderByDescending(s => s.PubDate);

            int pageSize = 20;
            int pageNumber = (page ?? 1);

            var MedicalTechList = new StaticPagedList<MedicalTechModels>(MedicalTech.ToPagedList(pageNumber, pageSize), pageNumber, pageSize,
                                                           MedicalTech.Count());

            return View(MedicalTechList);
        }

        //
        // GET: /MedicaTech/Details/5

        public ViewResult Details(int id)
        {
            MedicalTechModels medicaltechmodels = db.MedicalTechModels.Find(id);
            return View(medicaltechmodels);
        }

        //
        // GET: /MedicaTech/Create

        public ActionResult Create()
        {
            ViewBag.list = new SelectList(new CommonMethod().MedicaTechList(),string.Empty);
            return View();
        } 

        //
        // POST: /MedicaTech/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(MedicalTechModels medicaltechmodels)
        {
            ViewBag.list = new SelectList(new CommonMethod().MedicaTechList());
            if (ModelState.IsValid)
            {
                db.MedicalTechModels.Add(medicaltechmodels);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(medicaltechmodels);
        }
        
        //
        // GET: /MedicaTech/Edit/5
 
        public ActionResult Edit(int id)
        {
            MedicalTechModels medicaltechmodels = db.MedicalTechModels.Find(id);
            ViewBag.list = new SelectList(new CommonMethod().MedicaTechList(),medicaltechmodels.Type);
            return View(medicaltechmodels);
        }

        //
        // POST: /MedicaTech/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(MedicalTechModels medicaltechmodels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicaltechmodels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medicaltechmodels);
        }

        //
        // GET: /MedicaTech/Delete/5
 
        public ActionResult Delete(int id)
        {
            MedicalTechModels medicaltechmodels = db.MedicalTechModels.Find(id);
            db.MedicalTechModels.Remove(medicaltechmodels);
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