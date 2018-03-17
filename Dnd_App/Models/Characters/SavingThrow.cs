using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dnd_App.Models.Characters
{
    [Table("SavingThrow")]
    public class SavingThrow : IEqualityComparer<SavingThrow>
    {
        [Key]
        public int Id { set; get; }
        public string ModName { set; get; }
        public int Value { set; get; }

        public SavingThrow()
        {

        }

        public bool Equals(SavingThrow x, SavingThrow y)
        {
            if (x.ModName == y.ModName)
                return true;
            else
                return false;
        }

        public int GetHashCode(SavingThrow obj)
        {
            if (obj == null)
            {
                return 0;
            }
            return obj.ModName.GetHashCode();
        }

        public Entitites.SavingThrow ToEntity()
        {
            return Mapper.Map<Entitites.SavingThrow>(this);
        }
    }
}