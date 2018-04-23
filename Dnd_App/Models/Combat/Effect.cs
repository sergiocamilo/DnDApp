using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dnd_App.Models.Combat
{
    public class Effect
    {
        public Enum.TypeCondition Name { get; set; }
        public int Turn { get; set; }

    }
}