using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Dnd_App.Models.Enum
{
    public enum TypeAction
    {
        [Description("Melee Attack")]
        MeleeAttack,

        [Description("Melee Weapon Attack")]
        MeleeWeaponAttack,

        [Description("Range Attack")]
        RangeAttack,

        [Description("Range Weapon Attack")]
        RangeWeaponAttack,

        [Description("Melee or Ranged Attack")]
        MeleeorRangedAttack,

        [Description("Melee or Ranged Weapon Attack")]
        MeleeorRangedWeaponAttack
    }
}