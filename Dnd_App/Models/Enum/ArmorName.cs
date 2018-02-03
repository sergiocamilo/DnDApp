using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Dnd_App.Models.Enum
{
    public enum ArmorName
    {
        [Description("Natural Armor")]
        NaturalArmor,
        Padded,
        Leather,
        [Description("Studded Leather")]
        StuddedLeather,
        Hide,
        [Description("Chain Shirt")]
        ChainShirt,
        [Description("Scale Mail")]
        ScaleMail,
        Breastplate,
        [Description("Half Plate")]
        HalfPlate,
        RingMail,
        [Description("Chain Mail")]
        ChainMail,
        Splint,
        Plate
    }
}