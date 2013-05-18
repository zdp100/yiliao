using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class UploadController : Controller
    {
        YiLiaoContext db=new YiLiaoContext();

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult Upload(HttpPostedFileBase fileData, string folder)
        {
            if (fileData != null)
            {
                try
                {
                    // 文件上传后的保存路径
                    string filePath = Server.MapPath(@"~" + folder+@"/");
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    string fileName = Path.GetFileName(fileData.FileName);// 原始文件名称
                    string fileExtension = Path.GetExtension(fileName); // 文件扩展名
                    string saveName = Guid.NewGuid().ToString() + fileExtension; // 保存文件名称

                    fileData.SaveAs(filePath + saveName);

                    return Json(new { Success = true, Folder = folder, SaveName = saveName });
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

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadList(HttpPostedFileBase fileData, string folder)
        {
            if (fileData != null)
            {
                try
                {
                    // 文件上传后的保存路径
                    string filePath = Server.MapPath(@"~" + folder + @"/");
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    string fileName = Path.GetFileName(fileData.FileName);// 原始文件名称
                    string fileExtension = Path.GetExtension(fileName); // 文件扩展名
                    string saveName = Guid.NewGuid().ToString() + fileExtension; // 保存文件名称
                    string fileUrl = folder+@"/"+saveName;//根路径
                    fileData.SaveAs(filePath + saveName);

                    //存数据库
                    ImageUrlModels model =new ImageUrlModels();
                    model.ImageUrl = fileUrl;
                    db.ImageUrlModelses.Add(model);
                    db.SaveChanges();
                    //var m = db.ImageUrlModelses.Max(s => s.Id);
                    //string id = m.ToString();




                    return Json(new { Success = true, Folder = folder, SaveName = saveName, Id = model.Id});
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

        private string Psth = "Uploadfile\\headImg";
        private string Dir = "Uploadfile/headImg";
        private HttpServerUtilityBase server;
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult FlashUpFile(string input, string Filename, string Upload, string avatar1, string avatar2, string avatar3,string appid)
        {
            

            server = Server;
            string uid = input;
            
            if (!string.IsNullOrEmpty(Filename) && !string.IsNullOrEmpty(Upload))
            {
                //return Content("http://localhost:4822/Uploadfile/image/1.jpg");
                return Content(UploadTempAvatar(Server,Request,uid));
            }
            if (!string.IsNullOrEmpty(avatar1) && !string.IsNullOrEmpty(avatar2) && !string.IsNullOrEmpty(avatar3))
            {
                //创建路径
                CreateDir(Server,uid);
                //保存图片
                if (!(SaveAvatar(avatar1, "avatar1", uid, appid) && SaveAvatar(avatar2, "avatar2", uid, appid) && SaveAvatar(avatar3, "avatar3", uid, appid)))
                {
                    //删除源文件
                    System.IO.File.Delete(GetMapPath(Server, Psth + "temp\\" + uid + ".jpg"));//dir
                    return Content("<?xml version=\"1.0\" ?><root><face success=\"0\"/></root>");
                }
                System.IO.File.Delete(GetMapPath(Server, Psth + "temp\\" + uid + ".jpg"));//dir
                return Content("<?xml version=\"1.0\" ?><root><face success=\"1\"/></root>");
                //return;
            }
            //return Json(new { Success = false, Message = "请选择要上传的文件！" }, JsonRequestBehavior.AllowGet);
            return Content("");
        }
        //判断路径是否存在，不存在就创建
        private void CreateDir(HttpServerUtilityBase serverUtilityBase, string uid)
        {
            string strdate = DateTime.Now.ToString("yyyy-MM-dd");
            string avatarDir = string.Format(Dir + "/{0}",//dir
                 strdate);
            if (!Directory.Exists(GetMapPath(serverUtilityBase, avatarDir)))
                Directory.CreateDirectory(GetMapPath(serverUtilityBase, avatarDir));
        }
        

        //上传图片
        private string UploadTempAvatar(HttpServerUtilityBase serverUtilityBase,HttpRequestBase requestBase,string uid)
        {
            string filename = uid + ".jpg";
            string uploadUrl = GetRootUrl(requestBase) + Dir;
            string uploadDir = GetMapPath(serverUtilityBase, Psth);
            if (!Directory.Exists(uploadDir + "temp\\"))
                Directory.CreateDirectory(uploadDir + "temp\\");

            filename = "temp/" + filename;
            if (requestBase.Files.Count > 0)
            {
                requestBase.Files[0].SaveAs(uploadDir + filename);
            }

            return uploadUrl + filename;
        }

        //数据转换
        private byte[] FlashDataDecode(string s)
        {
            byte[] r = new byte[s.Length / 2];
            int l = s.Length;
            for (int i = 0; i < l; i = i + 2)
            {
                int k1 = ((int)s[i]) - 48;
                k1 -= k1 > 9 ? 7 : 0;
                int k2 = ((int)s[i + 1]) - 48;
                k2 -= k2 > 9 ? 7 : 0;
                r[i / 2] = (byte)(k1 << 4 | k2);
            }
            return r;
        }

        //保存图片
        private bool SaveAvatar(string avatar,string type ,string uid,string appid)
        {
            //string strdate = DateTime.Now.ToString("yyyy-MM-dd");
            byte[] b = FlashDataDecode(avatar);
            if (b.Length == 0)
                return false;
            string size = "";
            if (type == "avatar1")
                size = "large";
            else if (type == "avatar2")
                size = "medium";
            else
                size = "small";
            string avatarFileName = string.Format(Dir + "/{0}-{1}.jpg",//dir
                uid, size);
            //if (type == "avatar2" && appid=="0")
            if (type == "avatar2" )
            {
                if (!SaveAvatarSql("/" + avatarFileName))
                {
                    return false;
                }
            }
            FileStream fs = new FileStream(GetMapPath(server, avatarFileName), FileMode.Create);
            fs.Write(b, 0, b.Length);
            fs.Close();
            return true;
        }

        public bool SaveAvatarSql(string url)
        {
            if (!string.IsNullOrEmpty(Session["user"] as string))
            {
                string user = Session["user"].ToString();
                var model = db.UsersModels.Single(u => u.UserName == user);
                model.Images = url;
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        //返回URL
        public static string GetRootUrl(HttpRequestBase requestBase)
        {

            string ApplicationPath = requestBase.ApplicationPath != "/" ? requestBase.ApplicationPath : string.Empty;
            int port = requestBase.Url.Port;
            return string.Format("{0}://{1}{2}{3}/",
                                 requestBase.Url.Scheme,
                                 requestBase.Url.Host,
                                 (port == 80 || port == 0) ? "" : ":" + port,
                                 ApplicationPath);
        }

        //获取地址
        public static string GetMapPath(HttpServerUtilityBase server, string strPath)
        {

            if (server != null)
            {
                return server.MapPath(@"~/"+strPath);
            }
            else //非web程序引用
            {
                strPath = strPath.Replace("/", "\\");
                if (strPath.StartsWith("\\"))
                {
                    strPath = strPath.Substring(strPath.IndexOf('\\', 1)).TrimStart('\\');
                }
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }
    }
}
