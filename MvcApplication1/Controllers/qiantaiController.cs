using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using MvcApplication1.Common;
using PagedList;

namespace MvcApplication1.Controllers
{
    public class qiantaiController : Controller
    {
        private YiLiaoContext db=new YiLiaoContext();
        //
        // GET: /qiantai/

        public ActionResult Index()
        {
            ViewBag.news = db.NewsModels.OrderBy(s => s.PubDate).Take(11).ToList();
            var model= db.DoctorsModels.OrderBy(s => s.DoctorID).Take(4);

            //var img = db.HospitalImagesModels.OrderByDescending(s => s.ImageID).Take(9).Select(m => new { ImageID = m.ImageID, ImageUrl = m.ImageUrl }).ToList();
            var img = db.HospitalImagesModels.OrderByDescending(s => s.ImageID).Take(9).ToList();
            ViewBag.images = img;
            return View(model.ToList());
        }

        //医疗概况
        public ActionResult About1()
        {
            SinglePageModels about = db.SinglePageModels.Find(1);
            SinglePageModels structure = db.SinglePageModels.Find(2);
            ViewData["about"] = about;
            ViewData["structure"] = structure;
            ViewBag.Reader = db.ReadersModels.OrderBy(s => s.ReaderID).Take(5).ToList();
            var img = db.HospitalImagesModels.OrderByDescending(s => s.ImageID).Take(9).ToList();
            ViewBag.images = img;
            return View();
        }

        public ActionResult About(int? id)
        {
            SinglePageModels model;
            id = id ?? 1;
            if (id==1 || id==2)
            {
                model = db.SinglePageModels.Find(id);
            }
            else
            {
                model= db.SinglePageModels.Find(1);
            }
            return View(model);
        }

        public ActionResult Reader(int? page)
        {
            var model = db.ReadersModels.OrderBy(s => s.ReaderID);
            int pageNumber = page ?? 1;
            int pageSize = 10;

            var list = new PagedList.StaticPagedList<ReadersModels>(
                    new PagedList<ReadersModels>(model, pageNumber, pageSize), pageNumber, pageSize,
                    model.Count());
            return View(list);
        }

        public ActionResult ReaderShow(int? id)
        {
            id = id ?? 1;
            var model = db.ReadersModels.Find(id);
            if (model==null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Images(int? page)
        {
            var model = db.HospitalImagesModels.OrderByDescending(s => s.ImageID);
      
            int pageNumber = page ?? 1;
            int pageSize = 9;

            var list = new PagedList.StaticPagedList<HospitalImagesModels>(
                    new PagedList<HospitalImagesModels>(model, pageNumber, pageSize), pageNumber, pageSize,
                    model.Count());
            return View(list);
        }

        public ActionResult ImagesShow(int? id)
        {
            var model = db.ImageUrlModelses.Where(m => m.HImagesId == id).OrderBy(m=>m.Id);
            return View(model);
        }

        //医疗指南
        public ActionResult TreatGuid(int? id)
        {
            var SinglePage = from s in db.SinglePageModels
                             where s.Type == "就医指南"
                             orderby s.ID
                             select s;
            id = (id ?? 3);
            ViewData["treat"] = db.SinglePageModels.Find(id);


            return View(SinglePage);
        }

        //名医荟萃
        public ActionResult DoctorsAtm(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 20;
            var model = db.DoctorsModels.OrderByDescending(s=>s.DoctorID);

            var Doctorslist =new PagedList.StaticPagedList<DoctorsModels>(
                    new PagedList<DoctorsModels>(model, pageNumber, pageSize), pageNumber, pageSize,
                    model.Count());
            return View(Doctorslist);
        }

        public ActionResult DoctorsAtmShow(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("DoctorsAtm");
            }
  
            var modle = db.DoctorsModels.Find(id);
            if (modle == null)
            {
                return RedirectToAction("DoctorsAtm");
            }



            //modle.Count = (modle.Count ?? 0) + 1;
            db.Entry(modle).State = EntityState.Modified;
            db.SaveChanges();
            var model = from s in db.NewsModels
                        //orderby s.PubDate descending
                        select s;
            List<string> list = new List<string>();
            foreach (var item in model.GroupBy(s => s.NewType))
            {
                list.Add(item.Key);
            }
            //ViewBag.left = homeLeft(list, "News", "新闻动态");


            ViewData["news"] = model;
            //string type = modle.NewType;

            //if (!string.IsNullOrEmpty(type))
            //{
            //    ViewBag.type = type;
            //}
            //else
            //{
            //    ViewBag.type = "新闻动态";
            //}

            return View(modle);
        }

        //新闻动态
        public ActionResult News(int? page,string type)
        {
            var model = from s in db.NewsModels
                             //orderby s.PubDate descending
                             select s;
            int pageNumber = (page ?? 1);
            int pageSize = 20;
            //ViewData["news"]  = model.GroupBy(s=>s.NewType);
            //----------------------
            List<string> list =new List<string>();
            foreach (var item in model.GroupBy(s => s.NewType))
            {
                list.Add(item.Key);
            }
            ViewBag.left = homeLeft(list, "News", "新闻动态");
            //--------------------------
            if (!string.IsNullOrEmpty(type))
            {
                model = model.Where(s => s.NewType.Contains(type));
                ViewBag.type = type;
            }
            else
            {
                ViewBag.type = "新闻动态";
            }

            //model = model.OrderByDescending(s => s.PubDate);

            var models = from s in model

                         select new listModel()
                             {
                                 id=s.NewsID,
                                 Title = s.Title,
                                 PubDate = s.PubDate
                             };
            models = models.OrderByDescending(s => s.PubDate);


            var newslist = new PagedList.StaticPagedList<listModel>(
                    new PagedList<listModel>(models, pageNumber, pageSize), pageNumber, pageSize,
                    models.Count());

            return View(newslist);
        }

        public ActionResult NewsShow(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("News");
            }
            var newsModle = db.NewsModels.Find(id);
            if (newsModle==null)
            {
                return RedirectToAction("News");
            }



            newsModle.Count = (newsModle.Count??0) + 1;
            db.Entry(newsModle).State = EntityState.Modified;
            db.SaveChanges();
            var model = from s in db.NewsModels
                        //orderby s.PubDate descending
                        select s;
            List<string> list = new List<string>();
            foreach (var item in model.GroupBy(s => s.NewType))
            {
                list.Add(item.Key);
            }
            ViewBag.left = homeLeft(list, "News", "新闻动态");


            ViewData["news"] = model;
            string type = newsModle.NewType;

            if (!string.IsNullOrEmpty(type))
            {
                ViewBag.type = type;
            }
            else
            {
                ViewBag.type = "新闻动态";
            }

            return View(newsModle);
        }

        //健康园地
        public ActionResult HealthCorner(int? page, string type)
        {
            var model = from s in db.HealthModels
                        select s;
            int pageNumber = (page ?? 1);
            int pageSize = 20;

            List<string> list = new List<string>();
            foreach (var item in model.GroupBy(s => s.HealthTypeName))
            {
                list.Add(item.Key);
            }
            ViewBag.left = homeLeft(list, "HealthCorner", "健康园地");

            //ViewData["Health"] = model;

            if (!string.IsNullOrEmpty(type))
            {
                model = model.Where(s => s.HealthTypeName.Contains(type));
                ViewBag.type = type;
            }
            else
            {
                ViewBag.type = "健康园地";
            }

            var models = from s in model

                         select new listModel()
                         {
                             id = s.HealthID,
                             Title = s.HealthHead,
                             PubDate = s.PubDate
                         };
            models = models.OrderByDescending(s => s.PubDate);


            var newslist = new PagedList.StaticPagedList<listModel>(
                    new PagedList<listModel>(models, pageNumber, pageSize), pageNumber, pageSize,
                    models.Count());
            return View(newslist);
        }

        public ActionResult HealthCornerShow(int? id)
        {
            if (id==null)
            {
                return RedirectToAction("HealthCorner");
            }

            var HealthModel = db.HealthModels.Find(id);
            if (HealthModel == null)
            {
                return RedirectToAction("HealthCorner");
            }
            HealthModel.Count = (HealthModel.Count ?? 0) + 1;
            db.Entry(HealthModel).State = EntityState.Modified;
            db.SaveChanges();
            var model = from s in db.HealthModels
                        select s;
            List<string> list = new List<string>();
            foreach (var item in model.GroupBy(s => s.HealthTypeName))
            {
                list.Add(item.Key);
            }
            ViewBag.left = homeLeft(list, "HealthCorner", "健康园地");
            //ViewData["Health"] = model;

            string type = HealthModel.HealthTypeName;

            if (!string.IsNullOrEmpty(type))
            {
                ViewBag.type = type;
            }
            else
            {
                ViewBag.type = "健康园地";
            }

            return View(HealthModel);
        }

        //医疗技术
        public ActionResult MedicalTech(int? page, string type)
        {
            var model = from s in db.MedicalTechModels
                        select s;
            int pageNumber = (page ?? 1);
            int pageSize = 20;
            List<string> list = new List<string>();
            foreach (var item in model.GroupBy(s => s.Type))
            {
                list.Add(item.Key);
            }
            ViewBag.left = homeLeft(list, "MedicalTech", "医疗技术");
            //ViewData["MedicalTech"] = model;

            if (!string.IsNullOrEmpty(type))
            {
                model = model.Where(s => s.Type.Contains(type));
                ViewBag.type = type;
            }
            else
            {
                ViewBag.type = "医疗技术";
            }

            var models = from s in model

                         select new listModel()
                         {
                             id = s.ID,
                             Title = s.Title,
                             PubDate = s.PubDate
                         };
            models = models.OrderByDescending(s => s.PubDate);


            var newslist = new PagedList.StaticPagedList<listModel>(
                    new PagedList<listModel>(models, pageNumber, pageSize), pageNumber, pageSize,
                    models.Count());
            return View(newslist);
        }

        public ActionResult MedicalTechShow(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("MedicalTech");
            }

            var MedicalModel = db.MedicalTechModels.Find(id);
            if (MedicalModel == null)
            {
                return RedirectToAction("MedicalTech");
            }
            string type = MedicalModel.Type;

            MedicalModel.Count = (MedicalModel.Count ?? 0) + 1;
            
            //db.Entry(MedicalModel).State = EntityState.Modified;
            //db.SaveChanges();

            save(MedicalModel);

            var model = from s in db.MedicalTechModels
                        select s;
            List<string> list = new List<string>();
            foreach (var item in model.GroupBy(s => s.Type))
            {
                list.Add(item.Key);
            }
            ViewBag.left = homeLeft(list, "MedicalTech", "医疗技术");
            //ViewData["MedicalTech"] = model;

            if (!string.IsNullOrEmpty(type))
            {
                ViewBag.type = type;
            }
            else
            {
                ViewBag.type = "医疗技术";
            }

            return View(MedicalModel);
        }

        public void save<T>(T model) where T : class
        {
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
        }

        //医院文化
        public ActionResult HospitalCulture(int? id)
        {
            var SinglePage = from s in db.SinglePageModels
                             where s.Type == "医院文化"
                             orderby s.ID
                             select s;
            id = (id ?? 13);
            ViewData["treat"] = db.SinglePageModels.Find(id);


            return View(SinglePage);
        }
        //联系我们
        public ActionResult ContactUs()
        {
            var model = db.SinglePageModels.Find(18);
            return View(model);
        }

        //论坛
        public ActionResult OnlineConsult(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 20;
            var model = db.MessageInfoModels
                .Include("ReplyLast")
                .OrderByDescending(s => s.PubDate).Skip((pageNumber - 1)*pageSize).Take(pageSize);
            var count = db.MessageInfoModels.Count();
            PagedList.StaticPagedList<MessageInfoModels> list = new StaticPagedList<MessageInfoModels>(model,pageNumber,pageSize,count);
            ViewBag.b = IsLoginExists();
            return View(list);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult OnlineConsult(string Title,string Content)
        {
            if (string.IsNullOrEmpty(Title) || string.IsNullOrEmpty(Content) || !IsLoginExists())
            {
                return RedirectToAction("OnlineConsult");
            }
            MessageInfoModels model=new MessageInfoModels();
            model.Title = Title;
            model.Content = Check.checkStr(Content);
            model.PubDate = DateTime.Now;
            model.UserName = Session["user"].ToString();
            model.userId = db.UsersModels.Single(u => u.UserName == model.UserName).UserID;
            db.MessageInfoModels.Add(model);
            db.SaveChanges();

            return RedirectToAction("OnlineConsult");
        }

        public ActionResult OnlineConsultShow(int id,int? page)
        {
            var model = db.MessageInfoModels
                .Include("Users")
                .Include("Reply")
                .SingleOrDefault(m => m.MessageID == id);

            model.ViewNum += 1;
            db.Entry(model).State=EntityState.Modified;
            db.SaveChanges();
            int pageNumber = (page ?? 1 );
            int pageSize = 20;
            PagedList.StaticPagedList<ReplyModel> list;


            if (pageNumber == 1)
            {            
                ReplyModel reply=new ReplyModel();
                reply.Content = model.Content;
                reply.PubDate = model.PubDate;
                reply.Users = model.Users;
                reply.MessageId = model.MessageID;

                List<ReplyModel> replylist=new List<ReplyModel>();
                replylist.Add(reply);
                IEnumerable<ReplyModel> rels;
                if (model.Reply.Count>0)
                {
                    rels = replylist.Concat(model.Reply.Take(pageSize - 1));
                }
                else
                {
                    rels = replylist;
                }

                list = new StaticPagedList<ReplyModel>(rels, pageNumber, pageSize, model.Reply.Count+1);
            }
            else
            {
                var ls = model.Reply.Skip((pageNumber - 1)*pageSize - 1).Take(pageSize);
                list = new StaticPagedList<ReplyModel>(ls, pageNumber, pageSize, model.Reply.Count+1);
            }
            ViewBag.b = IsLoginExists();
            ViewBag.list = list;
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult OnlineConsultShow(string Content,int? id)
        {
            var mid = id ?? 1;
            if (!string.IsNullOrEmpty(Content) || IsLoginExists())
            {
                string name = Session["user"].ToString();
                var model = new ReplyModel();
                model.Content =Check.checkStr(Content);
                model.userId = db.UsersModels.Single(u => u.UserName == name).UserID;
                model.MessageId = mid;
                model.PubDate = DateTime.Now;
                db.ReplyModel.Add(model);
                db.SaveChanges();
                var message = db.MessageInfoModels.Single(m => m.MessageID == id);
                message.ReplyNum = db.ReplyModel.Count(r => r.MessageId == id);
                message.ReplyLastId = model.ReplyId;
                db.Entry(message).State=EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("OnlineConsultShow", new { id = mid });
        }


        //左边菜单
        public HomeLeft homeLeft<T>(T model, string strAction, string strName) where T : List<string>
        {
            HomeLeft left = new HomeLeft();
            left.list = model;
            left.strAction = strAction;
            left.strName = strName;
            return left;
        }

        public ActionResult homeRightlist(StaticPagedList<listModel> listmodel, string strTypes, string strType, string strActions, string strAction)
        {
            ViewBag.Types = strTypes;
            ViewBag.Type = strType;
            ViewBag.strActions = strActions;
            ViewBag.strAction = strAction;
            return PartialView("HomeRightList", listmodel);
        }

        //注册
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                UsersModels users=new UsersModels();
                users.UserName = model.UserName;
                users.UserPassword = DESEncrypt.Encrypt(model.UserPassword);
                users.Email = model.Email;
                users.RegisterDate=DateTime.Now;
                db.UsersModels.Add(users);
                db.SaveChanges();

            }
            

            return View("RegisterResult");
        }

        public ActionResult RegisterResult()
        {
            return View();
        }

        //验证
        public ActionResult IsUserExists(string UserName)
        {
            bool Exists = db.UsersModels.Count(u => u.UserName == UserName)==0;
            return Json(Exists, JsonRequestBehavior.AllowGet);
        }

        //验证
        public ActionResult IsPwdExists(string OldPassWord)
        {
            if (IsLoginExists())
            {
                string user = Session["user"].ToString();
                
                if (string.IsNullOrEmpty( Session["pwd"] as string))
                {
                    UsersModels model = db.UsersModels.Single(u => u.UserName == user);
                    string pwd = model.UserPassword;
                    Session["pwd"] = DESEncrypt.Decrypt(pwd);
                }

                bool Exists = (OldPassWord == Session["pwd"].ToString());
                //bool Exists = db.UsersModels.Count(m => m.UserName == user && m.UserPassword == pwd)==1;

                return Json(Exists, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Content("<script>location.href='/';</script>");
            }
        }

        public ActionResult UserLogin()
        {
            return View();
        }
        public ActionResult Ulg(string url)
        {
            ViewBag.url = url;
            return View();
        }



        [HttpPost]
        public ActionResult Ulg(UserLoginViewModel model,string url)
        {
            if (ModelState.IsValid)
            {
                string password = DESEncrypt.Encrypt(model.PassWord);
                var count =
                    db.UsersModels.Count(
                        u => u.UserName == model.UserName && u.UserPassword == password);

                if (count==1)
                {

                    Session["user"] = model.UserName;
                    HttpCookie c=new HttpCookie("user");
                    c.Values.Add("u",DESEncrypt.Encrypt(model.UserName));
                    c.Values.Add("p", DESEncrypt.Encrypt(model.PassWord));
                    c.Expires.AddDays(1);
                    Response.Cookies.Add(c);
                    string str = "";
                    if (!string.IsNullOrEmpty(url))
                    {
                        str = "<script>location.href='"+url+"';</script>";
                    }
                    else
                    {
                        str = "<script>location.href='/';</script>";
                    }
                    
                    return Content(str);
                }
                else
                {
                    ModelState.AddModelError("","用户名或密码错误");
                }
            }
            return View();
        }

        public ActionResult userSet()
        {
            return View();
        }
        public ActionResult userSetHeadPor()
        {
            if (IsLoginExists())
            {
                string user = Session["user"].ToString();
                UsersModels model = db.UsersModels.Single(m => m.UserName == user);
                ViewBag.image = model.Images;
                ViewBag.uid = model.UserName;
                return View();
            }
            else
            {
                return Content("<script>location.href='/';</script>");
            }
        }


        public ActionResult userSetPersonal()
        {
            if (IsLoginExists())
            {
                string user = Session["user"].ToString();
                UsersModels model = db.UsersModels.Single(m => m.UserName == user);
                CommonMethod com = new CommonMethod();
                ViewBag.sexlist = new SelectList(com.Sexlist(), model.Sex);   
                return View(model);             
            }
            else
            {
                return Content("<script>location.href='/';</script>");
            }

            
        }

        [HttpPost]
        public ActionResult userSetPersonal(UsersModels model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State=EntityState.Modified;
                db.SaveChanges();
            }
            CommonMethod com = new CommonMethod();
            ViewBag.sexlist = new SelectList(com.Sexlist(), model.Sex);
            ViewBag.message = "<script>alert('修改成功')</script>";
            return View(model);
        }

        public ActionResult userSetPassWord()
        {
            return View();
        }

        [HttpPost]
        public ActionResult userSetPassWord(PassWordViewModel pwdmod)
        {
            if (IsLoginExists())
            {            
                if (ModelState.IsValid)
                {
                    string user = Session["user"].ToString();
                    UsersModels model = db.UsersModels.Single(m => m.UserName == user);
                    model.UserPassword = DESEncrypt.Encrypt(pwdmod.NewPassWord);
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();
                    Session["pwd"] = null;
                    ViewBag.message = "<script>alert('修改成功')</script>";
                    
                }
                return View();

            }
            else
            {
                return Content("<script>location.href='/';</script>");
            }

        }

        private bool IsLoginExists()
        {
            bool b=false;
            if (string.IsNullOrEmpty(Session["user"] as string))
            {
                if (Request.Cookies["user"] != null)
                {
                    string Name = Request.Cookies["user"]["u"];
                    string userName = DESEncrypt.Decrypt(Name);
                    string password = Request.Cookies["user"]["p"];
                    var count =
                        db.UsersModels.Count(
                            u => u.UserName == userName && u.UserPassword == password);
                    if (count == 1)
                    {
                        b = true;
                        Session["user"] = userName;
                    }
                }
                else
                {
                    b = false;
                }
            }
            else
            {
                b = true;
            }
            return b;
        }


        public ActionResult isLogin()
        {
            if (string.IsNullOrEmpty(Session["user"] as string))
            {
                if (Request.Cookies["user"]!=null)
                {
                    string Name = Request.Cookies["user"]["u"];
                    string userName = DESEncrypt.Decrypt(Name);
                    string password = Request.Cookies["user"]["p"];
                    var count =
                        db.UsersModels.Count(
                            u => u.UserName == userName && u.UserPassword == password);
                    if (count==1)
                    {
                        ViewBag.isuser = true;
                        ViewBag.userName = userName;
                        Session["user"] = userName;
                    }
                }
                else
                {
                    ViewBag.isuser = false;
                }
            }
            else
            {
                ViewBag.isuser = true;
                ViewBag.userName = Session["user"].ToString();
            }
            return PartialView("ViewUserLogin");
        }

        public ActionResult OutLogin(string url)
        {
            Session["user"] = null;
            Response.Cookies["user"].Expires=DateTime.Now.AddDays(-1);
            if (!string.IsNullOrEmpty(url))
            {
                return Redirect(url);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
