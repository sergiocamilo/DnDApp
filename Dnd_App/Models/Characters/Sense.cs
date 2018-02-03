using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Dnd_App.Models.Enum;

namespace Dnd_App.Models.Characters
{
    [Table("Sense")]
    public class Sense : IEqualityComparer<Sense>
    {
        [Key]
        public int id { set; get; }
        public TypeSense TypeSense { set; get; }
        public int range { set; get; }

        public Sense()
        {

        }

        public bool Equals(Sense x, Sense y)
        {
            if (x.TypeSense == y.TypeSense)
                return true;
            else
                return false;
        }

        public int GetHashCode(Sense obj)
        {
            if (obj == null)
            {
                return 0;
            }
            return obj.TypeSense.GetHashCode();
        }
    }
}