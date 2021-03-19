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

namespace crm.Controllers
{
    public class BlogController : Controller
    {
        private CrmContext db = new CrmContext();

        // GET: Blog
        public ActionResult Index()
        {
            return View(db.BlogPosts.ToList());
        }

        // GET: Blog/Details/5
        public ActionResult Post(int? id)
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
