using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Dnd_App.Models.Enum;
using AutoMapper;

namespace Dnd_App.Models.Characters
{
    [Table("HitPoint")]
    public class HitPoint
    {
        [Key]
        public int Id { set; get; }
        public int HitPointsAVG { set; get; }
        public int Die { set; get; }
        //public TypeHitDie TypeHitDie { set; get; }
        public int BonusCon { set; get; }
        public TypeDie TypeDie { set; get; }
        public int BonusMultiplied { set; get; }

        public HitPoint()
        {
        }

        public void RecalculateHP()
        {
            var type = new TypeHitDie().GetValueDie(this.TypeDie);
            var dieTypedie = Convert.ToDouble(Die) * type;
            this.BonusMultiplied = BonusCon * Die;
            this.HitPointsAVG = ((int)dieTypedie) + BonusMultiplied;

        }


        public Entitites.HitPoint ToEntity()
        {
            return Mapper.Map<Entitites.HitPoint>(this);
        }


    }
}