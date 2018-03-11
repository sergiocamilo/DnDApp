using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dnd_App.Controllers
{
    public class PCController : Controller
    {
        // GET: PC
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult _AllPC()
        {
            return PartialView();
        }


        [HttpGet]
        public ActionResult New()
        {
            Utils.Presets Preset = new Utils.Presets();
            var pc = Preset.GenerateEmptyPC();
            pc.ChangePreset();
            Utils.TemporalDB.Instance.InsertPC(pc);

            return View(pc);
        }

        [HttpGet]
        public PartialViewResult _Create(long TempID)
        {
            var pc = new Models.Characters.PC();
            pc = Utils.TemporalDB.Instance.SelectPC(TempID);
            return PartialView(pc);
        }

        [HttpGet]
        public ActionResult _View(long TempID)
        {
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);
            return PartialView(pc);
        }

    }
}