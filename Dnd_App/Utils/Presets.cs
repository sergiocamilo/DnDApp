using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dnd_App.Models.Characters;
using Dnd_App.Models.Enum;

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

    }

    



}