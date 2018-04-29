using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Dnd_App.Models.Enum;
using Dnd_App.Entitites;
using AutoMapper;

namespace Dnd_App.Models.Characters
{
    [Table("PC")]
    public class PC : ICloneable
    {
        [Key]
        public int id { set; get; }
        public long TempID { set; get; }

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


        public Boolean Create()
        {
            try
            {
                using (var DB = new DnDAppDBEntities())
                {
                    var PCEntity = new Entitites.PC()
                    {
                        name = name,
                        Size = size.ToEntity(),
                        alignmentAttitude = (int)alignmentAttitude,
                        alignmentMorality = (int)alignmentMorality,
                        Armor = armorClass.ToEntity(),
                        HitPoint = hitPoint.ToEntity(),
                        telepathy = telepathy,
                        Challenge = level.ToEntity(),
                        HP = HP,
                        armorBonus = armorBonus,
                        race = (int)race,
                        background = (int) background,
                        C_class = (int) _class
                    };

                    foreach (var s in this.speeds)
                    {
                        DB.PC_Speed.Add(new PC_Speed() { PC = PCEntity, Speed = s.ToEntity(), isTemplate = false });
                    }

                    foreach (var s in this.presetSpeeds)
                    {
                        DB.PC_Speed.Add(new PC_Speed() { PC = PCEntity, Speed = s.ToEntity(), isTemplate = true });
                    }

                    foreach (var AS in this.abilitiesScores)
                    {
                        DB.PC_AbilityScore.Add(new PC_AbilityScore() { PC = PCEntity, AbilityScore = AS.ToEntity() });
                    }

                    foreach (var s in this.savingThrows)
                    {
                        DB.PC_SavingThrow.Add(new PC_SavingThrow() { PC = PCEntity, SavingThrow = s.ToEntity(), isTemplate = false });
                    }

                    foreach (var s in this.presetSavingThrows)
                    {
                        DB.PC_SavingThrow.Add(new PC_SavingThrow() { PC = PCEntity, SavingThrow = s.ToEntity(), isTemplate = true });
                    }

                    foreach (var s in this.skills)
                    {
                        DB.PC_Skill.Add(new PC_Skill() { PC = PCEntity, Skill = s.ToEntity(), isTemplate = false });
                    }

                    foreach (var s in this.presetSkills)
                    {
                        DB.PC_Skill.Add(new PC_Skill() { PC = PCEntity, Skill = s.ToEntity(), isTemplate = true });
                    }

                    foreach (var s in this.vulnerabilities)
                    {
                        var v = s.ToEntity();
                        v.damage1 = (int)Enum._Damage.Vul;
                        DB.PC_Damage.Add(new PC_Damage() { PC = PCEntity, Damage = v, isTemplate = false });
                    }

                    foreach (var s in this.presetVulnerabilities)
                    {
                        var v = s.ToEntity();
                        v.damage1 = (int)Enum._Damage.Vul;
                        DB.PC_Damage.Add(new PC_Damage() { PC = PCEntity, Damage = v, isTemplate = true });
                    }

                    foreach (var s in this.resistances)
                    {
                        var v = s.ToEntity();
                        v.damage1 = (int)Enum._Damage.Res;
                        DB.PC_Damage.Add(new PC_Damage() { PC = PCEntity, Damage = v, isTemplate = false });
                    }

                    foreach (var s in this.presetResistances)
                    {
                        var v = s.ToEntity();
                        v.damage1 = (int)Enum._Damage.Res;
                        DB.PC_Damage.Add(new PC_Damage() { PC = PCEntity, Damage = v, isTemplate = true });
                    }

                    foreach (var s in this.presetImmunitiesDamage)
                    {
                        var v = s.ToEntity();
                        v.damage1 = (int)Enum._Damage.Imm;
                        DB.PC_Damage.Add(new PC_Damage() { PC = PCEntity, Damage = v, isTemplate = true });
                    }

                    foreach (var s in this.immunitiesDamage)
                    {
                        var v = s.ToEntity();
                        v.damage1 = (int)Enum._Damage.Imm;
                        DB.PC_Damage.Add(new PC_Damage() { PC = PCEntity, Damage = v, isTemplate = false });
                    }

                    foreach (var s in this.immunitiesCondition)
                    {
                        var v = s.ToEntity();
                        DB.PC_Condition.Add(new PC_Condition() { PC = PCEntity, Condition = v, isTemplate = false });
                    }

                    foreach (var s in this.presetImmunitiesCondition)
                    {
                        var v = s.ToEntity();
                        DB.PC_Condition.Add(new PC_Condition() { PC = PCEntity, Condition = v, isTemplate = true });
                    }

                    foreach (var s in this.senses)
                    {
                        DB.PC_Sense.Add(new PC_Sense() { PC = PCEntity, Sense = s.ToEntity(), isTemplate = false });
                    }

                    foreach (var s in this.presetSenses)
                    {
                        DB.PC_Sense.Add(new PC_Sense() { PC = PCEntity, Sense = s.ToEntity(), isTemplate = true });
                    }

                    foreach (var s in this.languagesSpeak)
                    {
                        var v = s.ToEntity();
                        v.typeLanguage = (int)Enum._Language.speak;
                        DB.PC_Language.Add(new PC_Language() { PC = PCEntity, Language = v, isTemplate = false });
                    }

                    foreach (var s in this.presetLanguagesSpeak)
                    {
                        var v = s.ToEntity();
                        v.typeLanguage = (int)Enum._Language.speak;
                        DB.PC_Language.Add(new PC_Language() { PC = PCEntity, Language = v, isTemplate = true });
                    }

                    foreach (var s in this.languagesUndersatand)
                    {
                        var v = s.ToEntity();
                        v.typeLanguage = (int)Enum._Language.understand;
                        DB.PC_Language.Add(new PC_Language() { PC = PCEntity, Language = v, isTemplate = false });
                    }

                    foreach (var s in this.presetLanguagesUndersatand)
                    {
                        var v = s.ToEntity();
                        v.typeLanguage = (int)Enum._Language.understand;
                        DB.PC_Language.Add(new PC_Language() { PC = PCEntity, Language = v, isTemplate = true });
                    }

                    foreach (var s in this.specialTraits)
                    {
                        DB.PC_SpecialTrait.Add(new PC_SpecialTrait() { PC = PCEntity, SpecialTrait = s.ToEntity(), isTemplate= false });
                    }

                    foreach (var s in this.presetSpecialTraits)
                    {
                        DB.PC_SpecialTrait.Add(new PC_SpecialTrait() { PC = PCEntity, SpecialTrait = s.ToEntity(), isTemplate = true });
                    }

                    foreach (var s in this.actions)
                    {
                        var v = s.ToEntity();
                        v.Actiontype = (int)Enum._Action.Action;
                        DB.PC_Action.Add(new PC_Action() { PC = PCEntity, Action = v, isTemplate = false });
                    }

                    foreach (var s in this.presetActions)
                    {
                        var v = s.ToEntity();
                        v.Actiontype = (int)Enum._Action.Action;
                        DB.PC_Action.Add(new PC_Action() { PC = PCEntity, Action = v, isTemplate = true });
                    }



                    DB.PC.Add(PCEntity);
                    DB.SaveChanges();

                    this.id = PCEntity.id;

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
                    var PCEntity = DB.PC.Where(pc => pc.id == this.id).First();

                    this.id = PCEntity.id;
                    this.name = PCEntity.name;
                    this.size = Mapper.Map<Size>(PCEntity.Size);
                    this.alignmentAttitude = (Enum.TypeAlignAttitude)PCEntity.alignmentAttitude;
                    this.alignmentMorality = (Enum.TypeAlignMorality)PCEntity.alignmentMorality;
                    this.armorClass = Mapper.Map<Armor>(PCEntity.Armor);
                    this.hitPoint = Mapper.Map<HitPoint>(PCEntity.HitPoint);
                    this.level = Mapper.Map<Challenge>(PCEntity.Challenge);
                    this.telepathy = PCEntity.telepathy;
                    this.race = (Race) PCEntity.race;
                    this._class = (_Class)PCEntity.C_class;
                    this.background = (Background)PCEntity.background;

                    foreach (var s in PCEntity.PC_Speed.Where(n => !n.isTemplate))
                    {
                        this.speeds.Add(Mapper.Map<Speed>(s.Speed));
                    }

                    foreach (var s in PCEntity.PC_Speed.Where(n => n.isTemplate))
                    {
                        this.presetSpeeds.Add(Mapper.Map<Speed>(s.Speed));
                    }

                    foreach (var AS in PCEntity.PC_AbilityScore)
                    {
                        this.abilitiesScores.Add(Mapper.Map<AbilityScore>(AS.AbilityScore));
                    }

                    foreach (var s in PCEntity.PC_SavingThrow.Where(n => !n.isTemplate))
                    {
                        this.savingThrows.Add(Mapper.Map<SavingThrow>(s.SavingThrow));
                    }

                    foreach (var s in PCEntity.PC_SavingThrow.Where(n => n.isTemplate))
                    {
                        this.presetSavingThrows.Add(Mapper.Map<SavingThrow>(s.SavingThrow));
                    }

                    foreach (var s in PCEntity.PC_Skill.Where(n => !n.isTemplate))
                    {
                        this.skills.Add(Mapper.Map<Skill>(s.Skill));
                    }

                    foreach (var s in PCEntity.PC_Skill.Where(n => n.isTemplate))
                    {
                        this.presetSkills.Add(Mapper.Map<Skill>(s.Skill));
                    }

                    foreach (var s in PCEntity.PC_Damage.Where(n => !n.isTemplate))
                    {
                        if ((Enum._Damage)s.Damage.damage1 == Enum._Damage.Vul)
                            this.vulnerabilities.Add(Mapper.Map<Damage>(s.Damage));
                        if ((Enum._Damage)s.Damage.damage1 == Enum._Damage.Res)
                            this.resistances.Add(Mapper.Map<Damage>(s.Damage));
                        if ((Enum._Damage)s.Damage.damage1 == Enum._Damage.Imm)
                            this.immunitiesDamage.Add(Mapper.Map<Damage>(s.Damage));
                    }

                    foreach (var s in PCEntity.PC_Damage.Where(n => n.isTemplate))
                    {
                        if ((Enum._Damage)s.Damage.damage1 == Enum._Damage.Vul)
                            this.presetVulnerabilities.Add(Mapper.Map<Damage>(s.Damage));
                        if ((Enum._Damage)s.Damage.damage1 == Enum._Damage.Res)
                            this.presetResistances.Add(Mapper.Map<Damage>(s.Damage));
                        if ((Enum._Damage)s.Damage.damage1 == Enum._Damage.Imm)
                            this.presetImmunitiesDamage.Add(Mapper.Map<Damage>(s.Damage));
                    }

                    foreach (var s in PCEntity.PC_Condition.Where(n => !n.isTemplate))
                    {
                        this.immunitiesCondition.Add(Mapper.Map<Condition>(s.Condition));
                    }

                    foreach (var s in PCEntity.PC_Condition.Where(n => n.isTemplate))
                    {
                        this.presetImmunitiesCondition.Add(Mapper.Map<Condition>(s.Condition));
                    }

                    foreach (var s in PCEntity.PC_Sense.Where(n => !n.isTemplate))
                    {
                        this.senses.Add(Mapper.Map<Sense>(s.Sense));
                    }

                    foreach (var s in PCEntity.PC_Sense.Where(n => n.isTemplate))
                    {
                        this.presetSenses.Add(Mapper.Map<Sense>(s.Sense));
                    }

                    foreach (var s in PCEntity.PC_Language.Where(n => !n.isTemplate))
                    {
                        if ((Enum._Language)s.Language.typeLanguage == Enum._Language.speak)
                            this.languagesSpeak.Add(Mapper.Map<Language>(s.Language));
                        if ((Enum._Language)s.Language.typeLanguage == Enum._Language.understand)
                            this.languagesUndersatand.Add(Mapper.Map<Language>(s.Language));
                    }

                    foreach (var s in PCEntity.PC_Language.Where(n => n.isTemplate))
                    {
                        if ((Enum._Language)s.Language.typeLanguage == Enum._Language.speak)
                            this.presetLanguagesSpeak.Add(Mapper.Map<Language>(s.Language));
                        if ((Enum._Language)s.Language.typeLanguage == Enum._Language.understand)
                            this.presetLanguagesUndersatand.Add(Mapper.Map<Language>(s.Language));
                    }

                    foreach (var s in PCEntity.PC_SpecialTrait.Where(n => !n.isTemplate))
                    {
                        this.specialTraits.Add(Mapper.Map<SpecialTrait>(s.SpecialTrait));
                    }

                    foreach (var s in PCEntity.PC_SpecialTrait.Where(n => n.isTemplate))
                    {
                        this.presetSpecialTraits.Add(Mapper.Map<SpecialTrait>(s.SpecialTrait));
                    }

                    foreach (var s in PCEntity.PC_Action.Where(n => !n.isTemplate))
                    {
                        if ((Enum._Action)s.Action.Actiontype == Enum._Action.Action)
                            this.actions.Add(Mapper.Map<Action>(s.Action));
                    }

                    foreach (var s in PCEntity.PC_Action.Where(n => n.isTemplate))
                    {
                        if ((Enum._Action)s.Action.Actiontype == Enum._Action.Action)
                            this.presetActions.Add(Mapper.Map<Action>(s.Action));
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
            
            this.Delete();
            this.id = 0;
            this.Create();
            return this.id;

            //Actualizar referencias

        }

        public Boolean Delete()
        {
            try
            {
                using (var DB = new DnDAppDBEntities())
                {
                    var PCEntityOld = DB.PC.Where(pc => pc.id == this.id).First();
                    DB.PC.Remove(PCEntityOld);
                    DB.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        #region Calculos


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

        #endregion


        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}