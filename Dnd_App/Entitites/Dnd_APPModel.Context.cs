﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DnDAppDBEntities : DbContext
    {
        public DnDAppDBEntities()
            : base("name=DnDAppDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<AbilityScore> AbilityScore { get; set; }
        public virtual DbSet<Action> Action { get; set; }
        public virtual DbSet<Armor> Armor { get; set; }
        public virtual DbSet<Challenge> Challenge { get; set; }
        public virtual DbSet<Condition> Condition { get; set; }
        public virtual DbSet<Damage> Damage { get; set; }
        public virtual DbSet<HitPoint> HitPoint { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<NPC> NPC { get; set; }
        public virtual DbSet<NPC_AbilityScore> NPC_AbilityScore { get; set; }
        public virtual DbSet<NPC_Action> NPC_Action { get; set; }
        public virtual DbSet<NPC_Condition> NPC_Condition { get; set; }
        public virtual DbSet<NPC_Damage> NPC_Damage { get; set; }
        public virtual DbSet<NPC_Language> NPC_Language { get; set; }
        public virtual DbSet<NPC_SavingThrow> NPC_SavingThrow { get; set; }
        public virtual DbSet<NPC_Sense> NPC_Sense { get; set; }
        public virtual DbSet<NPC_Skill> NPC_Skill { get; set; }
        public virtual DbSet<NPC_SpecialTrait> NPC_SpecialTrait { get; set; }
        public virtual DbSet<NPC_Speed> NPC_Speed { get; set; }
        public virtual DbSet<SavingThrow> SavingThrow { get; set; }
        public virtual DbSet<Sense> Sense { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<SpecialTrait> SpecialTrait { get; set; }
        public virtual DbSet<Speed> Speed { get; set; }
        public virtual DbSet<User_NPC> User_NPC { get; set; }
    }
}
