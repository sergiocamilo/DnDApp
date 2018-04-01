using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dnd_App.Models.Combat
{
    public class PCCombat
    {
        [Key]
        public long Id { set; get; }
        public long TempID { set; get; }
        public User User { set; get; }
        public Models.Characters.PC PC { set; get; }
        public int Initiative { set; get; }
    }
}