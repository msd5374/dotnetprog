using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shubhammvc.Controllers
{
    public class paramController : Controller
    {
        // GET: param
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult param1(int id=0,string name="",string lastname="")
        {
            
            ViewBag.id = id;
            ViewBag.name = name;
            ViewBag.lastname = lastname;
            return View();
        }
    }
}