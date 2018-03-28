using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dnd_App.Models.Characters;
using Dnd_App.Models.Enum;


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

        [HttpPost]
        public ActionResult Save(long TempID)
        {
            var Pc = Utils.TemporalDB.Instance.SelectPC(TempID);
            var U = Dnd_App.Utils.Session.CurrentSession();


            if (Pc.id == 0)//new npc
            {
                Pc.Create();
                //U.AddNPC(Npc.Id);
            }
            else
            {
                //var newid = Npc.Update();
                //U.AddNPC(newid);
            }
            Utils.TemporalDB.Instance.RemovePC(TempID);

            return Json(new
            {
                message = "Succesful"
            });
        }

        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    Utils.Presets Preset = new Utils.Presets();
        //    var NPC = Preset.initVoidNPC();
        //    NPC.Id = (int)id;
        //    NPC.Select();
        //    Utils.TemporalDB.Instance.InsertNPC(NPC);
        //    return View("New", NPC);
        //}

        //[HttpGet]
        //public ActionResult _ViewFromDB(long id)
        //{
        //    Utils.Presets Preset = new Utils.Presets();
        //    var NPC = Preset.initVoidNPC();
        //    NPC.Id = (int)id;
        //    NPC.Select();
        //    return PartialView("_View", NPC);
        //}


        #region Callbacks --> Basic Info

        [HttpPost]
        public void UpdateName(String newName, int TempID)
        {
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);
            pc.name = newName;
        }



        [HttpPost]
        public void _changeRace(Race race, int TempID)
        {

            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);
            pc.race = race;
            pc.ChangePreset();
        }

        [HttpPost]
        public void _changeBackgroud(Background background, int TempID)
        {

            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);
            pc.background = background;
            pc.ChangePreset();

        }

        [HttpPost]
        public void _changeClass(_Class _class, int TempID)
        {

            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);
            pc._class = _class;
            pc.ChangePreset();

        }

        [HttpPost]
        public void _updateAlignmentMorality(TypeAlignMorality val, int TempID)
        {
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);
            pc.alignmentMorality = val;
        }

        [HttpPost]
        public void _updateAlignmentAttitude(TypeAlignAttitude val, int TempID)
        {
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);
            pc.alignmentAttitude = val;
        }

        [HttpPost]
        public void _updateLevel(int val, int TempID)
        {
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);
            var aux = pc.level.LevelList().Find(con => con.XP == val);

            pc.level.ProficiencyBonus = aux.ProficiencyBonus;
            pc.level.Value = aux.Value;
            pc.level.XP = aux.XP;

            pc.RecalculatePorficiency();
        }

        #endregion

        #region Callbacks --> Armor class

        [HttpPost]
        public void _updateBonusArmor(int bonus, int TempID)
        {
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);
            pc.armorBonus = bonus;

            pc.RecalculateAC();
        }

        #endregion

        #region Callbacks --> HP

        [HttpPost]
        public void _updateHP(int hp, int TempID)
        {
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);
            pc.HP = hp;

            pc.RecalculateHP();
        }

        #endregion

        #region Callbacks --> Speeds

        [HttpPost]
        public PartialViewResult _AddSpeed(List<TypeSpeed> list, int TempID)
        {

            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);
            pc.AddSpeed(list);
            return PartialView(pc.speeds);
        }



        [HttpPost]
        public void _UpdateSpeed(TypeSpeed _type, int _value, int TempID)
        {

            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);
            foreach (var s in pc.speeds.Where(r => r.TypeSpeed == _type))
            {
                s.Speedft = _value;
            }
        }

        #endregion

        #region Callbacks --> Ability scores

        [HttpPost]
        public void RecalculateAS(String _mod, String _value, int TempID)
        {

            int modparse;
            try
            {
                modparse = Convert.ToInt32(_value);
            }
            catch (Exception)
            {
                modparse = 1;
            }

            if (modparse < 1)
            {
                modparse = 1;
            }

            if (modparse > 30)
            {
                modparse = 30;
            }

            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);

            foreach (var item in pc.abilitiesScores)
            {
                if (item.ShortName.Equals(_mod))
                {
                    item.Value = modparse;
                }
            }

            pc.RecalculateAbilityModifier();



        }

        #endregion

        #region Callbacks --> Saving throws

        [HttpPost]
        public void _UpdateSavingThrow(Boolean _check, String _mod, int TempID)
        {
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);

            foreach (var item in pc.abilitiesScores)
            {
                if (item.ShortName.Equals(_mod))
                {
                    item.SavingThrow = _check;
                }
            }

            pc.RecalculateST();
        }

        #endregion

        #region Callbacks --> Skills

        [HttpPost]
        public PartialViewResult _addSkills(List<SkillName> list, int TempID)
        {
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);
            pc.AddSkills(list);
            return PartialView(pc.skills);
        }

        [HttpPost]
        public PartialViewResult _addpresetSkills(List<SkillName> list, int TempID)
        {
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);
            return PartialView(pc.presetSkills);
        }

        //we
        [HttpPost]
        public void _updateSkill(SkillName Name, int value, int TempID)
        {

            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);
            foreach (var s in pc.skills.Where(r => r.SkillName == Name))
            {
                s.Bonus = value;
                pc.RecalculateSkills(pc.skills);
            }
            foreach (var s in pc.presetSkills.Where(r => r.SkillName == Name))
            {
                s.Bonus = value;
                pc.RecalculateSkills(pc.presetSkills);
            }
        }

        #endregion

        #region Callbacks --> Conditions

        [HttpPost]
        public void _addVulnerabilities(List<TypeDamage> list, int TempID)
        {
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);
            pc.AddDamage("vul", list);
        }

        [HttpPost]
        public void _addResistances(List<TypeDamage> list, int TempID)
        {
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);
            pc.AddDamage("res", list);
        }

        [HttpPost]
        public void _addImmunitiesDMG(List<TypeDamage> list, int TempID)
        {
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);
            pc.AddDamage("imm", list);
        }

        [HttpPost]
        public void _addImmunitiesCND(List<TypeCondition> list, int TempID)
        {
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);
            pc.AddCondition(list);


        }

        #endregion

        #region Callbacks --> Senses

        [HttpPost]
        public PartialViewResult _addSenses(List<TypeSense> list, int TempID)
        {

            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);
            pc.AddSense(list);
            return PartialView(pc.senses);
        }

        [HttpPost]
        public void _UpdateSenses(TypeSense _type, int _value, int TempID)
        {
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);

            foreach (var s in pc.senses.Where(r => r.TypeSense == _type))
            {
                s.range = _value;
            }

            pc.RecalculatePerception(pc.presetSenses);
            pc.RecalculatePerception(pc.senses);

        }

        #endregion

        #region Callbacks --> Languages

        [HttpPost]
        public void _addLanguagesSpeak(List<LanguageName> list, int TempID)
        {
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);
            pc.AddLanguagesSpeak(list);

        }

        [HttpPost]
        public void _addLanguagesUnderstand(List<LanguageName> list, int TempID)
        {
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);
            pc.AddLanguagesUnderstand(list);
        }

        #endregion

        #region Callbacks --> Special Traits

        [HttpPost]
        public PartialViewResult _PartialSpecialTraits(int TempID)
        {
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);
            return PartialView(pc.specialTraits);
        }

        [HttpPost]
        public void _addSpecialTrait(int TempID)
        {
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);

            pc.specialTraits.Add(new SpecialTrait() { Name = "new special trait" });

        }

        [HttpPost]
        public void _deleteSpecialTraits(String Name, int TempID)
        {
            if (Name == null)
            {
                Name = "";
            }
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);

            pc.specialTraits.RemoveAll(x => x.Name == Name);
        }

        [HttpPost]
        public void _editTextSpecialTraits(String Name, String text, int TempID)
        {
            if (Name == null)
            {
                Name = "";
            }
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);


            foreach (var a in pc.specialTraits.Where(r => r.Name == Name))
            {
                a.Description = text;
            }



        }

        [HttpPost]
        public void _editNameSpecialTraits(String preName, String Name, int TempID)
        {
            if (Name == null)
            {
                Name = "";
            }
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);


            foreach (var a in pc.specialTraits.Where(r => r.Name == preName))
            {
                a.Name = Name;
            }

        }

        #endregion

        #region Callbacks --> Actions

        [HttpPost]
        public PartialViewResult _PartialAction(int TempID)
        {
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);
            return PartialView(pc.actions);
        }



        [HttpPost]
        public void _addAction(int TempID)
        {
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);
            pc.actions.Add(new Models.Characters.Action() { Name = "new_action", AbilityAction = "Str" });
        }

        [HttpPost]
        public void _deleteAction(String Name, int TempID)
        {
            if (Name == null)
            {
                Name = "";
            }
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);
            pc.actions.RemoveAll(x => x.Name == Name);
        }

        [HttpPost]
        public void _editTextAction(String Name, String text, int TempID)
        {
            if (Name == null)
            {
                Name = "";
            }
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);


            foreach (var a in pc.actions.Where(r => r.Name == Name))
            {
                a.Description = text;
            }

        }

        [HttpPost]
        public void _editNameAction(String preName, String Name, int TempID)
        {
            if (Name == null)
            {
                Name = "";
            }
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);


            foreach (var a in pc.actions.Where(r => r.Name == preName))
            {
                a.Name = Name;
            }

        }


        [HttpPost]
        public void _editLimiteAction(String Name, String value, int TempID)
        {
            if (Name == null)
            {
                Name = "";
            }
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);


            foreach (var a in pc.actions.Where(r => r.Name == Name))
            {
                a.Limited = value;
            }

        }

        //recalcular
        [HttpPost]
        public void _editTypeAction(String Name, int value, int TempID)
        {
            if (Name == null)
            {
                Name = "";
            }
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);

            foreach (var a in pc.actions.Where(r => r.Name == Name))
            {
                a.TypeAction = (TypeAction)value;
            }

            pc.RecalculateAttackAction();
            pc.RecalculateHitAction();
        }

        //recalcular
        [HttpPost]
        public void _editBonusAttckAction(String Name, int value, int TempID)
        {
            if (Name == null)
            {
                Name = "";
            }
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);

            foreach (var a in pc.actions.Where(r => r.Name == Name))
            {
                a.BonusAttack = value;
            }

            pc.RecalculateAttackAction();
        }

        [HttpPost]
        public void _editAbilityAction(String Name, String value, int TempID)
        {
            if (Name == null)
            {
                Name = "";
            }
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);

            foreach (var a in pc.actions.Where(r => r.Name == Name))
            {
                a.AbilityAction = value;
            }

            pc.RecalculateAttackAction();
            pc.RecalculateHitAction();
        }

        [HttpPost]
        public void _editRangeAction(String Name, int value, int TempID)
        {
            if (Name == null)
            {
                Name = "";
            }
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);

            foreach (var a in pc.actions.Where(r => r.Name == Name))
            {
                a.Range = value;
            }

        }

        [HttpPost]
        public void _editMinAction(String Name, int value, int TempID)
        {
            if (Name == null)
            {
                Name = "";
            }
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);


            foreach (var a in pc.actions.Where(r => r.Name == Name))
            {
                a.Min = value;
            }


        }

        [HttpPost]
        public void _editMaxAction(String Name, int value, int TempID)
        {
            if (Name == null)
            {
                Name = "";
            }
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);


            foreach (var a in pc.actions.Where(r => r.Name == Name))
            {
                a.Max = value;
            }

        }

        [HttpPost]
        public void _editTargetAction(String Name, String value, int TempID)
        {
            if (Name == null)
            {
                Name = "";
            }
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);


            foreach (var a in pc.actions.Where(r => r.Name == Name))
            {
                a.Target = value;
            }

        }

        [HttpPost]
        public void _editHitDieAction(String Name, int value, int TempID)
        {
            if (Name == null)
            {
                Name = "";
            }
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);


            foreach (var a in pc.actions.Where(r => r.Name == Name))
            {
                a.HitDie = value;
            }

            pc.RecalculateHitAction();
        }

        //recalcular
        [HttpPost]
        public void _editBonusDamageAction(String Name, int value, int TempID)
        {
            if (Name == null)
            {
                Name = "";
            }
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);


            foreach (var a in pc.actions.Where(r => r.Name == Name))
            {
                a.BonusDamage = value;
            }

            pc.RecalculateHitAction();
        }

        //recalcular
        [HttpPost]
        public void _editDieAction(String Name, int value, int TempID)
        {
            if (Name == null)
            {
                Name = "";
            }
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);


            foreach (var a in pc.actions.Where(r => r.Name == Name))
            {
                a.Die = (TypeDie)value;
            }

            pc.RecalculateHitAction();
        }

        [HttpPost]
        public void _editTypeDamageAction(String Name, int value, int TempID)
        {
            if (Name == null)
            {
                Name = "";
            }
            var pc = Utils.TemporalDB.Instance.SelectPC(TempID);


            foreach (var a in pc.actions.Where(r => r.Name == Name))
            {
                a.TypeDamage = (TypeDamage)value;
            }

        }

        #endregion
    }
}