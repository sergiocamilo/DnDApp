using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dnd_App.Utils
{
    public class FilterCombat
    {
        public Boolean npc { get; set; }
        public Boolean pc { get; set; }
        public String search { get; set; }

        public FilterCombat()
        {
            this.npc = true;
            this.pc = true;
            this.search = "";
        }

        public void All()
        {
            this.npc = true;
            this.pc = true;
        }

        public void OnlyNpc()
        {
            this.npc = true;
            this.pc = false;
        }

        public void OnlyPc()
        {
            this.npc = false;
            this.pc = true;
        }
    }

}