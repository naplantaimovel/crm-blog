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


namespace crm.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        private CrmContext db = new CrmContext();

        // GET: Admin/Blog
        public ActionResult Index()
        {           

            return View(db.BlogPosts.ToList());
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
        [ValidateAntiForgeryToken]
        public ActionResult Criar([Bind(Include = "BlogPostId,Titulo,Texto,Autor,Data")] BlogPost blogPost, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {

                if (file.ContentLength > 0)
                {
                    string _FileName = blogPost.Titulo.GenerateSlug() + Path.GetExtension(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Image"), _FileName);
                    file.SaveAs(_path);

                    WebImage wbImage = new WebImage("~/Image/" + _FileName);
                    wbImage.Resize(300, 300);
                    wbImage.Save(@"~/Image/" + _FileName);
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
        public ActionResult Editar([Bind(Include = "BlogPostId,Titulo,Texto,Autor,Img,Data")] BlogPost blogPost, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {               

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
    }
}
