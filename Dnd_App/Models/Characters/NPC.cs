using Dnd_App.Entitites;
using Dnd_App.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dnd_App.Models.Characters
{

    public class NPC
    {
        [Key]
        public int Id { set; get; }
        public long TempID { set; get; }

        public String Name { set; get; }
        public Size Size { set; get; }
        public TypeCreature TypeCreature { set; get; }
        public String Tag { set; get; }
        public TypeAlignMorality AlignmentMorality { set; get; }
        public TypeAlignAttitude AlignmentAttitude { set; get; }

        public Armor ArmorClass { set; get; }
        public HitPoint HitPoint { set; get; }
        public List<Speed> Speeds { set; get; }

        public List<AbilityScore> AbilitiesScores { set; get; }

        public List<SavingThrow> SavingThrows { set; get; }
        public List<Skill> Skills { set; get; }

        public List<Damage> Vulnerabilities { set; get; }
        public List<Damage> Resistances { set; get; }
        public List<Damage> ImmunitiesDamage { set; get; }

        public List<Condition> ImmunitiesCondition { set; get; }

        public List<Sense> Senses { set; get; }

        public List<Language> LanguagesSpeak { set; get; }
        public List<Language> LanguagesUndersatand { set; get; }
        public int Telepathy { set; get; }

        public Challenge Challenge { set; get; }

        public List<SpecialTrait> SpecialTraits { set; get; }

        public List<Action> Actions { set; get; }

        public List<Action> LegendaryActions { set; get; }
        public List<Action> Reactions { set; get; }


        #region CALCULOS

        public void RecalculatePorficiency()
        {
            RecalculatePerception();
            RecalculateAttackAction();
            RecalculateST();
            RecalculateSkills();
        }

        public void RecalculateAbilityModifier()
        {
            foreach (var item in this.AbilitiesScores)
            {
                double aux = (item.Value - 10.0) / 2.0;
                item.ModValue = (int)Math.Floor(aux);
            }

            RecalculateHP();
            RecalculateAC();
            RecalculateSkills();
            RecalculateST();
            RecalculatePerception();
            RecalculateHitAction();
            RecalculateAttackAction();
        }

        public void RecalculateAC()
        {
            this.ArmorClass.Bonus = this.AbilitiesScores.Find(con => con.ShortName == "Dex").ModValue;
            this.ArmorClass.RecalculateAC();
        }

        public void RecalculateHP()
        {
            this.HitPoint.BonusCon = this.AbilitiesScores.Find(con => con.ShortName == "Con").ModValue;
            this.HitPoint.RecalculateHP();
        }

        public void RecalculateHitAction()
        {
            foreach (var item in this.Actions)
            {

                if (item.TypeAction == TypeAction.MeleeAttack || item.TypeAction == TypeAction.MeleeWeaponAttack)
                {
                    item.AbilityDamage = this.AbilitiesScores.Find(con => con.ShortName == "Str").ModValue;
                    var aux = new TypeHitDie().GetValueDie(item.Die);
                    item.Damage = item.HitDie * (int)Math.Floor(aux) + item.BonusDamage + item.AbilityDamage;
                }
                else if (item.TypeAction == TypeAction.RangeAttack || item.TypeAction == TypeAction.RangeWeaponAttack)
                {
                    item.AbilityDamage = this.AbilitiesScores.Find(con => con.ShortName == "Dex").ModValue;

                    var aux = new TypeHitDie().GetValueDie(item.Die);
                    item.Damage = item.HitDie * (int)Math.Floor(aux) + item.BonusDamage + item.AbilityDamage;
                }
                else
                {
                    item.AbilityDamage = this.AbilitiesScores.Find(con => con.ShortName == item.AbilityAction).ModValue;

                    var aux = new TypeHitDie().GetValueDie(item.Die);
                    item.Damage = item.HitDie * (int)Math.Floor(aux) + item.BonusDamage + item.AbilityDamage;
                }


            }
        }

        public void RecalculateAttackAction()
        {
            foreach (var item in this.Actions)
            {
                if (item.TypeAction == TypeAction.MeleeAttack || item.TypeAction == TypeAction.MeleeAttack)
                {
                    item.TotalBonusAttack = this.Challenge.ProficiencyBonus +
                        this.AbilitiesScores.Find(con => con.ShortName == "Str").ModValue +
                        item.BonusAttack;
                }
                else
                {
                    item.TotalBonusAttack = this.Challenge.ProficiencyBonus +
                        this.AbilitiesScores.Find(con => con.ShortName == "Dex").ModValue +
                        item.BonusAttack;
                }
            }
        }

        public void RecalculateST()
        {
            var stnew = new List<SavingThrow>();
            foreach (var item in AbilitiesScores)
            {
                if (item.SavingThrow)
                {
                    stnew.Add(new SavingThrow()
                    {
                        ModName = item.ShortName,
                        Value = item.ModValue + this.Challenge.ProficiencyBonus
                    });
                }

            }

            this.SavingThrows = stnew;
        }

        public void RecalculateSkills()
        {
            foreach (var item in this.Skills)
            {
                if (item.SkillName == SkillName.Athletics)
                {
                    item.Total = this.Challenge.ProficiencyBonus + this.AbilitiesScores.Find(con => con.ShortName == "Str").ModValue + item.Bonus;
                }
                else if (item.SkillName == SkillName.Acrobatics || item.SkillName == SkillName.SleightofHand || item.SkillName == SkillName.Stealth)
                {
                    item.Total = this.Challenge.ProficiencyBonus + this.AbilitiesScores.Find(con => con.ShortName == "Dex").ModValue + item.Bonus;
                }
                else if (item.SkillName == SkillName.Arcana || item.SkillName == SkillName.History || item.SkillName == SkillName.Investigation
                    || item.SkillName == SkillName.Nature || item.SkillName == SkillName.Religion)
                {
                    item.Total = this.Challenge.ProficiencyBonus + this.AbilitiesScores.Find(con => con.ShortName == "Int").ModValue + item.Bonus;
                }
                else if (item.SkillName == SkillName.AnimalHandling || item.SkillName == SkillName.Insight || item.SkillName == SkillName.Medicine
                    || item.SkillName == SkillName.Perception || item.SkillName == SkillName.Survival)
                {
                    item.Total = this.Challenge.ProficiencyBonus + this.AbilitiesScores.Find(con => con.ShortName == "Wis").ModValue + item.Bonus;
                }
                else
                {
                    item.Total = this.Challenge.ProficiencyBonus + this.AbilitiesScores.Find(con => con.ShortName == "Cha").ModValue + item.Bonus;
                }
            }
        }

        public void RecalculatePerception()
        {

            foreach (var item in this.Senses)
            {
                if (item.TypeSense == TypeSense.passivePerception)
                {
                    item.range = 10 + this.AbilitiesScores.Find(con => con.ShortName == "Wis").ModValue + this.Challenge.ProficiencyBonus;
                }
            }

        }

        public void AddSpeed(List<Enum.TypeSpeed> list)
        {
            var newListSpeeds = new List<Speed>();

            if (list == null)
                list = new List<TypeSpeed>();

            for (int i = 0; i < list.Count; i++)
            {
                newListSpeeds.Add(new Speed () { TypeSpeed = list[i], Speedft = 30 });
            }

            if (list.Count <= this.Speeds.Count)
            {
                this.Speeds = this.Speeds.Intersect(newListSpeeds, new Speed()).ToList();
            }
            else
            {
                newListSpeeds = newListSpeeds.Except(this.Speeds, new Speed()).ToList();
                this.Speeds.AddRange(newListSpeeds);
            }
        }


        public void AddSenses(List<Enum.TypeSense> list)
        {
            var newListSenses = new List<Sense>();

            if (list == null)
                list = new List<TypeSense>();

            for (int i = 0; i < list.Count; i++)
            {
                newListSenses.Add( new Sense() { TypeSense = list[i], range = 0 });
            }

            if (list.Count <= this.Senses.Count)
            {
                this.Senses = this.Senses.Intersect(newListSenses, new Sense()).ToList();
            }
            else
            {
                newListSenses = newListSenses.Except(this.Senses, new Sense()).ToList();
                this.Senses.AddRange(newListSenses);
            }
        }


        #endregion


        



    }
}
