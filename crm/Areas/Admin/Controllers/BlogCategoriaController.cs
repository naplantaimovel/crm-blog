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
    public class BlogCategoriaController : Controller
    {
        private CrmContext db = new CrmContext();

        // GET: Admin/BlogCategoria
        public ActionResult Index()
        {
            return View(db.BlogCategorias.ToList());
        }

        // GET: Admin/BlogCategoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogCategoria blogCategoria = db.BlogCategorias.Find(id);
            if (blogCategoria == null)
            {
                return HttpNotFound();
            }
            return View(blogCategoria);
        }

        // GET: Admin/BlogCategoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/BlogCategoria/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlogCategoriaId,Categoria")] BlogCategoria blogCategoria)
        {
            if (ModelState.IsValid)
            {
                db.BlogCategorias.Add(blogCategoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blogCategoria);
        }

        // GET: Admin/BlogCategoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogCategoria blogCategoria = db.BlogCategorias.Find(id);
            if (blogCategoria == null)
            {
                return HttpNotFound();
            }
            return View(blogCategoria);
        }

        // POST: Admin/BlogCategoria/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogCategoriaId,Categoria")] BlogCategoria blogCategoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogCategoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogCategoria);
        }

        // GET: Admin/BlogCategoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogCategoria blogCategoria = db.BlogCategorias.Find(id);
            if (blogCategoria == null)
            {
                return HttpNotFound();
            }
            return View(blogCategoria);
        }

        // POST: Admin/BlogCategoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogCategoria blogCategoria = db.BlogCategorias.Find(id);
            db.BlogCategorias.Remove(blogCategoria);
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
