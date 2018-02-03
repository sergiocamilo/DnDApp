using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Dnd_App.Models.Enum;

namespace Dnd_App.Models.Characters
{
    [Table("Skill")]
    public class Skill : IEqualityComparer<Skill>
    {
        [Key]
        public int Id { set; get; }
        public SkillName SkillName { set; get; }
        public int Value { set; get; }
        public int Bonus { set; get; }
        public int Total { set; get; }

        public Skill()
        {

        }

        public Dictionary<int, String> ListViewSkills()
        {
            var dic = new Dictionary<int, string>();

            dic.Add(0, "Str: Athletics");
            dic.Add(1, "Dex: Acrobatics");
            dic.Add(2, "Dex: Sleight of Hand");
            dic.Add(3, "Dex: Stealth");
            dic.Add(4, "Int: Arcana");
            dic.Add(5, "Int: History");
            dic.Add(6, "Int: Investigation");
            dic.Add(7, "Int: Nature");
            dic.Add(8, "Int: Religion");
            dic.Add(9, "Wis: Animal Handling");
            dic.Add(10, "Wis: Insight");
            dic.Add(11, "Wis: Medicine");
            dic.Add(12, "Wis: Perception");
            dic.Add(13, "Wis: Survival");
            dic.Add(14, "Cha: Deception");
            dic.Add(15, "Cha: Intimidation");
            dic.Add(16, "Cha: Performance");
            dic.Add(17, "Cha: Persuasion");

            return dic;

        }

        public bool Equals(Skill x, Skill y)
        {
            if (x.SkillName == y.SkillName)
                return true;
            else
                return false;
        }

        public int GetHashCode(Skill obj)
        {
            if (obj == null)
            {
                return 0;
            }
            return obj.SkillName.GetHashCode();
        }
    }
}