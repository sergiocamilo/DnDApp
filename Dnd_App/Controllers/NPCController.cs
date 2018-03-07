using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Dnd_App.Controllers
{
    public class NPCController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult _AllNPC()
        {
            return PartialView();
        }


        [HttpGet]
        public ActionResult New()
        {
            Utils.Presets Preset = new Utils.Presets();
            var NPC = Preset.GenerateEmptyNPC();
            Utils.TemporalDB.Instance.InsertNPC(NPC);

            return View(NPC);
        }

        [HttpGet]
        public PartialViewResult _Create(long TempID)
        {
            var Npc = new Models.Characters.NPC();
            Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            return PartialView(Npc);
        }

        [HttpGet]
        public ActionResult _View(long TempID)
        {
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            return PartialView(Npc);
        }



        #region Callbacks --> Basic Info

        [HttpPost]
        public ActionResult _updateName(String newName, long TempID)
        {
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            var LastValue = Npc.Name;
            Npc.Name = newName;

            return Json(new { nameValue = "Name", lastValue = LastValue, newValue = newName });
        }

        [HttpPost]
        public ActionResult _updateSize(Models.Enum.TypeSize type, int TempID)
        {
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            var LastValue = Npc.Size.TypeSize;
            Npc.Size.TypeSize = type;

            return Json(new { nameValue = "Size", lastValue = LastValue.ToString(), newValue = type.ToString() });
        }

        [HttpPost]
        public ActionResult _updateType(Models.Enum.TypeCreature type, int TempID)
        {
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            var LastValue = Npc.TypeCreature;
            Npc.TypeCreature = type;

            return Json(new { nameValue = "Type creature", lastValue = LastValue.ToString(), newValue = type.ToString() });
        }

        [HttpPost]
        public ActionResult _updateAlignmentMorality(Models.Enum.TypeAlignMorality val, int TempID)
        {
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            var LastValue = Npc.AlignmentMorality;
            Npc.AlignmentMorality = val;

            return Json(new { nameValue = "Alignment Morality", lastValue = LastValue.ToString(), newValue = val.ToString() });
        }

        [HttpPost]
        public ActionResult _updateAlignmentAttitude(Models.Enum.TypeAlignAttitude val, int TempID)
        {
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            var LastValue = Npc.AlignmentMorality;
            Npc.AlignmentAttitude = val;

            return Json(new { nameValue = "Alignment Attitude", lastValue = LastValue.ToString(), newValue = val.ToString() });
        }

        [HttpPost]
        public ActionResult _updateTag(String val, int TempID)
        {
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            var LastValue = Npc.Tag;
            Npc.Tag = val;

            return Json(new { nameValue = "Tag", lastValue = LastValue, newValue = val });
        }


        #endregion

        #region Callbacks --> Armor Class

        [HttpPost]
        public ActionResult _RecalculateAC(Boolean _isShield, Models.Enum.ArmorName _nameAC, int TempID)
        {
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);

            var LastValue = Npc.ArmorClass.Name + "" + (Npc.ArmorClass.Shield ? " + shield" : "");

            Npc.ArmorClass.Name = _nameAC;
            Npc.ArmorClass.Shield = _isShield;

            //Npc.RecalculateAC();

            return Json(new
            {
                nameValue = "Armor Class",
                lastValue = LastValue.ToString(),
                newValue = Npc.ArmorClass.Name + "" + (Npc.ArmorClass.Shield ? " + shield" : "")
            });

        }


        #endregion

        #region Callbacks --> Armor Class

        [HttpPost]
        public ActionResult _RecalculateHP(int hd, Models.Enum.TypeDie d, int TempID)
        {

            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);

            Npc.HitPoint.Die = hd;
            Npc.HitPoint.TypeDie = d;

            var LastValue = Npc.HitPoint.HitPointsAVG;
            //npc.RecalculateHP();

            return Json(new
            {
                nameValue = "Hit Points average",
                lastValue = LastValue.ToString(),
                newValue = Npc.HitPoint.HitPointsAVG.ToString()
            });
        }

        #endregion

        #region Callbacks --> Speeds


        [HttpPost]
        public ActionResult _UpdateSpeed(Models.Enum.TypeSpeed _type, int _value, int TempID)
        {
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            int LastValue = 0;

            foreach (var s in Npc.Speeds.Where(r => r.TypeSpeed == _type))
            {
                LastValue = s.Speedft;
                s.Speedft = _value;

            }

            return Json(new
            {
                nameValue = "Speed "+ _type,
                lastValue = LastValue.ToString(),
                newValue = _value
            });

        }

        [HttpPost]
        public PartialViewResult _AddSpeed(List<Models.Enum.TypeSpeed> list, int TempID)
        {

            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            //Npc.AddSpeed(list);


            return PartialView(Npc.Speeds);
        }


        #endregion

        #region Callbacks --> Ability score

        [HttpPost]
        public ActionResult RecalculateAS(String _mod, int _value, int TempID)
        {

            if (_value < 1)
                _value = 1;

            if (_value > 30)
                _value = 30;

            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            var LastValue = Npc.AbilitiesScores.Find(ability => ability.ShortName.Equals(_mod))
                .Value;

            Npc.AbilitiesScores.Find(ability => ability.ShortName.Equals(_mod))
                .Value = _value;

            return Json(new
            {
                nameValue = _mod,
                lastValue = LastValue.ToString(),
                newValue = _value
            });
        }

        #endregion

        #region Callbacks --> Saving throw

        public ActionResult _UpdateSavingThrow(Boolean _check, String _mod, int TempID)
        {
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            var LastValue = Npc.AbilitiesScores.Find(ability => ability.ShortName.Equals(_mod))
                .SavingThrow;
            Npc.AbilitiesScores.Find(ability => ability.ShortName.Equals(_mod))
                .SavingThrow = _check;

            //Npc.RecalculateST();

            return Json(new
            {
                nameValue = "Saving throw :"+ _mod,
                lastValue = LastValue? "on": "off",
                newValue = _check? "on" : "off"
            });
        }



        #endregion

        #region Callbacks --> Skills

        [HttpPost]
        public PartialViewResult _addSkills(List<Models.Enum.SkillName> list, int TempID)
        {

            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            var newListSkills = new List<Models.Characters.Skill>();

            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    newListSkills.Add(new Models.Characters.Skill { SkillName = list[i], Value = 0 });
                }
            }

            Npc.Skills = newListSkills;

            //Npc.RecalculateSkills();

            return PartialView(Npc.Skills);
        }

        [HttpPost]
        public ActionResult _updateSkill(Models.Enum.SkillName name, int value, int TempID)
        {
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            int LastValue = 0;
            foreach (var s in Npc.Skills.Where(r => r.SkillName == name))
            {
                LastValue = s.Bonus;
                s.Bonus = value;
                //Npc.RecalculateSkills();
            }

            return Json(new
            {
                nameValue = "Bonus "+ name.ToString(),
                lastValue = LastValue +"",
                newValue = value + ""
            });
        }

        #endregion



    }
}