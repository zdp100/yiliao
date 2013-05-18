using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using PagedList;
using MvcApplication1.Common;

namespace MvcApplication1.Controllers
{   
    //[LoginAuthorize]
    public class NewsController : Controller
    {
        private YiLiaoContext db = new YiLiaoContext();

        //
        // GET: /News/

        public ViewResult Index(string searchString,int? page)
        {
            var news = from s in db.NewsModels
                       select s;
            if (!string.IsNullOrEmpty(searchString))
            {
                news = news.Where(s => s.Title.ToUpper().Contains(searchString.ToUpper()) || s.NewType.ToUpper().Contains(searchString.ToUpper()));
            }

            news = news.OrderByDescending(s => s.PubDate);

            int pageSize = 20;
            int pageNumber = (page ?? 1);

            var newsList = new StaticPagedList<NewsModels>(news.ToPagedList(pageNumber, pageSize), pageNumber, pageSize,
                                                           news.Count());
            return View(newsList);
        }

        //
        // GET: /News/Details/5

        public ViewResult Details(int id)
        {
            NewsModels newsmodels = db.NewsModels.Find(id);
            return View(newsmodels);
        }

        private List<SelectListItem> newTypeList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "动态新闻", Value = "动态新闻" });
            list.Add(new SelectListItem() { Text = "媒体聚焦", Value = "媒体聚焦" });
            list.Add(new SelectListItem() { Text = "电子院刊", Value = "电子院刊" });
            list.Add(new SelectListItem() { Text = "科室传真", Value = "科室传真" });
            //List<string> list=new List<string>();
            //list.Add("动态新闻");
            //list.Add("媒体聚焦");
            //list.Add("电子院刊");
            //list.Add("科室传真");
            return list;
        }

        //
        // GET: /News/Create

        public ActionResult Create()
        {
            ViewBag.sl = new SelectList(newTypeList(), "Value", "Text");

            return View();
        } 

        //
        // POST: /News/Create
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(NewsModels newsmodels)
        {
            ViewBag.sl = new SelectList(newTypeList(), "Value", "Text");
            if (ModelState.IsValid)
            {
                db.NewsModels.Add(newsmodels);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(newsmodels);
        }
        
        //
        // GET: /News/Edit/5
 
        public ActionResult Edit(int id)
        {
            NewsModels newsmodels = db.NewsModels.Find(id);
            ViewBag.sl = new SelectList(newTypeList(), "Value", "Text", newsmodels.NewType);
            return View(newsmodels);
        }

        //
        // POST: /News/Edit/5
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(NewsModels newsmodels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsmodels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.sl = new SelectList(newTypeList(), "Value", "Text", newsmodels.NewType);
            return View(newsmodels);
        }

        //
        // GET: /News/Delete/5
 
        public ActionResult Delete(int id)
        {
            NewsModels newsmodels = db.NewsModels.Find(id);
            db.NewsModels.Remove(newsmodels);
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