using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using crm.Data;
using crm.Models;
using SlugGenerator;
using System.IO;
using ImageResizer;
using System.Web.Helpers;

namespace crm.Areas.Admin.Controllers
{
    public class UploadController : Controller
    {
        // GET: Admin/Upload
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Upload/Create
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Image"), _FileName);
                    file.SaveAs(_path);

                    //crop  
                    //ResizeSettings resizeSetting = new ResizeSettings
                    //{
                    //    Width = 100,
                    //    Height = 150
                    //Format = "png"
                    //};
                    //ImageBuilder.Current.Build(_path, _path, resizeSetting);
                    //crop fim

                    WebImage wbImage = new WebImage("~/Image/" + _FileName);
                    wbImage.Resize(300, 300);
                    //wbImage.FileName = "quati.jpg";
                    //wbImage.Write();
                    wbImage.Save(@"~/Image/" + _FileName);

                }

                ViewBag.Message = "File Uploaded Successfully!!";
                return View("Index");
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View("");
            }
        }
    }
}
