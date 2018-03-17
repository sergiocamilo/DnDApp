using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dnd_App.Models.Characters;
using Dnd_App.Models.Enum;
using Dnd_App.Models.Combat;

namespace Dnd_App.Utils
{
    
    public class TemporalDB
    {
        private static TemporalDB instance;

        public Dictionary<long, NPC> NPCInstances { get; set; }
        public Dictionary<long, PC> PCInstances { get; set; }
        public Dictionary<long, Combat> CombatInstances { get; set; }
        public long NPCInstancesIndex;
        public long PCInstancesIndex;
        public long CombatInstancesIndex;

        public NPC Deva{ get; }

        private TemporalDB()
        {

            Deva = new NPC();
            Deva = GenerateDEVA();

            NPCInstances = new Dictionary<long, NPC>();
            NPCInstances.Add(0, Deva);
            NPCInstancesIndex = 1;


            PCInstances = new Dictionary<long, PC>();
            PCInstancesIndex = 1;

            CombatInstances = new Dictionary<long, Combat>();
            CombatInstancesIndex = 1;

        }

        
        public static TemporalDB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TemporalDB();
                }
                return instance;
            }
        }


        #region NPC methods

        private NPC GenerateDEVA()
        {

            NPC DEVA = new NPC();

            DEVA.Name = "DEVA test";
            DEVA.Tag = "";
            DEVA.Size = new Size() { TypeSize = TypeSize.Medium, Space = 10 };
            DEVA.TypeCreature = TypeCreature.Celestial;
            DEVA.AlignmentMorality = TypeAlignMorality.good;
            DEVA.AlignmentAttitude = TypeAlignAttitude.lawful;

            DEVA.ArmorClass = new Armor()
            {
                Total = 14,
                Name = ArmorName.NaturalArmor,
                BaseArmor = 10,
                Bonus = 4,
                MaxDexMod = 0,
                Shield = false,
                Stealth = false
            };
            DEVA.HitPoint = new HitPoint()
            {
                HitPointsAVG = 136,
                Die = 16,
                TypeDie = TypeDie.d4,
                BonusCon = 4,
                BonusMultiplied = 64
            };
            DEVA.Speeds = new List<Speed>();
            DEVA.Speeds.Add(new Speed() { TypeSpeed = TypeSpeed.Base, Speedft = 30 });
            DEVA.Speeds.Add(new Speed() { TypeSpeed = TypeSpeed.Fly, Speedft = 90 });

            DEVA.AbilitiesScores = new List<AbilityScore>();
            DEVA.AbilitiesScores.Add(new AbilityScore() { Name = "Strenght", ShortName = "Str", Value = 18, ModValue = 4 });
            DEVA.AbilitiesScores.Add(new AbilityScore() { Name = "Dexterity", ShortName = "Dex", Value = 18, ModValue = 4 });
            DEVA.AbilitiesScores.Add(new AbilityScore() { Name = "Constitution", ShortName = "Con", Value = 18, ModValue = 4 });
            DEVA.AbilitiesScores.Add(new AbilityScore() { Name = "Intelligence", ShortName = "Int", Value = 17, ModValue = 3 });
            DEVA.AbilitiesScores.Add(new AbilityScore() { Name = "Wisdom", ShortName = "Wis", Value = 20, ModValue = 5, SavingThrow = true });
            DEVA.AbilitiesScores.Add(new AbilityScore() { Name = "Charisma", ShortName = "Cha", Value = 20, ModValue = 5, SavingThrow = true });

            DEVA.SavingThrows = new List<SavingThrow>();
            DEVA.SavingThrows.Add(new SavingThrow() { ModName = "Wis", Value = 9 });
            DEVA.SavingThrows.Add(new SavingThrow() { ModName = "Cha", Value = 9 });
            DEVA.Skills = new List<Skill>();
            DEVA.Skills.Add(new Skill() { SkillName = SkillName.Insight, Total = 7, Value = 3, Bonus = 4 });
            DEVA.Skills.Add(new Skill() { SkillName = SkillName.Perception, Total = 9, Value = 5, Bonus = 4 });

            DEVA.Vulnerabilities = new List<Damage>();
            DEVA.ImmunitiesDamage = new List<Damage>();
            DEVA.Resistances = new List<Damage>();

            DEVA.Resistances.Add(new Damage() { TypeDamage = TypeDamage.Radiant });
            DEVA.Resistances.Add(new Damage() { TypeDamage = TypeDamage.Bludgeoning });
            DEVA.Resistances.Add(new Damage() { TypeDamage = TypeDamage.Piercing });
            DEVA.Resistances.Add(new Damage() { TypeDamage = TypeDamage.Slashing });

            DEVA.ImmunitiesCondition = new List<Condition>();
            DEVA.ImmunitiesCondition.Add(new Condition() { TypeCondition = TypeCondition.Charmed });
            DEVA.ImmunitiesCondition.Add(new Condition() { TypeCondition = TypeCondition.Exhaustion });
            DEVA.ImmunitiesCondition.Add(new Condition() { TypeCondition = TypeCondition.Frightened });


            DEVA.Senses = new List<Sense>();
            DEVA.Senses.Add(new Sense() { TypeSense = TypeSense.Darkvision, range = 120 });
            DEVA.Senses.Add(new Sense() { TypeSense = TypeSense.passivePerception, range = 19 });

            DEVA.LanguagesSpeak = new List<Language>();
            DEVA.LanguagesUndersatand = new List<Language>();
            DEVA.Telepathy = 120;

            DEVA.Challenge = new Challenge() { Value = "10", XP = 5900, ProficiencyBonus = 4 };

            DEVA.SpecialTraits = new List<SpecialTrait>();
            DEVA.SpecialTraits.Add(new SpecialTrait()
            {
                Name = "Angelic Weapons",
                Description = "The deva's weapon attacks are magical." +
                " When the deva hits with anyweapon, the weapon deals an extra 4d8 radiant damage (included in the attack)."
            });
            DEVA.SpecialTraits.Add(new SpecialTrait()
            {
                Name = "Innate Spellcasting",
                Description = "The deva's spellcasting ability is " +
                "Charisma (spell saveDC17).The deva can innately cast the following spells, requiring onlyverbalcomponents: \n At will: " +
                "detect evil and good \n 1Jday each:commune, raise dead" +
                " When the deva hits with anyweapon, the weapon deals an extra 4d8 radiant damage (included in the attack)."
            });
            DEVA.SpecialTraits.Add(new SpecialTrait()
            {
                Name = "Magic Resistance",
                Description = "The deva has advantage on saving throws against spells and other magicaleffects."
            });


            DEVA.Actions = new List<Models.Characters.Action>();
            //DEVA.actions.Add(new Action()
            //{
            //    name = "Multiattack",
            //    limited = "",
            //    description = "The deva makes two melee attacks"
            //});

            DEVA.Actions.Add(new Models.Characters.Action()
            {
                Name = "Mace",
                Limited = "",
                TypeAction = TypeAction.MeleeWeaponAttack,
                AbilityAction = "Str",
                TotalBonusAttack = 8,
                Range = 5,
                Target = "one target",
                Damage = 7,
                HitDie = 1,
                Die = TypeDie.d6,
                AbilityDamage = 4,
                BonusDamage = 0,
                TypeDamage = TypeDamage.Bludgeoning,
                Description = ""
            });


            DEVA.LegendaryActions = new List<Models.Characters.Action>();
            DEVA.Reactions = new List<Models.Characters.Action>();

            return DEVA;
        }

        public void InsertNPC(NPC NewNPC)
        {
            lock (new { })
            {
                NewNPC.TempID = NPCInstancesIndex;
                NPCInstances.Add(NPCInstancesIndex, NewNPC);
                NPCInstancesIndex++;
            }
        }

        public NPC SelectNPC(long TempID)
        {
            return NPCInstances[TempID];
        }


        #endregion
        

        #region PC methods

        public void InsertPC(PC NewPC)
        {
            lock (new { })
            {
                NewPC.TempID = PCInstancesIndex;
                PCInstances.Add(PCInstancesIndex, NewPC);
                PCInstancesIndex++;
            }
        }

        public PC SelectPC(long TempID)
        {
            return PCInstances[TempID];
        }

        #endregion


        #region Combat methods

        public void InsertCombat(Combat NewCombat)
        {
            lock (new { })
            {
                NewCombat.TempID = CombatInstancesIndex;
                CombatInstances.Add(CombatInstancesIndex, NewCombat);
                CombatInstancesIndex++;
            }
        }

        public Combat SelectCombat(long TempID)
        {
            return CombatInstances[TempID];
        }

        #endregion





    }
}