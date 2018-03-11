using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Dnd_App.Models.Enum;

namespace Dnd_App.Models.Characters
{
    [Table("Armor")]
    public class Armor
    {
        [Key]
        public int Id { set; get; }
        public ArmorName Name { set; get; }
        public int BaseArmor { set; get; }
        public int Bonus { set; get; }
        public int MaxDexMod { set; get; }
        public int Total { set; get; }

        public Boolean Stealth { set; get; }
        public Boolean Shield { set; get; }


        public void RecalculateAC()
        {
            this.RecalculateBase();

            if (Name == ArmorName.Hide || Name == ArmorName.ChainShirt || Name == ArmorName.ScaleMail ||
                Name == ArmorName.Breastplate || Name == ArmorName.HalfPlate)
            {
                if (Bonus > 2)
                {
                    this.Bonus = 2;
                }
            }

            this.Total = this.BaseArmor + this.Bonus;
            if (this.Shield)
            {
                this.Total += 2;
            }
        }

        public void RecalculateBase()
        {
            switch (this.Name)
            {
                case ArmorName.NaturalArmor:
                    this.BaseArmor = 10;
                    break;
                case ArmorName.Padded:
                    this.BaseArmor = 11;
                    break;
                case ArmorName.Leather:
                    this.BaseArmor = 11;
                    break;
                case ArmorName.StuddedLeather:
                    this.BaseArmor = 12;
                    break;
                case ArmorName.Hide:
                    this.BaseArmor = 12;
                    break;
                case ArmorName.ChainShirt:
                    this.BaseArmor = 13;
                    break;
                case ArmorName.ScaleMail:
                    this.BaseArmor = 14;
                    break;
                case ArmorName.Breastplate:
                    this.BaseArmor = 14;
                    break;
                case ArmorName.HalfPlate:
                    this.BaseArmor = 15;
                    break;
                case ArmorName.RingMail:
                    this.BaseArmor = 14;
                    break;
                case ArmorName.ChainMail:
                    this.BaseArmor = 16;
                    break;
                case ArmorName.Splint:
                    this.BaseArmor = 17;
                    break;
                case ArmorName.Plate:
                    this.BaseArmor = 18;
                    break;
                default:
                    break;
            }

        }



    }
}