using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ticketing.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
        //Get: SomeData
        public ActionResult SomeData()
        {
            return Content("Hi you are viewing the help content of the current function");
        }


    }
}