//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dnd_App.Entitites
{
    using System;
    using System.Collections.Generic;
    
    public partial class NPC_SavingThrow
    {
        public int id { get; set; }
        public int NPC_id { get; set; }
        public int SavingThrow_id { get; set; }
    
        public virtual NPC NPC { get; set; }
        public virtual SavingThrow SavingThrow { get; set; }
    }
}