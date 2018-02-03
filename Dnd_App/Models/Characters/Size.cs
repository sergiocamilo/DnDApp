using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Dnd_App.Models.Enum;

namespace Dnd_App.Models.Characters
{
    [Table("Size")]
    public class Size
    {
        [Key]
        public int Id { set; get; }
        public TypeSize TypeSize { set; get; }
        public int Space { set; get; }
        public TypeHitDie TypeHitDie { set; get; }

        public Size(){}
    }
}