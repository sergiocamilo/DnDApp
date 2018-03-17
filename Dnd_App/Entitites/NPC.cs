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
    
    public partial class NPC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NPC()
        {
            this.NPC_AbilityScore = new HashSet<NPC_AbilityScore>();
            this.NPC_Action = new HashSet<NPC_Action>();
            this.NPC_Condition = new HashSet<NPC_Condition>();
            this.NPC_Damage = new HashSet<NPC_Damage>();
            this.NPC_Language = new HashSet<NPC_Language>();
            this.NPC_SavingThrow = new HashSet<NPC_SavingThrow>();
            this.NPC_Sense = new HashSet<NPC_Sense>();
            this.NPC_Skill = new HashSet<NPC_Skill>();
            this.NPC_SpecialTrait = new HashSet<NPC_SpecialTrait>();
            this.NPC_Speed = new HashSet<NPC_Speed>();
            this.User_NPC = new HashSet<User_NPC>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public int typecreature { get; set; }
        public string tag { get; set; }
        public int alignmentMorality { get; set; }
        public int alignmentAttitude { get; set; }
        public int telepathy { get; set; }
        public Nullable<int> size_id { get; set; }
        public Nullable<int> armorclass_id { get; set; }
        public Nullable<int> hitPoint_id { get; set; }
        public Nullable<int> challenge_id { get; set; }
    
        public virtual Armor Armor { get; set; }
        public virtual Challenge Challenge { get; set; }
        public virtual HitPoint HitPoint { get; set; }
        public virtual Size Size { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NPC_AbilityScore> NPC_AbilityScore { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NPC_Action> NPC_Action { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NPC_Condition> NPC_Condition { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NPC_Damage> NPC_Damage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NPC_Language> NPC_Language { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NPC_SavingThrow> NPC_SavingThrow { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NPC_Sense> NPC_Sense { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NPC_Skill> NPC_Skill { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NPC_SpecialTrait> NPC_SpecialTrait { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NPC_Speed> NPC_Speed { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_NPC> User_NPC { get; set; }
    }
}
