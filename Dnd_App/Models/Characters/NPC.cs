using AutoMapper;
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


        public Boolean Create()
        {
            try
            {
                using (var DB = new DnDAppDBEntities())
                {
                    var NPCEntity = new Entitites.NPC()
                    {
                        name = Name,
                        Size = Size.ToEntity(),
                        typecreature = (int) TypeCreature,
                        tag = Tag,
                        alignmentAttitude = (int)AlignmentAttitude,
                        alignmentMorality = (int)AlignmentMorality,
                        Armor = ArmorClass.ToEntity(),
                        HitPoint = HitPoint.ToEntity(),
                        telepathy = Telepathy,
                        Challenge = Challenge.ToEntity()
                    };

                    foreach (var s in this.Speeds)
                    {
                        DB.NPC_Speed.Add( new NPC_Speed() { NPC = NPCEntity, Speed = s.ToEntity()});
                    }

                    foreach (var AS in this.AbilitiesScores)
                    {
                        DB.NPC_AbilityScore.Add(new NPC_AbilityScore(){NPC = NPCEntity, AbilityScore = AS.ToEntity()});
                    }

                    foreach (var s in this.SavingThrows)
                    {
                        DB.NPC_SavingThrow.Add(new NPC_SavingThrow() { NPC = NPCEntity, SavingThrow = s.ToEntity()});
                    }

                    foreach (var s in this.Skills)
                    {
                        DB.NPC_Skill.Add(new NPC_Skill() { NPC = NPCEntity, Skill = s.ToEntity() });
                    }

                    foreach (var s in this.Vulnerabilities)
                    {
                        var v = s.ToEntity();
                        v.damage1 = (int) Enum._Damage.Vul;
                        DB.NPC_Damage.Add(new NPC_Damage() { NPC = NPCEntity, Damage = v });
                    }

                    foreach (var s in this.Resistances)
                    {
                        var v = s.ToEntity();
                        v.damage1 = (int)Enum._Damage.Res;
                        DB.NPC_Damage.Add(new NPC_Damage() { NPC = NPCEntity, Damage = v });
                    }

                    foreach (var s in this.ImmunitiesDamage)
                    {
                        var v = s.ToEntity();
                        v.damage1 = (int)Enum._Damage.Imm;
                        DB.NPC_Damage.Add(new NPC_Damage() { NPC = NPCEntity, Damage = v });
                    }

                    foreach (var s in this.ImmunitiesCondition)
                    {
                        var v = s.ToEntity();
                        DB.NPC_Condition.Add(new NPC_Condition() { NPC = NPCEntity, Condition = v });
                    }

                    foreach (var s in this.Senses)
                    {
                        DB.NPC_Sense.Add(new NPC_Sense() { NPC = NPCEntity, Sense = s.ToEntity() });
                    }

                    foreach (var s in this.LanguagesSpeak)
                    {
                        var v = s.ToEntity();
                        v.typeLanguage = (int)Enum._Language.speak;
                        DB.NPC_Language.Add(new NPC_Language() { NPC = NPCEntity, Language = v });
                    }

                    foreach (var s in this.LanguagesUndersatand)
                    {
                        var v = s.ToEntity();
                        v.typeLanguage = (int)Enum._Language.understand;
                        DB.NPC_Language.Add(new NPC_Language() { NPC = NPCEntity, Language = v });
                    }

                    foreach (var s in this.SpecialTraits)
                    {
                        DB.NPC_SpecialTrait.Add(new NPC_SpecialTrait() { NPC = NPCEntity, SpecialTrait = s.ToEntity() });
                    }

                    foreach (var s in this.Actions)
                    {
                        var v = s.ToEntity();
                        v.Actiontype = (int)Enum._Action.Action;
                        DB.NPC_Action.Add(new NPC_Action() { NPC = NPCEntity, Action = v });
                    }

                    foreach (var s in this.Reactions)
                    {
                        var v = s.ToEntity();
                        v.Actiontype = (int)Enum._Action.reaction;
                        DB.NPC_Action.Add(new NPC_Action() { NPC = NPCEntity, Action = v });
                    }

                    foreach (var s in this.LegendaryActions)
                    {
                        var v = s.ToEntity();
                        v.Actiontype = (int)Enum._Action.laction;
                        DB.NPC_Action.Add(new NPC_Action() { NPC = NPCEntity, Action = v });
                    }

                    DB.NPC.Add(NPCEntity);
                    DB.SaveChanges();

                    this.Id = NPCEntity.id;

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean Select()
        {
            try
            {
                using (var DB = new DnDAppDBEntities())
                {
                    var NPCEntity = DB.NPC.Where(npc => npc.id == this.Id).First();

                    this.Id = NPCEntity.id;
                    this.Name = NPCEntity.name;
                    this.Size = Mapper.Map<Size>(NPCEntity.Size);
                    this.AlignmentAttitude = (Enum.TypeAlignAttitude) NPCEntity.alignmentAttitude;
                    this.AlignmentMorality = (Enum.TypeAlignMorality) NPCEntity.alignmentMorality;
                    this.TypeCreature = (Enum.TypeCreature) NPCEntity.typecreature;
                    this.Tag = NPCEntity.tag;
                    this.ArmorClass = Mapper.Map<Armor>(NPCEntity.Armor);
                    this.HitPoint = Mapper.Map<HitPoint>(NPCEntity.HitPoint);
                    this.Challenge = Mapper.Map<Challenge>(NPCEntity.Challenge);
                    this.Telepathy = NPCEntity.telepathy;

                    foreach (var s in NPCEntity.NPC_Speed)
                    {
                        this.Speeds.Add(Mapper.Map<Speed>(s.Speed));
                    }

                    foreach (var AS in NPCEntity.NPC_AbilityScore)
                    {
                        this.AbilitiesScores.Add(Mapper.Map<AbilityScore>(AS.AbilityScore));
                    }

                    foreach (var s in NPCEntity.NPC_SavingThrow)
                    {
                        this.SavingThrows.Add(Mapper.Map<SavingThrow>(s.SavingThrow));
                    }

                    foreach (var s in NPCEntity.NPC_Skill)
                    {
                        this.Skills.Add(Mapper.Map<Skill>(s.Skill));
                    }

                    foreach (var s in NPCEntity.NPC_Damage)
                    {
                        if((Enum._Damage) s.Damage.damage1 == Enum._Damage.Vul)
                            this.Vulnerabilities.Add(Mapper.Map<Damage>(s.Damage));
                        if ((Enum._Damage)s.Damage.damage1 == Enum._Damage.Res)
                            this.Resistances.Add(Mapper.Map<Damage>(s.Damage));
                        if ((Enum._Damage)s.Damage.damage1 == Enum._Damage.Imm)
                            this.ImmunitiesDamage.Add(Mapper.Map<Damage>(s.Damage));

                    }

                    foreach (var s in NPCEntity.NPC_Condition)
                    {
                        this.ImmunitiesCondition.Add(Mapper.Map<Condition>(s.Condition));
                    }

                    foreach (var s in NPCEntity.NPC_Sense)
                    {
                        this.Senses.Add(Mapper.Map<Sense>(s.Sense));
                    }

                    foreach (var s in NPCEntity.NPC_Language)
                    {
                        if ((Enum._Language)s.Language.typeLanguage == Enum._Language.speak)
                            this.LanguagesSpeak.Add(Mapper.Map<Language>(s.Language));
                        if ((Enum._Language)s.Language.typeLanguage == Enum._Language.understand)
                            this.LanguagesUndersatand.Add(Mapper.Map<Language>(s.Language));
                    }

                    foreach (var s in NPCEntity.NPC_SavingThrow)
                    {
                        this.SavingThrows.Add(Mapper.Map<SavingThrow>(s.SavingThrow));
                    }

                    foreach (var s in NPCEntity.NPC_Action)
                    {
                        if ((Enum._Action)s.Action.Actiontype == Enum._Action.Action)
                            this.Actions.Add(Mapper.Map<Action>(s.Action));
                        if ((Enum._Action)s.Action.Actiontype == Enum._Action.reaction)
                            this.Reactions.Add(Mapper.Map<Action>(s.Action));
                        if ((Enum._Action)s.Action.Actiontype == Enum._Action.laction)
                            this.LegendaryActions.Add(Mapper.Map<Action>(s.Action));
                    }

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int Update()
        {
            #region Bug
            //try
            //{
            //    using (var DB = new DnDAppDBEntities())
            //    {

            //        var NPCEntityOld = DB.NPC.Where(npc => npc.id == this.Id).First();
            //        DB.NPC.Remove(NPCEntityOld);
            //        var x = DB.SaveChanges();
            //        var NPCEntity = new Entitites.NPC()
            //        {
            //            id = Id,
            //            name = Name,
            //            Size = Size.ToEntity(),
            //            typecreature = (int)TypeCreature,
            //            tag = Tag,
            //            alignmentAttitude = (int)AlignmentAttitude,
            //            alignmentMorality = (int)AlignmentMorality,
            //            Armor = ArmorClass.ToEntity(),
            //            HitPoint = HitPoint.ToEntity(),
            //            telepathy = Telepathy,
            //            Challenge = Challenge.ToEntity()
            //        };

            //        foreach (var s in this.Speeds)
            //        {
            //            DB.NPC_Speed.Add(new NPC_Speed() { NPC = NPCEntity, Speed = s.ToEntity() });
            //        }

            //        foreach (var AS in this.AbilitiesScores)
            //        {
            //            DB.NPC_AbilityScore.Add(new NPC_AbilityScore() { NPC = NPCEntity, AbilityScore = AS.ToEntity() });
            //        }

            //        foreach (var s in this.SavingThrows)
            //        {
            //            DB.NPC_SavingThrow.Add(new NPC_SavingThrow() { NPC = NPCEntity, SavingThrow = s.ToEntity() });
            //        }

            //        foreach (var s in this.Skills)
            //        {
            //            DB.NPC_Skill.Add(new NPC_Skill() { NPC = NPCEntity, Skill = s.ToEntity() });
            //        }

            //        foreach (var s in this.Vulnerabilities)
            //        {
            //            var v = s.ToEntity();
            //            v.damage1 = (int)Enum._Damage.Vul;
            //            DB.NPC_Damage.Add(new NPC_Damage() { NPC = NPCEntity, Damage = v });
            //        }

            //        foreach (var s in this.Resistances)
            //        {
            //            var v = s.ToEntity();
            //            v.damage1 = (int)Enum._Damage.Res;
            //            DB.NPC_Damage.Add(new NPC_Damage() { NPC = NPCEntity, Damage = v });
            //        }

            //        foreach (var s in this.ImmunitiesDamage)
            //        {
            //            var v = s.ToEntity();
            //            v.damage1 = (int)Enum._Damage.Imm;
            //            DB.NPC_Damage.Add(new NPC_Damage() { NPC = NPCEntity, Damage = v });
            //        }

            //        foreach (var s in this.ImmunitiesCondition)
            //        {
            //            var v = s.ToEntity();
            //            DB.NPC_Condition.Add(new NPC_Condition() { NPC = NPCEntity, Condition = v });
            //        }

            //        foreach (var s in this.Senses)
            //        {
            //            DB.NPC_Sense.Add(new NPC_Sense() { NPC = NPCEntity, Sense = s.ToEntity() });
            //        }

            //        foreach (var s in this.LanguagesSpeak)
            //        {
            //            var v = s.ToEntity();
            //            v.typeLanguage = (int)Enum._Language.speak;
            //            DB.NPC_Language.Add(new NPC_Language() { NPC = NPCEntity, Language = v });
            //        }

            //        foreach (var s in this.LanguagesUndersatand)
            //        {
            //            var v = s.ToEntity();
            //            v.typeLanguage = (int)Enum._Language.understand;
            //            DB.NPC_Language.Add(new NPC_Language() { NPC = NPCEntity, Language = v });
            //        }

            //        foreach (var s in this.SpecialTraits)
            //        {
            //            DB.NPC_SpecialTrait.Add(new NPC_SpecialTrait() { NPC = NPCEntity, SpecialTrait = s.ToEntity() });
            //        }

            //        foreach (var s in this.Actions)
            //        {
            //            var v = s.ToEntity();
            //            v.Actiontype = (int)Enum._Action.Action;
            //            DB.NPC_Action.Add(new NPC_Action() { NPC = NPCEntity, Action = v });
            //        }

            //        foreach (var s in this.Reactions)
            //        {
            //            var v = s.ToEntity();
            //            v.Actiontype = (int)Enum._Action.reaction;
            //            DB.NPC_Action.Add(new NPC_Action() { NPC = NPCEntity, Action = v });
            //        }

            //        foreach (var s in this.LegendaryActions)
            //        {
            //            var v = s.ToEntity();
            //            v.Actiontype = (int)Enum._Action.laction;
            //            DB.NPC_Action.Add(new NPC_Action() { NPC = NPCEntity, Action = v });
            //        }


            //        DB.NPC.Add(NPCEntity);
            //        x = DB.SaveChanges();



            //        return true;
            //    }
            //}
            //catch (Exception e)
            //{
            //    return false;
            //}
            #endregion
            this.Delete();
            this.Id = 0;
            this.Create();
            return this.Id;
            //Actualizar referencias

        }

        public Boolean Delete()
        {
            try
            {
                using (var DB = new DnDAppDBEntities())
                {
                    var NPCEntityOld = DB.NPC.Where(npc => npc.id == this.Id).First();
                    DB.NPC.Remove(NPCEntityOld);
                    DB.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
