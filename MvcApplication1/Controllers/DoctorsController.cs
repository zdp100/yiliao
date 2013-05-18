using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using MvcApplication1.Common;
using PagedList;

namespace MvcApplication1.Controllers
{ 
    public class DoctorsController : Controller
    {
        private YiLiaoContext db = new YiLiaoContext();

        //
        // GET: /Doctors/

        public ViewResult Index(string searchString,int? page)
        {
            
            var doctors = from s in db.DoctorsModels
                          //orderby s.DoctorID descending 
                          select s;
            if (!string.IsNullOrEmpty(searchString))
            {
                doctors = doctors.Where(s => s.DoctorName.ToUpper().Contains(searchString.ToUpper()));
            }
            doctors = doctors.OrderByDescending(s => s.DoctorID);
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            var doctorslist = new StaticPagedList<DoctorsModels>(doctors.ToPagedList(pageNumber, pageSize), pageNumber, pageSize,
                                                       doctors.Count());
            return View(doctorslist);
        }

        //
        // GET: /Doctors/Details/5

        public ViewResult Details(int id)
        {
            DoctorsModels doctorsmodels = db.DoctorsModels.Find(id);
            return View(doctorsmodels);
        }

        //
        // GET: /Doctors/Create

        public ActionResult Create()
        {
            CommonMethod com=new CommonMethod();
            ViewBag.sexlist=new SelectList(com.Sexlist());
            return View();
        } 

        //
        // POST: /Doctors/Create

        [HttpPost]
        public ActionResult Create(DoctorsModels doctorsmodels)
        {
            if (ModelState.IsValid)
            {
                db.DoctorsModels.Add(doctorsmodels);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(doctorsmodels);
        }
        
        //
        // GET: /Doctors/Edit/5
 
        public ActionResult Edit(int id)
        {
            DoctorsModels doctorsmodels = db.DoctorsModels.Find(id);
            CommonMethod com = new CommonMethod();
            ViewBag.sexlist = new SelectList(com.Sexlist(),doctorsmodels.sex);
            return View(doctorsmodels);
        }

        //
        // POST: /Doctors/Edit/5

        [HttpPost]
        public ActionResult Edit(DoctorsModels doctorsmodels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctorsmodels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctorsmodels);
        }

        //
        // GET: /Doctors/Delete/5
 
        public ActionResult Delete(int id)
        {
            //DoctorsModels doctorsmodels = db.DoctorsModels.Find(id);
            //return View(doctorsmodels);
            DoctorsModels doctorsmodels = db.DoctorsModels.Find(id);
            db.DoctorsModels.Remove(doctorsmodels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // POST: /Doctors/Delete/5

        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int id)
        //{            
        //    DoctorsModels doctorsmodels = db.DoctorsModels.Find(id);
        //    db.DoctorsModels.Remove(doctorsmodels);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        [AcceptVerbs(HttpVerbs.Post)]
        public ContentResult Upload0(HttpPostedFileBase FileData, string folder) {
            string filename = "";
            string uploadpath = "";
            if (null != FileData) {
                try {
                    filename = Path.GetFileName(FileData.FileName);//获得文件名
                    uploadpath = HttpContext.Server.MapPath(folder + "\\");
                    string fullPathname = Path.Combine(uploadpath, filename);
                    saveFile(FileData, uploadpath, filename);
                } catch (Exception ex) {
                    filename = ex.ToString();
                }
            }
            return Content(folder +"/"+ filename);
        }

        [NonAction]
        private bool saveFile(HttpPostedFileBase postedFile, string filepath, string saveName) {
            bool result = false;
            if (!Directory.Exists(filepath)) {
                Directory.CreateDirectory(filepath);
            }
            try {
                postedFile.SaveAs(Path.Combine(filepath, saveName));
                result = true;
            } catch (Exception e) {
                throw new ApplicationException(e.Message);
            }
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult Upload(HttpPostedFileBase fileData)
        {
            if (fileData != null)
            {
                try
                {
                    // 文件上传后的保存路径
                    string filePath = Server.MapPath("~/Uploads/image");
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    string fileName = Path.GetFileName(fileData.FileName);// 原始文件名称
                    string fileExtension = Path.GetExtension(fileName); // 文件扩展名
                    string saveName = Guid.NewGuid().ToString() + fileExtension; // 保存文件名称

                    fileData.SaveAs(filePath + saveName);

                    return Json(new { Success = true, FileName = fileName, SaveName = saveName });
                }
                catch (Exception ex)
                {
                    return Json(new { Success = false, Message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {

                return Json(new { Success = false, Message = "请选择要上传的文件！" }, JsonRequestBehavior.AllowGet);
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}