using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dnd_App.Controllers
{
    public class ErrorController : Controller
    {

        public ActionResult Error(int id)
        {
            Response.StatusCode = id;

            return View();
        }

    }
}