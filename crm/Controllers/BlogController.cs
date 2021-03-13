using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace crm.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }

        // GET: Blog/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }  
    }
}
