using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dnd_App.Models.Enum;

namespace Dnd_App.Models.Characters
{
    //[Table("TypeHitDie")]
    public class TypeHitDie
    {
        //[Key]
        public int id { set; get; }

        public const double d4 = 2.5;
        public const double d6 = 3.5;
        public const double d8 = 4.5;
        public const double d10 = 5.5;
        public const double d12 = 6.5;
        public const double d20 = 10.5;

        public TypeHitDie() { }

        public double GetValueDie(TypeDie td)
        {
            switch (td)
            {
                case TypeDie.d4:
                    return d4;
                case TypeDie.d6:
                    return d6;
                case TypeDie.d8:
                    return d8;
                case TypeDie.d10:
                    return d10;
                case TypeDie.d12:
                    return d12;
                case TypeDie.d20:
                    return d20;
                default:
                    return d4;
            }

        }
    }
}