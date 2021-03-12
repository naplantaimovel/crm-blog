using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using crm.Models;

namespace crm.Controllers
{
    public class BlogController : Controller
    {
        private CrmContext db = new CrmContext();

        // GET: Blog
        public ActionResult Index()
        {
            var blogArtigos = db.BlogArtigos.Include(b => b.BlogCategoria);
            return View(blogArtigos.ToList());
        }

        // GET: Blog/Details/5
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
