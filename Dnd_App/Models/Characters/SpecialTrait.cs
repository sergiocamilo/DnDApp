using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dnd_App.Models.Characters
{
    [Table("SpecialTrait")]
    public class SpecialTrait
    {
        [Key]
        public int Id { set; get; }
        public String Name { set; get; }
        public String Description { set; get; }


        public Entitites.SpecialTrait ToEntity()
        {
            return Mapper.Map<Entitites.SpecialTrait>(this);
        }
    }
}