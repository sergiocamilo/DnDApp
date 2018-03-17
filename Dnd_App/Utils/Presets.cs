using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dnd_App.Models.Characters;
using Dnd_App.Models.Enum;
using Dnd_App.Models.Combat;

namespace Dnd_App.Utils
{
    public class Presets
    {
        public NPC GenerateEmptyNPC()
        {

            NPC Empty = new NPC();

            Empty.Name = "Name";
            Empty.Tag = "";
            Empty.Size = new Size() { TypeSize = TypeSize.Medium, Space = 10 };
            Empty.TypeCreature = TypeCreature.Aberration;
            Empty.AlignmentMorality = TypeAlignMorality.none;
            Empty.AlignmentAttitude = TypeAlignAttitude.none;

            Empty.ArmorClass = new Armor()
            {
                Total = 14,
                Name = ArmorName.NaturalArmor,
                BaseArmor = 10,
                Bonus = 4,
                MaxDexMod = 0,
                Shield = false,
                Stealth = false
            };
            Empty.HitPoint = new HitPoint()
            {
                HitPointsAVG = 136,
                Die = 16,
                TypeDie = TypeDie.d4,
                BonusCon = 4,
                BonusMultiplied = 64
            };
            Empty.Speeds = new List<Speed>();
            Empty.Speeds.Add(new Speed() { TypeSpeed = TypeSpeed.Base, Speedft = 30 });

            Empty.AbilitiesScores = new List<AbilityScore>();
            Empty.AbilitiesScores.Add(new AbilityScore() { Name = "Strenght", ShortName = "Str", Value = 18, ModValue = 4 });
            Empty.AbilitiesScores.Add(new AbilityScore() { Name = "Dexterity", ShortName = "Dex", Value = 18, ModValue = 4 });
            Empty.AbilitiesScores.Add(new AbilityScore() { Name = "Constitution", ShortName = "Con", Value = 18, ModValue = 4 });
            Empty.AbilitiesScores.Add(new AbilityScore() { Name = "Intelligence", ShortName = "Int", Value = 17, ModValue = 3 });
            Empty.AbilitiesScores.Add(new AbilityScore() { Name = "Wisdom", ShortName = "Wis", Value = 20, ModValue = 5, SavingThrow = true });
            Empty.AbilitiesScores.Add(new AbilityScore() { Name = "Charisma", ShortName = "Cha", Value = 20, ModValue = 5, SavingThrow = true });

            Empty.SavingThrows = new List<SavingThrow>();
            Empty.Skills = new List<Skill>();

            Empty.Vulnerabilities = new List<Damage>();
            Empty.ImmunitiesDamage = new List<Damage>();
            Empty.Resistances = new List<Damage>();

            Empty.ImmunitiesCondition = new List<Condition>();

           

            Empty.Senses = new List<Sense>();
           
            Empty.LanguagesSpeak = new List<Language>();
            Empty.LanguagesSpeak.Add(new Language() { LanguageName = LanguageName.Dwarvish });
            Empty.LanguagesUndersatand = new List<Language>();
            Empty.LanguagesUndersatand.Add(new Language() { LanguageName = LanguageName.Giant });
            Empty.Telepathy = 0;

            Empty.Challenge = new Challenge() { Value = "10", XP = 5900, ProficiencyBonus = 4 };

            Empty.SpecialTraits = new List<SpecialTrait>();

            Empty.Actions = new List<Models.Characters.Action>();
            Empty.LegendaryActions = new List<Models.Characters.Action>();
            Empty.Reactions = new List<Models.Characters.Action>();

            return Empty;


        }


        public NPC initVoidNPC()
        {

            NPC Empty = new NPC();

            Empty.Name = "";
            Empty.Tag = "";
            Empty.Size = new Size();
            Empty.TypeCreature = TypeCreature.Aberration;
            Empty.AlignmentMorality = TypeAlignMorality.none;
            Empty.AlignmentAttitude = TypeAlignAttitude.none;
            Empty.ArmorClass = new Armor();
            Empty.HitPoint = new HitPoint();
            Empty.Speeds = new List<Speed>();
            Empty.AbilitiesScores = new List<AbilityScore>();
            Empty.SavingThrows = new List<SavingThrow>();
            Empty.Skills = new List<Skill>();
            Empty.Vulnerabilities = new List<Damage>();
            Empty.ImmunitiesDamage = new List<Damage>();
            Empty.Resistances = new List<Damage>();
            Empty.ImmunitiesCondition = new List<Condition>();
            Empty.Senses = new List<Sense>();
            Empty.LanguagesSpeak = new List<Language>();
            Empty.LanguagesSpeak.Add(new Language());
            Empty.LanguagesUndersatand = new List<Language>();
            Empty.LanguagesUndersatand.Add(new Language());
            Empty.Telepathy = 0;
            Empty.Challenge = new Challenge();
            Empty.SpecialTraits = new List<SpecialTrait>();
            Empty.Actions = new List<Models.Characters.Action>();
            Empty.LegendaryActions = new List<Models.Characters.Action>();
            Empty.Reactions = new List<Models.Characters.Action>();

            return Empty;
        }
        


        #region PC templates

        public PC GenerateEmptyPC()
        {
            PC Empty =  new PC()
            {
                name = "Name",
                alignmentAttitude = TypeAlignAttitude.lawful,
                alignmentMorality = TypeAlignMorality.neutral,
                armorClass = new Armor(),
                level = new Challenge("1st", 0, 2),
                senses = new List<Sense>(),
                presetSenses = new List<Sense>(),
                savingThrows = new List<SavingThrow>(),
                presetSavingThrows = new List<SavingThrow>(),
                size = new Size(),
                speeds = new List<Speed>(),
                presetSpeeds = new List<Speed>(),
                vulnerabilities = new List<Damage>(),
                presetVulnerabilities = new List<Damage>(),
                immunitiesDamage = new List<Damage>(),
                presetImmunitiesDamage = new List<Damage>(),
                resistances = new List<Damage>(),
                presetResistances = new List<Damage>(),
                immunitiesCondition = new List<Condition>(),
                presetImmunitiesCondition = new List<Condition>(),
                specialTraits = new List<SpecialTrait>(),
                presetSpecialTraits = new List<SpecialTrait>(),
                hitPoint = new HitPoint(),
                actions = new List<Models.Characters.Action>(),
                presetActions = new List<Models.Characters.Action>(),
                languagesSpeak = new List<Language>(),
                presetLanguagesSpeak = new List<Language>(),
                languagesUndersatand = new List<Language>(),
                presetLanguagesUndersatand = new List<Language>(),
                skills = new List<Skill>(),
                presetSkills = new List<Skill>(),
                abilitiesScores = new List<AbilityScore>() {
                    new AbilityScore() { Name = "Strenght", ShortName = "Str", Value = 10, ModValue = 0 },
                    new AbilityScore() { Name = "Dexterity", ShortName = "Dex", Value = 10, ModValue = 4 },
                    new AbilityScore() { Name = "Constitution", ShortName = "Con", Value = 10, ModValue = 4 },
                    new AbilityScore() { Name = "Intelligence", ShortName = "Int", Value = 10, ModValue = 3 },
                    new AbilityScore() { Name = "Wisdom", ShortName = "Wis", Value = 10, ModValue = 0, SavingThrow = true },
                    new AbilityScore() { Name = "Charisma", ShortName = "Cha", Value = 10, ModValue = 0, SavingThrow = true }
                }
            };

            return Empty;
        }

        public PC LoadRace(PC pc, Race race)
        {
            switch (race)
            {
                case Race.HillDwarf:
                    pc.abilitiesScores.Find(con => con.ShortName == "Str").Bonus = 0;
                    pc.abilitiesScores.Find(con => con.ShortName == "Dex").Bonus = 0;
                    pc.abilitiesScores.Find(con => con.ShortName == "Con").Bonus = 2;
                    pc.abilitiesScores.Find(con => con.ShortName == "Int").Bonus = 0;
                    pc.abilitiesScores.Find(con => con.ShortName == "Wis").Bonus = 1;
                    pc.abilitiesScores.Find(con => con.ShortName == "Cha").Bonus = 0;
                    pc.size = new Size() { TypeSize = TypeSize.Medium, Space = 10 };
                    pc.presetSenses = new List<Sense>() { new Sense() { TypeSense = TypeSense.Darkvision, range = 60 } };
                    pc.presetSpeeds = new List<Speed>() { new Speed() { TypeSpeed = TypeSpeed.Base, Speedft = 25 } };
                    pc.presetLanguagesSpeak = new List<Language>() { new Language() { LanguageName = LanguageName.Common }, new Language() { LanguageName = LanguageName.Dwarvish } };
                    pc.presetResistances = new List<Damage>() { new Damage() { TypeDamage = TypeDamage.Poison } };
                    pc.presetSpecialTraits.Add(new SpecialTrait() { Name = "Hardy", Description = "Your speed is not reduced by wearing heavy armor." });
                    pc.presetSpecialTraits.Add(new SpecialTrait() { Name = "Dwarven Resilience", Description = "You have advantage on saving throws against poison, and you have resistance against poison damage." });
                    pc.presetSpecialTraits.Add(new SpecialTrait() { Name = "Dwarven Combat Training", Description = "You have proficiency with the battleaxe, handaxe, throwinghammer, and warhammer." });
                    pc.presetSpecialTraits.Add(new SpecialTrait() { Name = "Tool Proficiency", Description = "You gain proficiency with the artisan's tools of your choice: smith's tools, brewer's supplies, or mason's tools." });
                    pc.presetSpecialTraits.Add(new SpecialTrait() { Name = "Stonecunning", Description = "Whenever you make an Intelligence (History) check related to the origin of stonework, you are considered proficient in the History skill and add double your proficiency Bonus to the check, instead of your normal proficiency Bonus." });
                    pc.presetSpecialTraits.Add(new SpecialTrait() { Name = "Dwarven Toughness", Description = "Your hit point maximum increases by 1, and it increases by 1 every time you gain a level." });
                    break;
                case Race.HighElf:
                    pc.abilitiesScores.Find(con => con.ShortName == "Str").Bonus = 0;
                    pc.abilitiesScores.Find(con => con.ShortName == "Dex").Bonus = 2;
                    pc.abilitiesScores.Find(con => con.ShortName == "Con").Bonus = 0;
                    pc.abilitiesScores.Find(con => con.ShortName == "Int").Bonus = 1;
                    pc.abilitiesScores.Find(con => con.ShortName == "Wis").Bonus = 0;
                    pc.abilitiesScores.Find(con => con.ShortName == "Cha").Bonus = 0;
                    pc.size = new Size() { TypeSize = TypeSize.Medium, Space = 10 };
                    pc.presetSenses = new List<Sense>() { new Sense() { TypeSense = TypeSense.Darkvision, range = 60 } };
                    pc.presetSpeeds = new List<Speed>() { new Speed() { TypeSpeed = TypeSpeed.Base, Speedft = 30 } };
                    pc.presetLanguagesSpeak = new List<Language>() { new Language() { LanguageName = LanguageName.Common }, new Language() { LanguageName = LanguageName.Elvish } };
                    pc.presetResistances = new List<Damage>() { new Damage() { TypeDamage = TypeDamage.Poison } };
                    pc.presetSpecialTraits.Add(new SpecialTrait() { Name = "Keen Senses", Description = "You have proficiency in the Perception skill." });
                    pc.presetSpecialTraits.Add(new SpecialTrait() { Name = "Fey Ancestry", Description = "You have advantage on saving throws against being charmed, and magic can't put you to sleep." });
                    pc.presetSpecialTraits.Add(new SpecialTrait() { Name = "Trance", Description = "Elves don't need to sleep. Instead, they meditate deeply, remaining semiconscious, for 4 hours a day. (The Common word for such meditation is 'trance.') While meditating, you can dream after a fashion; such dreams are actually mental exercises that have become reflexive through years of practice. After resting in this way, you gain the same benefit that a human does from 8 hours of sleep." });
                    pc.presetSpecialTraits.Add(new SpecialTrait() { Name = "Elf Weapon Training", Description = "You have proficiency with the longsword, shortsword, shortbow, and longbow." });
                    pc.presetSpecialTraits.Add(new SpecialTrait() { Name = "Cantrip", Description = "You know one cantrip of your choice from the wizard spell list. Intelligence is your spellcasting ability for it." });
                    pc.presetSpecialTraits.Add(new SpecialTrait() { Name = "Extra Language", Description = "You can speak, read, and write one extra language of your choice." });
                    break;
                case Race.Human:
                    pc.abilitiesScores.Find(con => con.ShortName == "Str").Bonus = 1;
                    pc.abilitiesScores.Find(con => con.ShortName == "Dex").Bonus = 1;
                    pc.abilitiesScores.Find(con => con.ShortName == "Con").Bonus = 1;
                    pc.abilitiesScores.Find(con => con.ShortName == "Int").Bonus = 1;
                    pc.abilitiesScores.Find(con => con.ShortName == "Wis").Bonus = 1;
                    pc.abilitiesScores.Find(con => con.ShortName == "Cha").Bonus = 1;
                    pc.size = new Size() { TypeSize = TypeSize.Medium, Space = 10 };
                    pc.presetSpeeds = new List<Speed>() { new Speed() { TypeSpeed = TypeSpeed.Base, Speedft = 25 } };
                    pc.presetLanguagesSpeak = new List<Language>() { new Language() { LanguageName = LanguageName.Common } };
                    pc.presetSpecialTraits.Add(new SpecialTrait() { Name = "Additional Language", Description = "You can speak, read, and write one extra language of your choice." });
                    break;
            }
            return pc;
        }

        public PC LoadBackground(PC pc, Background background)
        {
            switch (background)
            {
                case Background.Acolyte:
                    pc.presetSkills = new List<Skill>() {
                        new Skill() { SkillName = SkillName.Insight, Total = 0, Value = 0, Bonus = 0 },
                        new Skill() { SkillName = SkillName.Religion, Total = 0, Value = 0, Bonus = 0 }
                    };

                    pc.presetSpecialTraits.Add(new SpecialTrait() { Name = "Languages", Description = "Two of your choice." });
                    pc.presetSpecialTraits.Add(new SpecialTrait() { Name = "Shelter of the Faithful", Description = "As an acolyte, you command the respect of those who share your faith, and you can perform the religious ceremonies o f your deity.You and your adventuring companions can expect to receive free healing and care at a temple, shrine, or other established presence o f your faith, though you must provide any material components needed for spells.Those w ho share your religion will support you(but only you) at a modest lifestyle.You might also have ties to a specific temple dedicated to your chosen deity or pantheon, and you have a residence there.This could be the temple where you used to serve, if you remain on good terms with it, or a temple where you have found a new home.While near your temple, you can call upon the priests for assistance, provided the assistance you ask for is not hazardous and you remain in good standing with your temple." });
                    break;
                case Background.Noble:
                    pc.presetSkills = new List<Skill>() {
                        new Skill() { SkillName = SkillName.History, Total = 0, Value = 0, Bonus = 0 },
                        new Skill() { SkillName = SkillName.Persuasion, Total = 0, Value = 0, Bonus = 0 }
                    };
                    pc.presetSpecialTraits.Add(new SpecialTrait() { Name = "Proficiencies", Description = "One type of gaming set." });
                    pc.presetSpecialTraits.Add(new SpecialTrait() { Name = "Languages", Description = "One of your choice." });
                    pc.presetSpecialTraits.Add(new SpecialTrait() { Name = "Position of Privilege", Description = "Thanks to your noble birth, people are inclined to think the best of you.You are w elcome in high society, and people assume you have the right to be wherever you are.The common folk make every effort to accommodate you and avoid your displeasure, and other people of high birth treat you as a member o f the same social sphere.You can secure an audience with a local noble if you need to." });
                    break;
                case Background.Soldier:
                    pc.presetSkills = new List<Skill>() {
                        new Skill() { SkillName = SkillName.Athletics, Total = 0, Value = 0, Bonus = 0 },
                        new Skill() { SkillName = SkillName.Intimidation, Total = 0, Value = 0, Bonus = 0 }
                    };
                    pc.presetSpecialTraits.Add(new SpecialTrait() { Name = "Proficiencies", Description = "One type of gaming set, vehicles (land)." });
                    pc.presetSpecialTraits.Add(new SpecialTrait() { Name = "Languages", Description = "One of your choice." });
                    pc.presetSpecialTraits.Add(new SpecialTrait() { Name = "Military Rank", Description = "You have a military rank from your career as a soldier. Soldiers loyal to your former military organization still recognize your authority and influence, and they defer to you if they are o f a lower rank. You can invoke your rank to exert influence over other soldiers and requisition simple equipment or horses for temporary use. You can also usually gain access to friendly military encampments and fortresses where your rank is recognized." });
                    break;
            }
            return pc;
        }

        public PC LoadClass(PC pc, _Class _class, int level)
        {
            switch (_class)
            {
                case _Class.Cleric:
                    pc.hitPoint = new HitPoint()
                    {
                        HitPointsAVG = 5,
                        Die = 1,
                        TypeDie = TypeDie.d8,
                        BonusCon = 0,
                        BonusMultiplied = 0
                    };
                    pc.presetSavingThrows = new List<SavingThrow>()
                    {
                        new SavingThrow() { ModName = "Wis", Value = 0 },
                        new SavingThrow() { ModName = "Cha", Value = 0 }
                    };
                    pc.abilitiesScores.Find(con => con.ShortName == "Str").SavingThrow = false;
                    pc.abilitiesScores.Find(con => con.ShortName == "Dex").SavingThrow = false;
                    pc.abilitiesScores.Find(con => con.ShortName == "Con").SavingThrow = false;
                    pc.abilitiesScores.Find(con => con.ShortName == "Int").SavingThrow = false;
                    pc.abilitiesScores.Find(con => con.ShortName == "Wis").SavingThrow = true;
                    pc.abilitiesScores.Find(con => con.ShortName == "Cha").SavingThrow = true;
                    pc.armorClass = new Armor()
                    {
                        Total = 16,
                        Name = ArmorName.ScaleMail,
                        BaseArmor = 14,
                        Bonus = 0,
                        MaxDexMod = 2,
                        Shield = true,
                        Stealth = false
                    };
                    pc.presetActions.Add(
                       new Models.Characters.Action()
                       {

                           Name = "Mace",
                           Limited = "",
                           TypeAction = TypeAction.MeleeAttack,
                           AbilityAction = "Str",
                           TotalBonusAttack = 8,
                           Range = 5,
                           Target = "one creature",
                           Damage = 7,
                           HitDie = 1,
                           Die = TypeDie.d6,
                           AbilityDamage = 4,
                           BonusDamage = 0,
                           TypeDamage = TypeDamage.Bludgeoning,
                           Description = ""
                       });
                    pc.presetActions.Add(
                      new Models.Characters.Action()
                      {
                          Name = "Light Crossbow",
                          Limited = "",
                          TypeAction = TypeAction.RangeAttack,
                          AbilityAction = "Str",
                          TotalBonusAttack = 8,
                          Range = 0,
                          Min = 80,
                          Max = 320,
                          Target = "one creature",
                          Damage = 5,
                          HitDie = 1,
                          Die = TypeDie.d8,
                          AbilityDamage = 5,
                          BonusDamage = 0,
                          TypeDamage = TypeDamage.Piercing,
                          Description = "ammunition, loading, two handed."
                      });
                    break;
                case _Class.Rogue:
                    pc.hitPoint = new HitPoint()
                    {
                        HitPointsAVG = 5,
                        Die = 1,
                        TypeDie = TypeDie.d8,
                        BonusCon = 0,
                        BonusMultiplied = 0
                    };
                    pc.presetSavingThrows = new List<SavingThrow>()
                    {
                        new SavingThrow() { ModName = "Dex", Value = 0 },
                        new SavingThrow() { ModName = "Int", Value = 0 }
                    };
                    pc.abilitiesScores.Find(con => con.ShortName == "Str").SavingThrow = false;
                    pc.abilitiesScores.Find(con => con.ShortName == "Dex").SavingThrow = true;
                    pc.abilitiesScores.Find(con => con.ShortName == "Con").SavingThrow = false;
                    pc.abilitiesScores.Find(con => con.ShortName == "Int").SavingThrow = true;
                    pc.abilitiesScores.Find(con => con.ShortName == "Wis").SavingThrow = false;
                    pc.abilitiesScores.Find(con => con.ShortName == "Cha").SavingThrow = false;
                    pc.armorClass = new Armor()
                    {
                        Total = 18,
                        Name = ArmorName.Leather,
                        BaseArmor = 16,
                        Bonus = 0,
                        MaxDexMod = 2,
                        Shield = true,
                        Stealth = false
                    };
                    pc.presetSpecialTraits.Add(new SpecialTrait() { Name = "Proficiencies", Description = "Light armor; Simple weapons, hand crossbows, longswords, rapiers, shortswords; Thieves’ tools." });
                    pc.presetSpecialTraits.Add(new SpecialTrait() { Name = "Skills", Description = "Choose four from Acrobatics, Athletics, Deception. Insight, Intimidation, Investigation, Perception, Performance. Persuasion, Sleight of Hand, and Stealth." });
                    pc.presetActions.Add(
                        new Models.Characters.Action()
                        {
                            Name = "Shortsword",
                            Limited = "",
                            TypeAction = TypeAction.MeleeAttack,
                            AbilityAction = "Str",
                            TotalBonusAttack = 8,
                            Range = 5,
                            Target = "one creature",
                            Damage = 7,
                            HitDie = 1,
                            Die = TypeDie.d8,
                            AbilityDamage = 4,
                            BonusDamage = 0,
                            TypeDamage = TypeDamage.Slashing,
                            Description = "versatile (1d10)"
                        }
                    );
                    pc.presetActions.Add(
                        new Models.Characters.Action()
                        {
                            Name = "Shortbow",
                            Limited = "",
                            TypeAction = TypeAction.RangeAttack,
                            AbilityAction = "Str",
                            TotalBonusAttack = 8,
                            Range = 0,
                            Min = 80,
                            Max = 320,
                            Target = "one creature",
                            Damage = 5,
                            HitDie = 1,
                            Die = TypeDie.d8,
                            AbilityDamage = 5,
                            BonusDamage = 0,
                            TypeDamage = TypeDamage.Piercing,
                            Description = "ammunition, loading, two handed."
                        }
                     );
                    break;
                case _Class.Fighter:
                    pc.hitPoint = new HitPoint()
                    {
                        HitPointsAVG = 6,
                        Die = 1,
                        TypeDie = TypeDie.d10,
                        BonusCon = 0,
                        BonusMultiplied = 0
                    };
                    pc.presetSavingThrows = new List<SavingThrow>()
                    {
                        new SavingThrow() { ModName = "Str", Value = 0 },
                        new SavingThrow() { ModName = "Con", Value = 0 }

                    };
                    pc.abilitiesScores.Find(con => con.ShortName == "Str").SavingThrow = true;
                    pc.abilitiesScores.Find(con => con.ShortName == "Dex").SavingThrow = false;
                    pc.abilitiesScores.Find(con => con.ShortName == "Con").SavingThrow = true;
                    pc.abilitiesScores.Find(con => con.ShortName == "Int").SavingThrow = false;
                    pc.abilitiesScores.Find(con => con.ShortName == "Wis").SavingThrow = false;
                    pc.abilitiesScores.Find(con => con.ShortName == "Cha").SavingThrow = false;
                    pc.armorClass = new Armor()
                    {
                        Total = 18,
                        Name = ArmorName.ChainMail,
                        BaseArmor = 16,
                        Bonus = 0,
                        MaxDexMod = 2,
                        Shield = true,
                        Stealth = false
                    };
                    pc.presetSpecialTraits.Add(new SpecialTrait() { Name = "Proficiencies", Description = "All armor, shields; Simple weapons, martial weapons." });
                    pc.presetSpecialTraits.Add(new SpecialTrait() { Name = "Skills", Description = " Choose two skills from Acrobatics, Animal Handling, Athletics, History, Insight, Intimidation, Perception, and Survival." });
                    pc.presetActions.Add(
                        new Models.Characters.Action()
                        {
                            Name = "Longsword",
                            Limited = "",
                            TypeAction = TypeAction.MeleeAttack,
                            AbilityAction = "Str",
                            TotalBonusAttack = 8,
                            Range = 5,
                            Target = "one creature",
                            Damage = 7,
                            HitDie = 1,
                            Die = TypeDie.d8,
                            AbilityDamage = 4,
                            BonusDamage = 0,
                            TypeDamage = TypeDamage.Slashing,
                            Description = "versatile (1d10)"
                        }
                    );
                    pc.presetActions.Add(
                        new Models.Characters.Action()
                        {
                            Name = "Light Crossbow",
                            Limited = "",
                            TypeAction = TypeAction.RangeAttack,
                            AbilityAction = "Str",
                            TotalBonusAttack = 8,
                            Range = 0,
                            Min = 80,
                            Max = 320,
                            Target = "one creature",
                            Damage = 5,
                            HitDie = 1,
                            Die = TypeDie.d8,
                            AbilityDamage = 5,
                            BonusDamage = 0,
                            TypeDamage = TypeDamage.Piercing,
                            Description = "ammunition, loading, two handed."
                        }
                     );
                    break;
                case _Class.Wizard:
                    pc.hitPoint = new HitPoint()
                    {
                        HitPointsAVG = 4,
                        Die = 1,
                        TypeDie = TypeDie.d6,
                        BonusCon = 0,
                        BonusMultiplied = 0
                    };
                    pc.presetSavingThrows = new List<SavingThrow>()
                    {
                        new SavingThrow() { ModName = "Int", Value = 0 },
                        new SavingThrow() { ModName = "Wis", Value = 0 }

                    };
                    pc.abilitiesScores.Find(con => con.ShortName == "Str").SavingThrow = false;
                    pc.abilitiesScores.Find(con => con.ShortName == "Dex").SavingThrow = false;
                    pc.abilitiesScores.Find(con => con.ShortName == "Con").SavingThrow = false;
                    pc.abilitiesScores.Find(con => con.ShortName == "Int").SavingThrow = true;
                    pc.abilitiesScores.Find(con => con.ShortName == "Wis").SavingThrow = true;
                    pc.abilitiesScores.Find(con => con.ShortName == "Cha").SavingThrow = false;
                    pc.armorClass = new Armor()
                    {
                        Total = 10,
                        Name = ArmorName.NaturalArmor,
                        BaseArmor = 10,
                        Bonus = 0,
                        MaxDexMod = 2,
                        Shield = false,
                        Stealth = false
                    };
                    pc.presetSpecialTraits.Add(new SpecialTrait() { Name = "Proficiencies", Description = "Daggers, darts, slings, quarterstaffs, light crossbows." });
                    pc.presetSpecialTraits.Add(new SpecialTrait() { Name = "Skills", Description = "Choose two from Arcana, History, Insight, Investigation, Medicine, and Religion." });
                    pc.presetActions.Add(
                        new Models.Characters.Action()
                        {
                            Name = "Longsword",
                            Limited = "",
                            TypeAction = TypeAction.MeleeAttack,
                            AbilityAction = "Str",
                            TotalBonusAttack = 8,
                            Range = 5,
                            Target = "one creature",
                            Damage = 7,
                            HitDie = 1,
                            Die = TypeDie.d8,
                            AbilityDamage = 4,
                            BonusDamage = 0,
                            TypeDamage = TypeDamage.Slashing,
                            Description = "versatile (1d10)"
                        }
                    );
                    pc.presetActions.Add(
                        new Models.Characters.Action()
                        {
                            Name = "Light Crossbow",
                            Limited = "",
                            TypeAction = TypeAction.RangeAttack,
                            AbilityAction = "Str",
                            TotalBonusAttack = 8,
                            Range = 0,
                            Min = 80,
                            Max = 320,
                            Target = "one creature",
                            Damage = 5,
                            HitDie = 1,
                            Die = TypeDie.d8,
                            AbilityDamage = 5,
                            BonusDamage = 0,
                            TypeDamage = TypeDamage.Piercing,
                            Description = "ammunition, loading, two handed."
                        }
                     );
                    break;


            }
            return pc;
        }

        #endregion


        public Combat GenerateEmptyCombat()
        {
            var Empty = new Combat();
            Empty.NPCs = new List<NPCCombat>();
            Empty.PCs = new List<PCCombat>();
            return Empty;
        }



    }

    



}