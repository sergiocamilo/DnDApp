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
    }
}
