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
    
    public partial class PC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PC()
        {
            this.PC_Speed = new HashSet<PC_Speed>();
            this.PC_AbilityScore = new HashSet<PC_AbilityScore>();
            this.PC_Action = new HashSet<PC_Action>();
            this.PC_Condition = new HashSet<PC_Condition>();
            this.PC_Damage = new HashSet<PC_Damage>();
            this.PC_Language = new HashSet<PC_Language>();
            this.PC_SavingThrow = new HashSet<PC_SavingThrow>();
            this.PC_Sense = new HashSet<PC_Sense>();
            this.PC_Skill = new HashSet<PC_Skill>();
            this.PC_SpecialTrait = new HashSet<PC_SpecialTrait>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public int alignmentMorality { get; set; }
        public int alignmentAttitude { get; set; }
        public int race { get; set; }
        public int C_class { get; set; }
        public int background { get; set; }
        public int armorBonus { get; set; }
        public int HP { get; set; }
        public int telepathy { get; set; }
        public Nullable<int> armorClass_id { get; set; }
        public Nullable<int> hitPoint_id { get; set; }
        public Nullable<int> level_id { get; set; }
        public Nullable<int> size_id { get; set; }
    
        public virtual Armor Armor { get; set; }
        public virtual Challenge Challenge { get; set; }
        public virtual HitPoint HitPoint { get; set; }
        public virtual Size Size { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PC_Speed> PC_Speed { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PC_AbilityScore> PC_AbilityScore { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PC_Action> PC_Action { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PC_Condition> PC_Condition { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PC_Damage> PC_Damage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PC_Language> PC_Language { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PC_SavingThrow> PC_SavingThrow { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PC_Sense> PC_Sense { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PC_Skill> PC_Skill { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PC_SpecialTrait> PC_SpecialTrait { get; set; }
    }
}