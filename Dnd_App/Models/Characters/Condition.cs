using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Dnd_App.Models.Enum;

namespace Dnd_App.Models.Characters
{
    [Table("Condition")]
    public class Condition : IEqualityComparer<Condition>
    {
        [Key]
        public int id { set; get; }
        public TypeCondition TypeCondition { set; get; }

        public Condition() { }

        public bool Equals(Condition x, Condition y)
        {
            if (x.TypeCondition == y.TypeCondition)
                return true;
            else
                return false;
        }

        public int GetHashCode(Condition obj)
        {
            if (obj == null)
            {
                return 0;
            }
            return obj.TypeCondition.GetHashCode();
        }
    }
}