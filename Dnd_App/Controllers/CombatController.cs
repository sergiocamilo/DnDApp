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
        public ActionResult Generate(long TempID)
        {
            var Combat = Utils.TemporalDB.Instance.SelectCombat(TempID);
            if (Combat.Characters == null)
            {
                Combat.GenerateCharacterList();
            }
            
            //var Combat = new Models.Combat.Combat();
            //Combat.NPCs = new List<Models.Combat.NPCCombat>();
            //Combat.PCs = new List<Models.Combat.PCCombat>();
            return View(Combat);
        }

        [HttpGet]
        public ActionResult Join()
        {
            var U = Dnd_App.Utils.Session.CurrentSession();
            var Combats = Utils.TemporalDB.Instance.CombatInstances;
            var CombatUser = new Dictionary<long,Models.Combat.Combat>();
            foreach (var c in Combats)
            {
                foreach (var p in c.Value.Participants)
                {
                    if (p.User.UserName == U.UserName)
                    {
                        CombatUser.Add(c.Key, c.Value);
                    }
                }
            }
            return View(CombatUser);
        }


        [HttpGet]
        public ActionResult JoinUser(long TempID)
        {
            var Combat = Utils.TemporalDB.Instance.SelectCombat(TempID);
            var U = Dnd_App.Utils.Session.CurrentSession();
            ViewBag.index = 0;
            for (int i = 0; i < Combat.PCs.Count; i++)
            {
                if (Combat.PCs[i].User.UserName == U.UserName)
                {
                    ViewBag.index = i;
                    break;
                }
            }
            return View(Combat);
        }

        [HttpGet]
        public ActionResult UserStatistic(long TempIDCombat, int IPC)
        {
            var Combat = Utils.TemporalDB.Instance.SelectCombat(TempIDCombat);
            var U = Dnd_App.Utils.Session.CurrentSession();
            ViewBag.index = IPC;
            
            return PartialView(Combat);
        }


        [HttpPost]
        public ActionResult RequestTurn(long TempID)
        {
            var Combat = Utils.TemporalDB.Instance.SelectCombat(TempID);
            if (!Combat.Active)
            {
                Combat.Turn = -1;
            }

            return Json(new { Turn = Combat.Turn });
        }

        [HttpPost]
        public void EndCombat(long TempID)
        {
            var Combat = Utils.TemporalDB.Instance.SelectCombat(TempID);
            Combat.Active = false;
        }


        [HttpGet]
        public PartialViewResult _CurrentCharacter(long TempID)
        {
            var Combat = Utils.TemporalDB.Instance.SelectCombat(TempID);
            return PartialView(Combat);
        }

        [HttpPost]
        public ActionResult Heal(int Val, Models.Enum.TypeCharacter Type, int ICharacter, long TempID)
        {
            var Combat = Utils.TemporalDB.Instance.SelectCombat(TempID);
            if (Type == Models.Enum.TypeCharacter.NPC)
            {
                if (Combat.Characters[ICharacter].HP >= Combat.NPCs[Combat.Characters[ICharacter].iList].NPC.HitPoint.HitPointsAVG)
                {
                    return Json(new { msg = "Max value for HP" });
                }
                else
                {
                    Combat.Characters[ICharacter].HP += Val;
                    if (Combat.Characters[ICharacter].HP > Combat.NPCs[Combat.Characters[ICharacter].iList].NPC.HitPoint.HitPointsAVG)
                    {
                        Combat.Characters[ICharacter].HP = Combat.NPCs[Combat.Characters[ICharacter].iList].NPC.HitPoint.HitPointsAVG;
                    }
                }
            }
            else
            {
                if (Combat.Characters[ICharacter].HP >= Combat.PCs[Combat.Characters[ICharacter].iList].PC.hitPoint.HitPointsAVG)
                {
                    return Json(new { msg = "Max value for HP" });
                }
                else
                {
                    Combat.Characters[ICharacter].HP += Val;
                    if (Combat.Characters[ICharacter].HP > Combat.PCs[Combat.Characters[ICharacter].iList].PC.hitPoint.HitPointsAVG)
                    {
                        Combat.Characters[ICharacter].HP = Combat.PCs[Combat.Characters[ICharacter].iList].PC.hitPoint.HitPointsAVG;
                    }

                }
            }
            return Json(new { msg = "Heal "+ Val + ", HP was increased to " + Combat.Characters[ICharacter].HP });
        }

        [HttpPost]
        public ActionResult TemporaryHP(int Val, Models.Enum.TypeCharacter Type, int ICharacter, long TempID)
        {
            var Combat = Utils.TemporalDB.Instance.SelectCombat(TempID);
            Combat.Characters[ICharacter].HP += Val;
            
            return Json(new { msg = "Temporary hp add " + Val + ", HP was increased to " + Combat.Characters[ICharacter].HP });
        }




        [HttpPost]
        public ActionResult Harm(int Val, Models.Enum.TypeCharacter Type, int ICharacter, long TempID)
        {
            var Combat = Utils.TemporalDB.Instance.SelectCombat(TempID);
            Combat.Characters[ICharacter].HP -= Val;
            if (Type == Models.Enum.TypeCharacter.NPC)
            {
                if (Combat.Characters[ICharacter].HP <= 0)
                {
                    Combat.Characters[ICharacter].HP = 0;
                    Combat.Characters[ICharacter].Active = false;
                }
            }
            else
            {
                if (Combat.Characters[ICharacter].HP <= 0)
                {
                    Combat.Characters[ICharacter].HP = 0;
                    Combat.Characters[ICharacter].Active = false;
                }
            }
            return Json(new { msg = "Attack " + Val + ", HP was decreased to " + Combat.Characters[ICharacter].HP });
        }


        [HttpPost]
        public ActionResult ChangeInitiative(int TempIDChar, int Type, int Val, int TempID)
        {

            var Combat = Utils.TemporalDB.Instance.SelectCombat(TempID);
            try
            {
                if (Type == 0)
                {
                    Combat.NPCs.Where(npc => npc.TempID == TempIDChar).First().Initiative = Val;
                    return Json(new { msg = "Initiative changed to " + Combat.NPCs.Where(npc => npc.TempID == TempIDChar).First().NPC.Name });
                }
                else
                {
                    Combat.PCs.Where(pc => pc.TempID == TempIDChar).First().Initiative = Val;
                    return Json(new { msg = "Initiative changed to " + Combat.PCs.Where(pc => pc.TempID == TempIDChar).First().PC.name });
                }
            }
            catch (Exception)
            {
                return Json(new { msg = "Error" });
            }
        }



        [HttpPost]
        public ActionResult AddEffect(String Val, Models.Enum.TypeCharacter Type, int ICharacter,int Duration , long TempID)
        {

            Models.Enum.TypeCondition Name = (Models.Enum.TypeCondition)Convert.ToInt32(Val);
            var Combat = Utils.TemporalDB.Instance.SelectCombat(TempID);

            Combat.Characters[ICharacter].Effects.Add(new Models.Combat.Effect()
            {
                Name = Name,
                Turn = Duration
            });

            return Json(new { msg = "Effect " + Name.ToString() + " was applied"});
        }

        [HttpPost]
        public ActionResult RemoveEffect(int Val, int ICharacter, long TempID)
        {

            Models.Enum.TypeCondition Name = (Models.Enum.TypeCondition)Convert.ToInt32(Val);
            var Combat = Utils.TemporalDB.Instance.SelectCombat(TempID);
            Combat.Characters[ICharacter].Effects.RemoveAt(Val);

            return Json(new { msg = "Effect " + Name.ToString() + " was removed" });
        }


        [HttpPost]
        public ActionResult NextTurn(long TempID)
        {
            var Combat = Utils.TemporalDB.Instance.SelectCombat(TempID);
            Combat.NextTurn();
            return Json(new { msg = "Next Turn" });
        }

        [HttpGet]
        public PartialViewResult SelectTarget(long TempID, int iAction)
        {
            var Combat = Utils.TemporalDB.Instance.SelectCombat(TempID);
            ViewBag.iAction = iAction;
            return PartialView(Combat);
        }

        [HttpGet]
        public PartialViewResult _Characters(long TempID)
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

        #region add pc

        [HttpGet]
        public PartialViewResult _AddPC(long TempID)
        {
            var Combat = Utils.TemporalDB.Instance.SelectCombat(TempID);
            return PartialView(Combat);
        }


        [HttpPost]
        public ActionResult _AddPCCombat(int IdPC, String Username, int TempID)
        {

            var Combat = Utils.TemporalDB.Instance.SelectCombat(TempID);
            Utils.Presets Preset = new Utils.Presets();
            var PC = Preset.initVoidPC();
            PC.id = IdPC;
            PC.Select();
            var User = new Models.User();
            User.UserName = Username;
            User.Read();
            if (Combat.InsertPC(PC, User))
            {
                return Json(new { msg = PC.name + " added" });
            }
            else
            {
                return Json(new { msg = "Not added, "+ User.UserName + " already has a pc associated" });
            }
            

            
        }

        [HttpPost]
        public ActionResult _RemovePCCombat(int TempIDPC, int TempID)
        {

            var Combat = Utils.TemporalDB.Instance.SelectCombat(TempID);
            Combat.RemovePC(TempIDPC);

            return Json(new { msg = "Removed" });
        }


        #endregion


    }
}