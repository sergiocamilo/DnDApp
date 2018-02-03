using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Dnd_App.Models.Enum
{
    public enum LanguageName
    {
        Common,
        Dwarvish,
        Elvish,
        Giant,
        Gnomish,
        Goblin,
        Halfing,
        Orc,
        Abyssal,
        Celestial,
        Draconic,
        [Description("Deep Speech")]
        DeepSpeech,
        Infernal,
        Primordial,
        Sylvan,
        Undercommon
    }
}