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
    
    public partial class PC_Action
    {
        public int id { get; set; }
        public int PC_id { get; set; }
        public int Action_id { get; set; }
        public bool isTemplate { get; set; }
    
        public virtual Action Action { get; set; }
        public virtual PC PC { get; set; }
    }
}
