using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dnd_App.Models.Combat
{
    public class NPCCombat
    {
        [Key]
        public long Id { set; get; }

        public long IdCombat { set; get; }
        public long IdUser { set; get; }
        public long IdNPC { set; get; }

        public int Initiative { set; get; }
    }
}