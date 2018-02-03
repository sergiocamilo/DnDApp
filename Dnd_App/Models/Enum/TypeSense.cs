using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Dnd_App.Models.Enum
{

    public enum TypeSense
    {
        Blindsight,
        Darkvision,
        Tremorsense,
        Truesight,
        [Description("passive Perception")]
        passivePerception
    }

}