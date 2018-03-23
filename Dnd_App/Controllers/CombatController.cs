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
            var U = Dnd_App.Utils.Session.CurrentSession();
            Combat.DM = new Models.Combat.UserCombat() { User = U, RoleCombat= Models.Enum.RoleCombat.DM };

            return View(Combat);
        }

        [HttpGet]
        public ActionResult _View(long TempID)
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




        #region Callbacks --> Basic Info

        [HttpPost]
        public ActionResult _UpdateName(String newName, long TempID)
        {
            var Combat = Utils.TemporalDB.Instance.SelectCombat(TempID);
            var LastValue = Combat.Name;
            Combat.Name = newName;

            return Json(new { nameValue = "Name", lastValue = LastValue, newValue = newName });
        }


        [HttpPost]
        public ActionResult _AddParticipant(List<String> list, int TempID)
        {

            var Combat = Utils.TemporalDB.Instance.SelectCombat(TempID);
            Combat.AddUserCombat(list);


            return Json(new { nameValue = "Success" });
        }

        #endregion


        #region add npc

        [HttpGet]
        public PartialViewResult _AddNPC(long TempID)
        {
            var Combat = Utils.TemporalDB.Instance.SelectCombat(TempID);
            return PartialView(Combat);
        }

        [HttpPost]
        public ActionResult _AddNPCCombat(int IdNPC, int TempID)
        {
            
            var Combat = Utils.TemporalDB.Instance.SelectCombat(TempID);
            Utils.Presets Preset = new Utils.Presets();
            var NPC = Preset.initVoidNPC();
            NPC.Id = IdNPC;
            NPC.Select();
            Combat.InsertNPC(NPC);


            return Json(new { msg = NPC.Name + " added" });
        }

        [HttpPost]
        public ActionResult _RemoveNPCCombat(int TempIDNPC, int TempID)
        {

            var Combat = Utils.TemporalDB.Instance.SelectCombat(TempID);
            Combat.RemoveNPC(TempIDNPC);

            return Json(new { msg = "Removed" });
        }


        #endregion
    }
}