using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dnd_App.Controllers
{
    public class NPCController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _AllNPC()
        {
            TempData["CurrentAction"] = "_AllNPC";
            TempData["CurrentController"] = "NPC";
            return PartialView();
        }

        public ActionResult _View(int Id)
        {
            //var NPC;
            return PartialView();
        }

    }
}