using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dnd_App.Models.Characters
{
    [Table("AbilityScore")]
    public class AbilityScore
    {
        [Key]
        public int Id { set; get; }
        public string Name { set; get; }
        public string ShortName { set; get; }
        public int Value { set; get; }
        public int ModValue { set; get; }
        public Boolean SavingThrow { set; get; }

        public int InputValue { set; get; }
        public int Bonus { set; get; }
        


        public AbilityScore()
        {
        }

        public Entitites.AbilityScore ToEntity()
        {
            return Mapper.Map<Entitites.AbilityScore>(this);
        }
    }
}