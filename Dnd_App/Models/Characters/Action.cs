using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Dnd_App.Models.Enum;

namespace Dnd_App.Models.Characters
{
    [Table("Action")]
    public class Action
    {
        [Key]
        public int Id { set; get; }

        public String Name { set; get; }
        public String Limited { set; get; }

        public TypeAction TypeAction { set; get; }
        public int BonusAttack { set; get; }//
        public int TotalBonusAttack { set; get; }//
        public String AbilityAction { set; get; }//


        //melee
        public int Range { set; get; }
        //range
        public int Min { set; get; }
        public int Max { set; get; }

        public String Target { set; get; }

        public int Damage { set; get; }
        public int HitDie { set; get; }
        public TypeDie Die { set; get; }
        public int AbilityDamage { set; get; }
        public int BonusDamage { set; get; }
        public TypeDamage TypeDamage { set; get; }

        public String Description { set; get; }
    }
}
