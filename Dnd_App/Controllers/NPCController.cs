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
            Npc.AddSpeed(list);


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


        #region Callbacks --> Vul res con

        [HttpPost]
        public void _addVulnerabilities(List<Models.Enum.TypeDamage> list, int TempID)
        {
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            var newListVulnerabilities = new List<Models.Characters.Damage>();

            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    newListVulnerabilities.Add(new Models.Characters.Damage()
                    { TypeDamage = (Models.Enum.TypeDamage)list[i] }
                    );
                }
            }
            Npc.Vulnerabilities = newListVulnerabilities;
        }

        [HttpPost]
        public void _addResistances(List<Models.Enum.TypeDamage> list, int TempID)
        {
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);

            var newListResistances = new List<Models.Characters.Damage>();

            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    newListResistances.Add(new Models.Characters.Damage()
                    { TypeDamage = (Models.Enum.TypeDamage)list[i] }
                    );
                }
            }
            Npc.Resistances = newListResistances;
        }

        [HttpPost]
        public void _addImmunitiesDMG(List<Models.Enum.TypeDamage> list, int TempID)
        {
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);

            var newListImmunitiesDMG = new List<Models.Characters.Damage>();

            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    newListImmunitiesDMG.Add(new Models.Characters.Damage()
                    { TypeDamage = (Models.Enum.TypeDamage)list[i] }
                    );
                }
            }
            Npc.ImmunitiesDamage = newListImmunitiesDMG;
        }

        [HttpPost]
        public void _addImmunitiesCND(List<Models.Enum.TypeCondition> list, int TempID)
        {
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);

            var newListImmunitiesCND = new List<Models.Characters.Condition>();

            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    newListImmunitiesCND.Add(new Models.Characters.Condition()
                    { TypeCondition = (Models.Enum.TypeCondition)list[i] });
                }
            }
            Npc.ImmunitiesCondition = newListImmunitiesCND;
        }


        #endregion

        #region Callbacks --> Senses

        [HttpPost]
        public PartialViewResult _addSenses(List<Models.Enum.TypeSense> list, int TempID)
        {

            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            Npc.AddSenses(list);
            
            //Npc.RecalculatePerception();


            return PartialView(Npc.Senses);
        }


        [HttpPost]
        public ActionResult _UpdateSenses(Models.Enum.TypeSense _type, int _value, int TempID)
        {
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            int LastValue = 0;

            foreach (var s in Npc.Senses.Where(r => r.TypeSense == _type))
            {
                LastValue = s.range;
                s.range = _value;
            }

            //Npc.RecalculatePerception();

            return Json(new
            {
                nameValue = _type.ToString(),
                lastValue = LastValue + "",
                newValue = _value + ""
            });

        }



        #endregion

        #region Callbacks --> Languages

        [HttpPost]
        public void _addLanguagesSpeak(List<Models.Enum.LanguageName> list, int TempID)
        {
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            var newLanguagesSpeak = new List<Models.Characters.Language>();

            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    newLanguagesSpeak.Add(new Models.Characters.Language()
                    { LanguageName = (Models.Enum.LanguageName)list[i] });
                }
            }
            Npc.LanguagesSpeak = newLanguagesSpeak;
        }

        [HttpPost]
        public void _addLanguagesUnderstand(List<Models.Enum.LanguageName> list, int TempID)
        {
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            var newLanguagesUnderstand = new List<Models.Characters.Language>();

            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    newLanguagesUnderstand.Add(new Models.Characters.Language()
                    { LanguageName = (Models.Enum.LanguageName)list[i] });
                }
            }
            Npc.LanguagesUndersatand = newLanguagesUnderstand;
        }

        [HttpPost]
        public ActionResult _updateTelepathy(int val, int TempID)
        {
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            var LastValue = Npc.Telepathy;
            Npc.Telepathy = val;


            return Json(new
            {
                nameValue = "Telepathy ",
                lastValue = LastValue + "",
                newValue = val + ""
            });
        }

        #endregion


        #region Callbacks --> Challenge

        [HttpPost]
        public ActionResult _updateChallenge(int val, int TempID)
        {
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            var aux = Npc.Challenge.ChallengeList().Find(con => con.XP == val);

            var LastValue = Npc.Challenge.Value;

            Npc.Challenge.ProficiencyBonus = aux.ProficiencyBonus;
            Npc.Challenge.Value = aux.Value;
            Npc.Challenge.XP = aux.XP;

            //Npc.RecalculatePorficiency();

            return Json(new
            {
                nameValue = "Challenge rating ",
                lastValue = LastValue + "",
                newValue = aux.Value + ""
            });

        }


        #endregion

        #region Callbacks --> Special Traits


        [HttpPost]
        public PartialViewResult _PartialSpecialTraits(int TempID)
        {
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            return PartialView(Npc.SpecialTraits);
        }

        [HttpPost]
        public void _addSpecialTrait(int TempID)
        {
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            Npc.SpecialTraits.Add(new Models.Characters.SpecialTrait() { Name = "new special trait" });

        }

        [HttpPost]
        public void _deleteSpecialTraits(String name, int TempID)
        {
            if (name == null)
            {
                name = "";
            }
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);

            Npc.SpecialTraits.RemoveAll(x => x.Name == name);
        }

        [HttpPost]
        public ActionResult _editTextSpecialTraits(String name, String text, int TempID)
        {
            if (name == null)
            {
                name = "";
            }
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            string LastValue = "";
            foreach (var a in Npc.SpecialTraits.Where(r => r.Name == name))
            {
                LastValue = a.Description;
                a.Description = text;
            }

            return Json(new
            {
                nameValue = "Special trait " + name,
                lastValue = LastValue + "",
                newValue = text + ""
            });
        }

        [HttpPost]
        public ActionResult _editNameSpecialTraits(String preName, String name, int TempID)
        {
            if (name == null)
            {
                name = "";
            }
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);


            foreach (var a in Npc.SpecialTraits.Where(r => r.Name == preName))
            {
                a.Name = name;
            }

            return Json(new
            {
                nameValue = "Special trait " + name,
                lastValue = preName + "",
                newValue = name + ""
            });
        }

        #endregion

        #region Callbacks --> Actions

        [HttpPost]
        public PartialViewResult _PartialAction(int TempID)
        {
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            return PartialView(Npc.Actions);
        }
        [HttpPost]
        public PartialViewResult _PartialReaction(int TempID)
        {
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            return PartialView(Npc.Reactions);
        }

        [HttpPost]
        public PartialViewResult _PartialLegendaryAction(int TempID)
        {
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            return PartialView(Npc.LegendaryActions);
        }

        [HttpPost]
        public void _addAction(int type, int TempID)
        {
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            switch (type)
            {
                case 1:
                    Npc.Actions.Add(new Models.Characters.Action() { Name = "new_action", AbilityAction = "Str" });
                    break;
                case 2:
                    Npc.Reactions.Add(new Models.Characters.Action() { Name = "new reaction" });
                    break;
                case 3:
                    Npc.LegendaryActions.Add(new Models.Characters.Action() { Name = "new legendary action" });
                    break;
                default:
                    break;
            }
        }

        [HttpPost]
        public void _deleteAction(int type, String name, int TempID)
        {
            if (name == null)
            {
                name = "";
            }
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            switch (type)
            {
                case 1:
                    Npc.Actions.RemoveAll(x => x.Name == name);
                    break;
                case 2:
                    Npc.Reactions.RemoveAll(x => x.Name == name);
                    break;
                case 3:
                    Npc.LegendaryActions.RemoveAll(x => x.Name == name);
                    break;
                default:
                    break;
            }

        }

        [HttpPost]
        public ActionResult _editTextAction(int type, String name, String text, int TempID)
        {
            if (name == null)
            {
                name = "";
            }
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            string LastValue = "";

            switch (type)
            {
                case 1:
                    foreach (var a in Npc.Actions.Where(r => r.Name == name))
                    {
                        LastValue = a.Description;
                        a.Description = text;
                    }
                    break;
                case 2:
                    foreach (var a in Npc.Reactions.Where(r => r.Name == name))
                    {
                        LastValue = a.Description;
                        a.Description = text;
                    }
                    break;
                case 3:
                    foreach (var a in Npc.LegendaryActions.Where(r => r.Name == name))
                    {
                        LastValue = a.Description;
                        a.Description = text;
                    }
                    break;
                default:
                    break;
            }

            return Json(new
            {
                nameValue = "Action description " + name,
                lastValue = LastValue + "",
                newValue = text + ""
            });
        }

        [HttpPost]
        public ActionResult _editNameAction(int type, String preName, String name, int TempID)
        {
            if (name == null)
            {
                name = "";
            }
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);

            switch (type)
            {
                case 1:
                    foreach (var a in Npc.Actions.Where(r => r.Name == preName))
                    {
                        a.Name = name;
                    }
                    break;
                case 2:
                    foreach (var a in Npc.Reactions.Where(r => r.Name == preName))
                    {
                        a.Name = name;
                    }
                    break;
                case 3:
                    foreach (var a in Npc.LegendaryActions.Where(r => r.Name == preName))
                    {
                        a.Name = name;
                    }
                    break;
                default:
                    break;
            }

            return Json(new
            {
                nameValue = "Action name " + name,
                lastValue = preName + "",
                newValue = name + ""
            });
        }

        [HttpPost]
        public ActionResult _editLimiteAction(int type, String name, String value, int TempID)
        {
            if (name == null)
            {
                name = "";
            }
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            string LastValue = "";

            switch (type)
            {
                case 1:
                    foreach (var a in Npc.Actions.Where(r => r.Name == name))
                    {
                        LastValue = a.Limited;
                        a.Limited = value;
                    }
                    break;
                case 2:
                    foreach (var a in Npc.Reactions.Where(r => r.Name == name))
                    {
                        LastValue = a.Limited;
                        a.Limited = value;
                    }
                    break;
                case 3:
                    foreach (var a in Npc.LegendaryActions.Where(r => r.Name == name))
                    {
                        LastValue = a.Limited;
                        a.Limited = value;
                    }
                    break;
                default:
                    break;
            }

            return Json(new
            {
                nameValue = "Action description " + name,
                lastValue = LastValue + "",
                newValue = value + ""
            });
        }

        //recalcular
        [HttpPost]
        public ActionResult _editTypeAction(int type, String name, int value, int TempID)
        {
            if (name == null)
            {
                name = "";
            }
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            string LastValue = "";

            switch (type)
            {
                case 1:
                    foreach (var a in Npc.Actions.Where(r => r.Name == name))
                    {
                        LastValue = a.TypeAction.ToString();
                        a.TypeAction = (Models.Enum.TypeAction)value;
                    }
                    break;
                case 2:
                    foreach (var a in Npc.Reactions.Where(r => r.Name == name))
                    {
                        LastValue = a.TypeAction.ToString();
                        a.TypeAction = (Models.Enum.TypeAction)value;
                    }
                    break;
                case 3:
                    foreach (var a in Npc.LegendaryActions.Where(r => r.Name == name))
                    {
                        LastValue = a.TypeAction.ToString();
                        a.TypeAction = (Models.Enum.TypeAction)value;
                    }
                    break;
                default:
                    break;
            }
            //npc.RecalculateAttackAction();
            //npc.RecalculateHitAction();

            return Json(new
            {
                nameValue = "Action type " + name,
                lastValue = LastValue + "",
                newValue = value + ""
            });
        }

        //recalcular
        [HttpPost]
        public ActionResult _editBonusAttckAction(int type, String name, int value, int TempID)
        {
            if (name == null)
            {
                name = "";
            }
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            string LastValue = "";

            switch (type)
            {
                case 1:
                    foreach (var a in Npc.Actions.Where(r => r.Name == name))
                    {
                        LastValue = a.BonusAttack.ToString();
                        a.BonusAttack = value;
                    }
                    break;
                case 2:
                    foreach (var a in Npc.Reactions.Where(r => r.Name == name))
                    {
                        LastValue = a.BonusAttack.ToString();
                        a.BonusAttack = value;
                    }
                    break;
                case 3:
                    foreach (var a in Npc.LegendaryActions.Where(r => r.Name == name))
                    {
                        LastValue = a.BonusAttack.ToString();
                        a.BonusAttack = value;
                    }
                    break;
                default:
                    break;
            }
            //Npc.RecalculateAttackAction();
            return Json(new
            {
                nameValue = "Action bonus " + name,
                lastValue = LastValue + "",
                newValue = value + ""
            });
        }

        [HttpPost]
        public ActionResult _editAbilityAction(int type, String name, String value, int TempID)
        {
            if (name == null)
            {
                name = "";
            }
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            string LastValue = "";

            switch (type)
            {
                case 1:
                    foreach (var a in Npc.Actions.Where(r => r.Name == name))
                    {
                        LastValue = a.AbilityAction;
                        a.AbilityAction = value;
                    }
                    break;
                case 2:
                    foreach (var a in Npc.Reactions.Where(r => r.Name == name))
                    {
                        LastValue = a.AbilityAction;
                        a.AbilityAction = value;
                    }
                    break;
                case 3:
                    foreach (var a in Npc.LegendaryActions.Where(r => r.Name == name))
                    {
                        LastValue = a.AbilityAction;
                        a.AbilityAction = value;
                    }
                    break;
                default:
                    break;
            }
            //npc.RecalculateAttackAction();
            //npc.RecalculateHitAction();
            return Json(new
            {
                nameValue = "Action ability action " + name,
                lastValue = LastValue + "",
                newValue = value + ""
            });
        }

        [HttpPost]
        public ActionResult _editRangeAction(int type, String name, int value, int TempID)
        {
            if (name == null)
            {
                name = "";
            }
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            string LastValue = "";

            switch (type)
            {
                case 1:
                    foreach (var a in Npc.Actions.Where(r => r.Name == name))
                    {
                        LastValue = a.Range.ToString();
                        a.Range = value;
                    }
                    break;
                case 2:
                    foreach (var a in Npc.Reactions.Where(r => r.Name == name))
                    {
                        LastValue = a.Range.ToString();
                        a.Range = value;
                    }
                    break;
                case 3:
                    foreach (var a in Npc.LegendaryActions.Where(r => r.Name == name))
                    {
                        LastValue = a.Range.ToString();
                        a.Range = value;
                    }
                    break;
                default:
                    break;
            }
            return Json(new
            {
                nameValue = "Action range " + name,
                lastValue = LastValue + "",
                newValue = value + ""
            });
        }

        [HttpPost]
        public ActionResult _editMinAction(int type, String name, int value, int TempID)
        {
            if (name == null)
            {
                name = "";
            }
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            string LastValue = "";

            switch (type)
            {
                case 1:
                    foreach (var a in Npc.Actions.Where(r => r.Name == name))
                    {
                        LastValue = a.Min.ToString();
                        a.Min = value;
                    }
                    break;
                case 2:
                    foreach (var a in Npc.Reactions.Where(r => r.Name == name))
                    {
                        LastValue = a.Min.ToString();
                        a.Min = value;
                    }
                    break;
                case 3:
                    foreach (var a in Npc.LegendaryActions.Where(r => r.Name == name))
                    {
                        LastValue = a.Min.ToString();
                        a.Min = value;
                    }
                    break;
                default:
                    break;
            }
            return Json(new
            {
                nameValue = "Action min " + name,
                lastValue = LastValue + "",
                newValue = value + ""
            });
        }

        [HttpPost]
        public ActionResult _editMaxAction(int type, String name, int value, int TempID)
        {
            if (name == null)
            {
                name = "";
            }
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            string LastValue = "";

            switch (type)
            {
                case 1:
                    foreach (var a in Npc.Actions.Where(r => r.Name == name))
                    {
                        LastValue = a.Max.ToString();
                        a.Max = value;
                    }
                    break;
                case 2:
                    foreach (var a in Npc.Reactions.Where(r => r.Name == name))
                    {
                        LastValue = a.Max.ToString();
                        a.Max = value;
                    }
                    break;
                case 3:
                    foreach (var a in Npc.LegendaryActions.Where(r => r.Name == name))
                    {
                        LastValue = a.Max.ToString();
                        a.Max = value;
                    }
                    break;
                default:
                    break;
            }

            return Json(new
            {
                nameValue = "Action max " + name,
                lastValue = LastValue + "",
                newValue = value + ""
            });
        }

        [HttpPost]
        public ActionResult _editTargetAction(int type, String name, String value, int TempID)
        {
            if (name == null)
            {
                name = "";
            }
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            string LastValue = "";

            switch (type)
            {
                case 1:
                    foreach (var a in Npc.Actions.Where(r => r.Name == name))
                    {
                        LastValue = a.Target;
                        a.Target = value;
                    }
                    break;
                case 2:
                    foreach (var a in Npc.Reactions.Where(r => r.Name == name))
                    {
                        LastValue = a.Target;
                        a.Target = value;
                    }
                    break;
                case 3:
                    foreach (var a in Npc.LegendaryActions.Where(r => r.Name == name))
                    {
                        LastValue = a.Target;
                        a.Target = value;
                    }
                    break;
                default:
                    break;
            }

            return Json(new
            {
                nameValue = "Action target " + name,
                lastValue = LastValue + "",
                newValue = value + ""
            });
        }

        [HttpPost]
        public ActionResult _editHitDieAction(int type, String name, int value, int TempID)
        {
            if (name == null)
            {
                name = "";
            }
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            string LastValue = "";

            switch (type)
            {
                case 1:
                    foreach (var a in Npc.Actions.Where(r => r.Name == name))
                    {
                        LastValue = a.HitDie.ToString();
                        a.HitDie = value;
                    }
                    break;
                case 2:
                    foreach (var a in Npc.Reactions.Where(r => r.Name == name))
                    {
                        LastValue = a.HitDie.ToString();
                        a.HitDie = value;
                    }
                    break;
                case 3:
                    foreach (var a in Npc.LegendaryActions.Where(r => r.Name == name))
                    {
                        LastValue = a.HitDie.ToString();
                        a.HitDie = value;
                    }
                    break;
                default:
                    break;
            }
            //npc.RecalculateHitAction();

            return Json(new
            {
                nameValue = "Action hit die " + name,
                lastValue = LastValue + "",
                newValue = value + ""
            });
        }


        [HttpPost]
        public ActionResult _editBonusDamageAction(int type, String name, int value, int TempID)
        {
            if (name == null)
            {
                name = "";
            }
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            string LastValue = "";

            switch (type)
            {
                case 1:
                    foreach (var a in Npc.Actions.Where(r => r.Name == name))
                    {
                        LastValue = a.BonusDamage.ToString();
                        a.BonusDamage = value;
                    }
                    break;
                case 2:
                    foreach (var a in Npc.Reactions.Where(r => r.Name == name))
                    {
                        LastValue = a.BonusDamage.ToString();
                        a.BonusDamage = value;
                    }
                    break;
                case 3:
                    foreach (var a in Npc.LegendaryActions.Where(r => r.Name == name))
                    {
                        LastValue = a.BonusDamage.ToString();
                        a.BonusDamage = value;
                    }
                    break;
                default:
                    break;
            }
            //npc.RecalculateHitAction();

            return Json(new
            {
                nameValue = "Action hit die " + name,
                lastValue = LastValue + "",
                newValue = value + ""
            });
        }

        [HttpPost]
        public ActionResult _editDieAction(int type, String name, int value, int TempID)
        {
            if (name == null)
            {
                name = "";
            }
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            string LastValue = "";

            switch (type)
            {
                case 1:
                    foreach (var a in Npc.Actions.Where(r => r.Name == name))
                    {
                        LastValue = a.Die.ToString();
                        a.Die = (Models.Enum.TypeDie)value;
                    }
                    break;
                case 2:
                    foreach (var a in Npc.Reactions.Where(r => r.Name == name))
                    {
                        LastValue = a.Die.ToString();
                        a.Die = (Models.Enum.TypeDie)value;
                    }
                    break;
                case 3:
                    foreach (var a in Npc.LegendaryActions.Where(r => r.Name == name))
                    {
                        LastValue = a.Die.ToString();
                        a.Die = (Models.Enum.TypeDie)value;
                    }
                    break;
                default:
                    break;
            }
            //npc.RecalculateHitAction();

            return Json(new
            {
                nameValue = "Action hit die " + name,
                lastValue = LastValue + "",
                newValue = value + ""
            });
        }

        [HttpPost]
        public ActionResult _editTypeDamageAction(int type, String name, int value, int TempID)
        {
            if (name == null)
            {
                name = "";
            }
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            string LastValue = "";

            switch (type)
            {
                case 1:
                    foreach (var a in Npc.Actions.Where(r => r.Name == name))
                    {
                        LastValue = a.TypeDamage.ToString();
                        a.TypeDamage = (Models.Enum.TypeDamage)value;
                    }
                    break;
                case 2:
                    foreach (var a in Npc.Reactions.Where(r => r.Name == name))
                    {
                        LastValue = a.TypeDamage.ToString();
                        a.TypeDamage = (Models.Enum.TypeDamage)value;
                    }
                    break;
                case 3:
                    foreach (var a in Npc.LegendaryActions.Where(r => r.Name == name))
                    {
                        LastValue = a.TypeDamage.ToString();
                        a.TypeDamage = (Models.Enum.TypeDamage)value;
                    }
                    break;
                default:
                    break;
            }
            return Json(new
            {
                nameValue = "Action damage type " + name,
                lastValue = LastValue + "",
                newValue = value + ""
            });
        }

        #endregion


    }
}