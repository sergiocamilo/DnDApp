using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dnd_App.Controllers
{
    public class CombatController : Controller
    {
        // GET: Combat
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult _AllCombats()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult New()
        {
            Utils.Presets Preset = new Utils.Presets();
            var Combat = Preset.GenerateEmptyCombat();
            Utils.TemporalDB.Instance.InsertCombat(Combat);

            return View(Combat);
        }

        [HttpGet]
        public ActionResult _View(long TempID)
        {
            var Combat = Utils.TemporalDB.Instance.SelectCombat(TempID);
            return PartialView(Combat);
        }

        [HttpGet]
        public PartialViewResult _AddNPC(long TempID)
        {
            var Combat = Utils.TemporalDB.Instance.SelectCombat(TempID);
            return PartialView(Combat);
        }

        [HttpGet]
        public PartialViewResult _AddPC(long TempID)
        {
            var Combat = Utils.TemporalDB.Instance.SelectCombat(TempID);
            return PartialView(Combat);
        }



    }
}