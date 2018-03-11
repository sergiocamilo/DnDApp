using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Dnd_App.Models.Enum;

namespace Dnd_App.Models.Characters
{
    [Table("PC")]
    public class PC : ICloneable
    {
        [Key]
        public int id { set; get; }
        public int TempID { set; get; }

        //Basic Info
        public String name { set; get; }
        public Size size { set; get; }
        public TypeAlignMorality alignmentMorality { set; get; }
        public TypeAlignAttitude alignmentAttitude { set; get; }
        public Race race { set; get; }
        public _Class _class { set; get; }
        public Background background { set; get; }
        public Challenge level { set; get; }

        public Armor armorClass { set; get; }
        public int armorBonus { set; get; }
        public HitPoint hitPoint { set; get; }
        public int HP { set; get; }

        public List<Speed> speeds { set; get; }
        public List<Speed> presetSpeeds { set; get; }

        public List<AbilityScore> abilitiesScores { set; get; }

        public List<SavingThrow> savingThrows { set; get; }
        public List<SavingThrow> presetSavingThrows { set; get; }

        public List<Skill> skills { set; get; }
        public List<Skill> presetSkills { set; get; }

        public List<Damage> vulnerabilities { set; get; }
        public List<Damage> presetVulnerabilities { set; get; }

        public List<Damage> resistances { set; get; }
        public List<Damage> presetResistances { set; get; }

        public List<Damage> immunitiesDamage { set; get; }
        public List<Damage> presetImmunitiesDamage { set; get; }

        public List<Condition> immunitiesCondition { set; get; }
        public List<Condition> presetImmunitiesCondition { set; get; }



        public List<Language> languagesSpeak { set; get; }
        public List<Language> presetLanguagesSpeak { set; get; }

        public List<Language> languagesUndersatand { set; get; }
        public List<Language> presetLanguagesUndersatand { set; get; }

        public int telepathy { set; get; }

        public List<Sense> senses { set; get; }
        public List<Sense> presetSenses { set; get; }

        public List<SpecialTrait> specialTraits { set; get; }
        public List<SpecialTrait> presetSpecialTraits { set; get; }

        public List<Action> actions { set; get; }
        public List<Action> presetActions { set; get; }





        

        public void ChangePreset()
        {
            this.languagesSpeak.AddRange(this.presetLanguagesSpeak);
            this.skills.AddRange(presetSkills);
            this.senses.AddRange(presetSenses);
            this.immunitiesCondition.AddRange(presetImmunitiesCondition);
            this.vulnerabilities.AddRange(presetVulnerabilities);
            this.resistances.AddRange(presetResistances);
            this.immunitiesDamage.AddRange(presetImmunitiesDamage);


            this.presetSpecialTraits = new List<SpecialTrait>();
            this.presetActions = new List<Action>();

            var Preset = new Utils.Presets();
            Preset.LoadClass(this, this._class, 1);
            Preset.LoadRace(this, this.race);
            Preset.LoadBackground(this, this.background);

            languagesSpeak = this.languagesSpeak.Except(this.presetLanguagesSpeak, new Language()).ToList();
            skills = this.skills.Except(this.presetSkills, new Skill()).ToList();
            senses = this.senses.Except(this.presetSenses, new Sense()).ToList();
            immunitiesCondition = this.immunitiesCondition.Except(this.presetImmunitiesCondition, new Condition()).ToList();
            vulnerabilities = this.vulnerabilities.Except(this.presetVulnerabilities, new Damage()).ToList();
            resistances = this.resistances.Except(this.presetResistances, new Damage()).ToList();
            immunitiesDamage = this.immunitiesDamage.Except(this.presetImmunitiesDamage, new Damage()).ToList();

            RecalculateAbilityModifier();

        }

        public void AddLanguagesSpeak(List<LanguageName> list)
        {
            var newLanguagesSpeak = new List<Language>();

            if (list == null)
                list = new List<LanguageName>();

            for (int i = 0; i < list.Count; i++)
            {
                if (!this.presetLanguagesSpeak.Any(m => m.LanguageName == list[i]))
                {
                    newLanguagesSpeak.Add(new Language() { LanguageName = list[i] });
                }
            }
            this.languagesSpeak = newLanguagesSpeak;
        }

        public void AddLanguagesUnderstand(List<LanguageName> list)
        {
            var newLanguagesUnderstand = new List<Language>();

            if (list == null)
                list = new List<LanguageName>();

            for (int i = 0; i < list.Count; i++)
            {
                if (!this.presetLanguagesUndersatand.Any(m => m.LanguageName == list[i]))
                {
                    newLanguagesUnderstand.Add(new Language() { LanguageName = list[i] });
                }
            }
            languagesUndersatand = newLanguagesUnderstand;


        }

        public void AddSpeed(List<TypeSpeed> list)
        {
            var newListSpeeds = new List<Speed>();

            if (list == null)
                list = new List<TypeSpeed>();

            for (int i = 0; i < list.Count; i++)
            {
                newListSpeeds.Add(new Speed { TypeSpeed = list[i], Speedft = 0 });
            }

            if (list.Count <= speeds.Count)
            {
                speeds = speeds.Intersect(newListSpeeds, new Speed()).ToList();
            }
            else
            {
                newListSpeeds = newListSpeeds.Except(speeds, new Speed()).ToList();
                speeds.AddRange(newListSpeeds);
            }

        }

        public void AddSense(List<TypeSense> list)
        {
            var newListSenses = new List<Sense>();

            if (list == null)
                list = new List<TypeSense>();


            for (int i = 0; i < list.Count; i++)
            {
                newListSenses.Add(new Sense { TypeSense = list[i], range = 0 });
            }

            if (list.Count <= senses.Count)
            {
                senses = senses.Intersect(newListSenses, new Sense()).ToList();
            }
            else
            {
                newListSenses = newListSenses.Except(senses, new Sense()).ToList();
                senses.AddRange(newListSenses);
            }

            RecalculatePerception(this.senses);
            RecalculatePerception(this.presetSenses);

        }

        public void AddSkills(List<SkillName> list)
        {
            var newSkills = new List<Skill>();

            if (list == null)
                list = new List<SkillName>();

            for (int i = 0; i < list.Count; i++)
            {
                if (!this.presetSkills.Any(m => m.SkillName == list[i]))
                {
                    newSkills.Add(new Skill() { SkillName = list[i] });
                }
            }
            this.skills = newSkills;
            RecalculateSkills(this.skills);
            RecalculateSkills(this.presetSkills);
        }

        public void RecalculateAC()
        {
            this.armorClass.Bonus = this.abilitiesScores.Find(con => con.ShortName == "Dex").ModValue;

            armorClass.RecalculateBase();

            if (armorClass.Name == ArmorName.Hide || armorClass.Name == ArmorName.ChainShirt || armorClass.Name == ArmorName.ScaleMail ||
                armorClass.Name == ArmorName.Breastplate || armorClass.Name == ArmorName.HalfPlate)
            {
                if (armorClass.Bonus > 2)
                {
                    armorClass.Bonus = 2;
                }
            }

            armorClass.Total = armorClass.BaseArmor + armorClass.Bonus + armorBonus;
            if (armorClass.Shield)
            {
                armorClass.Total += 2;
            }

        }

        public void RecalculateAbilityModifier()
        {
            foreach (var item in this.abilitiesScores)
            {
                double aux = (item.Value + item.Bonus - 10.0) / 2.0;
                item.ModValue = (int)Math.Floor(aux);
            }

            RecalculateHP();
            RecalculateAC();
            RecalculateSkills(this.skills);
            RecalculateSkills(this.presetSkills);
            RecalculateST();
            RecalculatePerception(this.senses);
            RecalculatePerception(this.presetSenses);
            RecalculateHitAction();
            RecalculateAttackAction();
        }

        public void RecalculateST()
        {

            var stnew = new List<SavingThrow>();
            foreach (var item in abilitiesScores)
            {
                if (item.SavingThrow)
                {
                    stnew.Add(new SavingThrow()
                    {
                        ModName = item.ShortName,
                        Value = item.ModValue + this.level.ProficiencyBonus
                    });
                }

            }
            this.savingThrows = stnew;

            savingThrows = this.savingThrows.Except(this.presetSavingThrows, new SavingThrow()).ToList();
            presetSavingThrows = stnew.Except(this.savingThrows, new SavingThrow()).ToList();

        }

        public void RecalculateSkills(List<Skill> list)
        {
            foreach (var item in list)
            {
                if (item.SkillName == SkillName.Athletics)
                {
                    item.Total = this.level.ProficiencyBonus + this.abilitiesScores.Find(con => con.ShortName == "Str").ModValue + item.Bonus;
                }
                else if (item.SkillName == SkillName.Acrobatics || item.SkillName == SkillName.SleightofHand || item.SkillName == SkillName.Stealth)
                {
                    item.Total = this.level.ProficiencyBonus + this.abilitiesScores.Find(con => con.ShortName == "Dex").ModValue + item.Bonus;
                }
                else if (item.SkillName == SkillName.Arcana || item.SkillName == SkillName.History || item.SkillName == SkillName.Investigation
                    || item.SkillName == SkillName.Nature || item.SkillName == SkillName.Religion)
                {
                    item.Total = this.level.ProficiencyBonus + this.abilitiesScores.Find(con => con.ShortName == "Int").ModValue + item.Bonus;
                }
                else if (item.SkillName == SkillName.AnimalHandling || item.SkillName == SkillName.Insight || item.SkillName == SkillName.Medicine
                    || item.SkillName == SkillName.Perception || item.SkillName == SkillName.Survival)
                {
                    item.Total = this.level.ProficiencyBonus + this.abilitiesScores.Find(con => con.ShortName == "Wis").ModValue + item.Bonus;
                }
                else
                {
                    item.Total = this.level.ProficiencyBonus + this.abilitiesScores.Find(con => con.ShortName == "Cha").ModValue + item.Bonus;
                }
            }
        }

        public void RecalculatePerception(List<Sense> senses)
        {

            foreach (var item in senses)
            {
                if (item.TypeSense == TypeSense.passivePerception)
                {
                    item.range = 10 + this.abilitiesScores.Find(con => con.ShortName == "Wis").ModValue + this.level.ProficiencyBonus;
                }
            }

        }

        public void RecalculatePorficiency()
        {
            RecalculatePerception(this.presetSenses);
            RecalculatePerception(this.senses);
            RecalculateAttackAction();
            RecalculateST();
            RecalculateSkills(this.skills);
            RecalculateSkills(this.presetSkills);
        }

        public void RecalculateHitAction()
        {
            foreach (var item in this.actions)
            {

                if (item.TypeAction == TypeAction.MeleeAttack || item.TypeAction == TypeAction.MeleeWeaponAttack)
                {
                    item.AbilityDamage = this.abilitiesScores.Find(con => con.ShortName == "Str").ModValue;
                    var aux = new TypeHitDie().GetValueDie(item.Die);
                    item.Damage = item.HitDie * (int)Math.Floor(aux) + item.BonusDamage + item.AbilityDamage;
                }
                else if (item.TypeAction == TypeAction.RangeAttack || item.TypeAction == TypeAction.RangeWeaponAttack)
                {
                    item.AbilityDamage = this.abilitiesScores.Find(con => con.ShortName == "Dex").ModValue;

                    var aux = new TypeHitDie().GetValueDie(item.Die);
                    item.Damage = item.HitDie * (int)Math.Floor(aux) + item.BonusDamage + item.AbilityDamage;
                }
                else
                {
                    item.AbilityDamage = this.abilitiesScores.Find(con => con.ShortName == item.AbilityAction).ModValue;

                    var aux = new TypeHitDie().GetValueDie(item.Die);
                    item.Damage = item.HitDie * (int)Math.Floor(aux) + item.BonusDamage + item.AbilityDamage;
                }


            }
        }

        public void RecalculateAttackAction()
        {
            foreach (var item in this.actions)
            {
                if (item.TypeAction == TypeAction.MeleeAttack || item.TypeAction == TypeAction.MeleeAttack)
                {
                    item.TotalBonusAttack = this.level.ProficiencyBonus +
                        this.abilitiesScores.Find(con => con.ShortName == "Str").ModValue +
                        item.BonusAttack;
                }
                else
                {
                    item.TotalBonusAttack = this.level.ProficiencyBonus +
                        this.abilitiesScores.Find(con => con.ShortName == "Dex").ModValue +
                        item.BonusAttack;
                }
            }
        }

        public void RecalculateHP()
        {
            //this.hitPoint.bonusCon = this.abilitiesScores.Find(con => con.shortName == "Con").modValue;
            var type = new TypeHitDie().GetValueDie(this.hitPoint.TypeDie);
            var dieTypedie = Convert.ToDouble(hitPoint.Die) * type;
            //this.bonusMultiplied = bonusCon * die;
            this.hitPoint.HitPointsAVG = ((int)dieTypedie) + HP;
            //this.hitPointsAVG = ((int)dieTypedie) + bonusMultiplied;
        }

        public void AddDamage(String damage, List<TypeDamage> list)
        {
            var newlist = new List<Damage>();

            if (list == null)
                list = new List<TypeDamage>();

            switch (damage)
            {
                case "vul":
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (!this.presetVulnerabilities.Any(m => m.TypeDamage == list[i]))
                        {
                            newlist.Add(new Damage() { TypeDamage = list[i] });
                        }
                    }
                    this.vulnerabilities = newlist;
                    break;
                case "imm":
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (!this.presetImmunitiesDamage.Any(m => m.TypeDamage == list[i]))
                        {
                            newlist.Add(new Damage() { TypeDamage = list[i] });
                        }
                    }
                    this.immunitiesDamage = newlist;
                    break;
                case "res":
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (!this.presetResistances.Any(m => m.TypeDamage == list[i]))
                        {
                            newlist.Add(new Damage() { TypeDamage = list[i] });
                        }
                    }
                    this.resistances = newlist;
                    break;
            }
        }

        public void AddCondition(List<TypeCondition> list)
        {
            var newlist = new List<Condition>();

            if (list == null)
                list = new List<TypeCondition>();


            for (int i = 0; i < list.Count; i++)
            {
                if (!this.presetImmunitiesCondition.Any(m => m.TypeCondition == list[i]))
                {
                    newlist.Add(new Condition() { TypeCondition = list[i] });
                }
            }
            this.immunitiesCondition = newlist;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}