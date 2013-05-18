using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{ 
    public class HospitalImagesController : Controller
    {
        private YiLiaoContext db = new YiLiaoContext();

        //
        // GET: /HospitalImages/

        public ViewResult Index()
        {
            return View(db.HospitalImagesModels.ToList());
        }

        //
        // GET: /HospitalImages/Details/5

        public ViewResult Details(int id)
        {
            HospitalImagesModels hospitalimagesmodels = db.HospitalImagesModels.Find(id);
            return View(hospitalimagesmodels);
        }

        //
        // GET: /HospitalImages/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /HospitalImages/Create

        [HttpPost]
        public ActionResult Create(HospitalImagesModels hospitalimagesmodels, string hideImageAdd, string hideImageDel)
        {
            if (ModelState.IsValid)
            {
                db.HospitalImagesModels.Add(hospitalimagesmodels);
                db.SaveChanges();
                bool b = false;
                if (!string.IsNullOrEmpty(hideImageAdd))
                {
                    string[] strid = hideImageAdd.Split(',');

                    foreach (var s in strid)
                    {
                        int id = Convert.ToInt32(s);
                        var model = db.ImageUrlModelses.Find(id);
                        model.HImages = hospitalimagesmodels;
                        db.Entry(model).State=EntityState.Modified;
                    }
                    b = true;
                }
                if (!string.IsNullOrEmpty(hideImageDel))
                {
                    string[] strid = hideImageDel.Split(',');

                    foreach (var s in strid)
                    {
                        int id = Convert.ToInt32(s);
                        var model = db.ImageUrlModelses.Find(id);
                        db.ImageUrlModelses.Remove(model);

                        //删除物理图片
                        //
                        //
                    }
                    b = true;
                }
                if (b)
                {
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            return View(hospitalimagesmodels);
        }
        
        //
        // GET: /HospitalImages/Edit/5
 
        public ActionResult Edit(int id)
        {

            

            HospitalImagesModels hospitalimagesmodels = db.HospitalImagesModels.Find(id);
            //var model = db.ImageUrlModelses.Where(s => s.HImages.ImageID== hospitalimagesmodels.ImageID).ToList();
            //hospitalimagesmodels.imageUrlModels = model;

            return View(hospitalimagesmodels);
        }

        //
        // POST: /HospitalImages/Edit/5

        [HttpPost]
        public ActionResult Edit(HospitalImagesModels hospitalimagesmodels, string hideImageAdd, string hideImageDel)
        {
            if (ModelState.IsValid)
            {
                


                db.Entry(hospitalimagesmodels).State = EntityState.Modified;
                db.SaveChanges();

                hospitalimagesmodels.imageUrlModels = new Collection<ImageUrlModels>(db.ImageUrlModelses.Where(s => s.HImages.ImageID == hospitalimagesmodels.ImageID).ToList());

                bool b = false;
                if (hideImageAdd!="")
                {
                    string[] strid = hideImageAdd.Split(',');
                    //List<ImageUrlModels> list =new List<ImageUrlModels>();
                    
                    foreach (var s in strid)
                    {
                        int id = Convert.ToInt32(s);
                        var model = db.ImageUrlModelses.Find(id);
                        //list.Add(model);
                        hospitalimagesmodels.imageUrlModels.Add(model);
                        
                    }
                    b = true;
                    //hospitalimagesmodels.imageUrlModels = list; 
                }
                if (hideImageDel!="")
                {
                    string[] strid = hideImageDel.Split(',');
                    //List<ImageUrlModels> list =new List<ImageUrlModels>();
                    foreach (var s in strid)
                    {
                        int id = Convert.ToInt32(s);
                        var model = db.ImageUrlModelses.Find(id);
                        //list.Add(model);
                        hospitalimagesmodels.imageUrlModels.Remove(model);
                    }
                    b = true;
                }
                if (b)
                {
                    db.SaveChanges();
                }
                


                return RedirectToAction("Index");
            }
            return View(hospitalimagesmodels);
        }

        //
        // GET: /HospitalImages/Delete/5
 
        public ActionResult Delete(int id)
        {
            HospitalImagesModels hospitalimagesmodels = db.HospitalImagesModels.Find(id);
            return View(hospitalimagesmodels);
        }

        //
        // POST: /HospitalImages/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            HospitalImagesModels hospitalimagesmodels = db.HospitalImagesModels.Find(id);
            db.HospitalImagesModels.Remove(hospitalimagesmodels);
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