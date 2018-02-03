using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Dnd_App.Models.Enum
{
    public enum SkillName
    {
        //Strength
        Athletics,
        
        //Dexterity
        Acrobatics,
        [Description("Sleight of Hand")]
        SleightofHand,
        Stealth,
        
        //Intelligence
        Arcana,
        History,
        Investigation,
        Nature,
        Religion,
        
        //Wisdom
        [Description("Animal Handling")]
        AnimalHandling,
        Insight,
        Medicine,
        Perception,
        Survival,
        
        //Charisma
        Deception,
        Intimidation,
        Performance,
        Persuasion
    }
}