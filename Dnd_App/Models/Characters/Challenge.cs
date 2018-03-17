using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dnd_App.Models.Characters
{
    [Table("Challenge")]
    public class Challenge
    {
        [Key]
        public int ID { set; get; }
        public String Value { set; get; }
        public int XP { set; get; }
        public int ProficiencyBonus { set; get; }

        public Challenge()
        {

        }

        public Challenge(String value, int xp, int proficiencyBonus)
        {
            this.Value = value;
            this.XP = xp;
            this.ProficiencyBonus = proficiencyBonus;
        }



        public List<Challenge> ChallengeList()
        {
            var challengeList = new List<Challenge>();

            challengeList.Add(new Challenge("0", 0, 2));
            challengeList.Add(new Challenge("0", 10, 2));
            challengeList.Add(new Challenge("1/8", 25, 2));
            challengeList.Add(new Challenge("1/4", 50, 2));
            challengeList.Add(new Challenge("1/2", 100, 2));
            challengeList.Add(new Challenge("1", 200, 2));
            challengeList.Add(new Challenge("2", 450, 2));
            challengeList.Add(new Challenge("3", 700, 2));
            challengeList.Add(new Challenge("4", 1100, 2));
            challengeList.Add(new Challenge("5", 1800, 3));
            challengeList.Add(new Challenge("6", 2300, 3));
            challengeList.Add(new Challenge("7", 2900, 3));
            challengeList.Add(new Challenge("8", 3900, 3));
            challengeList.Add(new Challenge("9", 5000, 4));
            challengeList.Add(new Challenge("10", 5900, 4));
            challengeList.Add(new Challenge("11", 7200, 4));
            challengeList.Add(new Challenge("12", 8400, 4));
            challengeList.Add(new Challenge("13", 10000, 5));
            challengeList.Add(new Challenge("14", 11500, 5));
            challengeList.Add(new Challenge("15", 13000, 5));
            challengeList.Add(new Challenge("16", 15000, 5));
            challengeList.Add(new Challenge("17", 18000, 6));
            challengeList.Add(new Challenge("18", 20000, 6));
            challengeList.Add(new Challenge("19", 22000, 6));
            challengeList.Add(new Challenge("20", 25000, 6));
            challengeList.Add(new Challenge("21", 33000, 7));
            challengeList.Add(new Challenge("22", 41000, 7));
            challengeList.Add(new Challenge("23", 50000, 7));
            challengeList.Add(new Challenge("24", 62000, 7));
            challengeList.Add(new Challenge("25", 75000, 8));
            challengeList.Add(new Challenge("26", 90000, 8));
            challengeList.Add(new Challenge("27", 105000, 8));
            challengeList.Add(new Challenge("28", 120000, 8));
            challengeList.Add(new Challenge("29", 135000, 9));
            challengeList.Add(new Challenge("30", 155000, 9));


            return challengeList;
        }


        public List<Challenge> LevelList()
        {
            var levelList = new List<Challenge>();

            levelList.Add(new Challenge("1st", 0, 2));
            levelList.Add(new Challenge("2nd", 300, 2));
            levelList.Add(new Challenge("3rd", 900, 2));
            levelList.Add(new Challenge("4th", 2700, 2));
            levelList.Add(new Challenge("5th", 6500, 3));
            levelList.Add(new Challenge("6th", 14000, 3));
            levelList.Add(new Challenge("7th", 23000, 3));
            levelList.Add(new Challenge("8th", 34000, 3));
            levelList.Add(new Challenge("9th", 48000, 4));
            levelList.Add(new Challenge("10th", 64000, 4));
            levelList.Add(new Challenge("11th", 85000, 4));
            levelList.Add(new Challenge("12th", 100000, 4));
            levelList.Add(new Challenge("13th", 120000, 5));
            levelList.Add(new Challenge("14th", 140000, 5));
            levelList.Add(new Challenge("15th", 165000, 5));
            levelList.Add(new Challenge("16th", 195000, 5));
            levelList.Add(new Challenge("17th", 225000, 6));
            levelList.Add(new Challenge("18th", 265000, 6));
            levelList.Add(new Challenge("19th", 305000, 6));
            levelList.Add(new Challenge("20th", 355000, 6));

            return levelList;
        }


        public Entitites.Challenge ToEntity()
        {
            return Mapper.Map<Entitites.Challenge>(this);
        }

    }
}