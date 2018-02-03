using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Dnd_App.Models.Enum;

namespace Dnd_App.Models.Characters
{
    [Table("Speed")]
    public class Speed : IEqualityComparer<Speed>
    {
        [Key]
        public int Id { set; get; }
        public TypeSpeed TypeSpeed { set; get; }
        public int Speedft { set; get; }

        public Speed()
        {
        }

        public bool Equals(Speed x, Speed y)
        {
            if (x.TypeSpeed == y.TypeSpeed)
                return true;
            else
                return false;
        }

        public int GetHashCode(Speed obj)
        {
            if (obj == null)
            {
                return 0;
            }
            return obj.TypeSpeed.GetHashCode();
        }
    }
}