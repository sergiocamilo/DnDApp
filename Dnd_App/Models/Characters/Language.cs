using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Dnd_App.Models.Enum;

namespace Dnd_App.Models.Characters
{
    [Table("Language")]
    public class Language : IEqualityComparer<Language>
    {
        [Key]
        public int Id { set; get; }
        public LanguageName LanguageName { set; get; }

        public Language() { }

        public bool Equals(Language x, Language y)
        {
            if (x.LanguageName == y.LanguageName)
                return true;
            else
                return false;
        }

        public int GetHashCode(Language obj)
        {
            if (obj == null)
            {
                return 0;
            }
            return obj.LanguageName.GetHashCode();
        }
    }
}