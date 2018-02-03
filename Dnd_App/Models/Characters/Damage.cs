using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Dnd_App.Models.Enum;

namespace Dnd_App.Models.Characters
{
    [Table("Damage")]
    public class Damage : IEqualityComparer<Damage>
    {
        [Key]
        public int Id { set; get; }
        public TypeDamage TypeDamage { set; get; }

        public Damage() { }

        public bool Equals(Damage x, Damage y)
        {
            if (x.TypeDamage == y.TypeDamage)
                return true;
            else
                return false;
        }

        public int GetHashCode(Damage obj)
        {
            if (obj == null)
            {
                return 0;
            }
            return obj.TypeDamage.GetHashCode();
        }
    }
}