using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dnd_App.Controllers
{
    public class HomeController : Controller
    {
        /*
         * GET Vista principal
         */
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

    }
}