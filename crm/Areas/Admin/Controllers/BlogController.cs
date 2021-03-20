using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using crm.Data;
using crm.Models;
using SlugGenerator;
using System.Web.Helpers;
using System.IO;
using PagedList;


namespace crm.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        private CrmContext db = new CrmContext();

        // GET: Admin/Blog
        public ActionResult Index(string q, int? p)
        {
            return View(db.BlogPosts.Where(x => x.Titulo.StartsWith(q) || q == null).ToList().ToPagedList(p ?? 1, 5));
        }

        // GET: Admin/Blog/Detalhes/5
        public ActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = db.BlogPosts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // GET: Admin/Blog/Criar
        public ActionResult Criar()
        {
            return View();
        }

        // POST: Admin/Blog/Criar   
        [HttpPost, ActionName("Criar")]
        [ValidateAntiForgeryToken]
        public ActionResult Criar([Bind(Include = "BlogPostId,Titulo,Texto,Autor,Data")] BlogPost blogPost, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {

                if (file != null && file.ContentLength > 0)
                {
                    string _FileName = blogPost.Titulo.GenerateSlug() + Path.GetExtension(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Image"), _FileName);
                    file.SaveAs(_path);

                    WebImage wbImage = new WebImage("~/Image/" + _FileName);
                    wbImage.Resize(990, 1000);
                    wbImage.Save(@"~/Image/" + _FileName);

                    WebImage wbImageThumbnail = new WebImage("~/Image/" + _FileName);
                    wbImageThumbnail.Resize(200, 1000);
                    wbImageThumbnail.Save(@"~/Image/Thumbnail/" + _FileName);

                    blogPost.Img = _FileName;
                }
                else {

                    blogPost.Img = "preview.jpg";
                }

                blogPost.Slug = blogPost.Titulo.GenerateSlug();                
                blogPost.Status = 1;

                db.BlogPosts.Add(blogPost);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(blogPost);            
        }        
        

        // GET: Admin/Blog/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = db.BlogPosts.Find(id);            

            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // POST: Admin/Blog/Editar/5        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "BlogPostId,Titulo,Texto,Autor,Data")] BlogPost blogPost, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    string _FileName = blogPost.Titulo.GenerateSlug() + Path.GetExtension(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Image"), _FileName);
                    file.SaveAs(_path);

                    WebImage wbImage = new WebImage("~/Image/" + _FileName);
                    wbImage.Resize(990, 1000);
                    wbImage.Save(@"~/Image/" + _FileName);

                    WebImage wbImageThumbnail = new WebImage("~/Image/" + _FileName);
                    wbImageThumbnail.Resize(200, 1000);
                    wbImageThumbnail.Save(@"~/Image/Thumbnail/" + _FileName);

                    blogPost.Img = _FileName;
                }
                else
                {
                    blogPost.Img = blogPost.Img;
                }

                blogPost.Slug = blogPost.Titulo.GenerateSlug();
                blogPost.Status = 1;

                db.Entry(blogPost).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(blogPost);
        }

        // GET: Admin/Blog/Excluir/5
        public ActionResult Excluir(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = db.BlogPosts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // POST: Admin/Blog/Excluir/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmar(int id)
        {
            BlogPost blogPost = db.BlogPosts.Find(id);
            db.BlogPosts.Remove(blogPost);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public string Thumbnail(string img) {

            if (img == null)
            {
                img = "preview.jpg";
            }           

            return img;        
        }

        public void SelectPicture()
        {
            WebImage img = new WebImage("~/Image/preview.jpg");
            img.Resize(200, 200);
            img.FileName = "~/Image/preview.jpg";
            img.Write();
        }

        
    }
}
