using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Dnd_App.Models.Enum;

namespace Dnd_App.Models.Characters
{
    [Table("Armor")]
    public class Armor
    {
        [Key]
        public int Id { set; get; }
        public ArmorName Name { set; get; }
        public int BaseArmor { set; get; }
        public int Bonus { set; get; }
        public int MaxDexMod { set; get; }
        public int Total { set; get; }

        public Boolean Stealth { set; get; }
        public Boolean Shield { set; get; }

    }
}