using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shubhammvc.Controllers
{
    public class helloController : Controller
    {
        // GET: hello
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult hi()
        {
            return View("helloview");
        }
    }
}