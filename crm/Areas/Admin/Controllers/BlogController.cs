using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using crm.Models;

namespace crm.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        private CrmContext db = new CrmContext();

        // GET: Admin/Blog
        public ActionResult Index()
        {
            var blogArtigos = db.BlogArtigos.Include(b => b.BlogCategoria);
            return View(blogArtigos.ToList());
        }

        // GET: Admin/Blog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogArtigo blogArtigo = db.BlogArtigos.Find(id);
            if (blogArtigo == null)
            {
                return HttpNotFound();
            }
            return View(blogArtigo);
        }

        // GET: Admin/Blog/Create
        public ActionResult Create()
        {
            ViewBag.BlogCategoriaId = new SelectList(db.BlogCategorias, "BlogCategoriaId", "Categoria");
            return View();
        }

        // POST: Admin/Blog/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlogArtigoId,Titulo,Texto,BlogCategoriaId")] BlogArtigo blogArtigo)
        {
            if (ModelState.IsValid)
            {
                db.BlogArtigos.Add(blogArtigo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BlogCategoriaId = new SelectList(db.BlogCategorias, "BlogCategoriaId", "Categoria", blogArtigo.BlogCategoriaId);
            return View(blogArtigo);
        }

        // GET: Admin/Blog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogArtigo blogArtigo = db.BlogArtigos.Find(id);
            if (blogArtigo == null)
            {
                return HttpNotFound();
            }
            ViewBag.BlogCategoriaId = new SelectList(db.BlogCategorias, "BlogCategoriaId", "Categoria", blogArtigo.BlogCategoriaId);
            return View(blogArtigo);
        }

        // POST: Admin/Blog/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogArtigoId,Titulo,Texto,BlogCategoriaId")] BlogArtigo blogArtigo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogArtigo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BlogCategoriaId = new SelectList(db.BlogCategorias, "BlogCategoriaId", "Categoria", blogArtigo.BlogCategoriaId);
            return View(blogArtigo);
        }

        // GET: Admin/Blog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogArtigo blogArtigo = db.BlogArtigos.Find(id);
            if (blogArtigo == null)
            {
                return HttpNotFound();
            }
            return View(blogArtigo);
        }

        // POST: Admin/Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogArtigo blogArtigo = db.BlogArtigos.Find(id);
            db.BlogArtigos.Remove(blogArtigo);
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
