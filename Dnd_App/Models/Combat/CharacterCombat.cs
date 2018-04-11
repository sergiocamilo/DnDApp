using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dnd_App.Models.Combat
{
    public class CharacterCombat 
    {
        public int Id { get; set; }
        public int Initiative { get; set; }
        public Enum.TypeCharacter Type { get; set; }
        public int iList { get; set; }

        
    }
}