using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Dnd_App.Models.Characters;

namespace Dnd_App.Models.Combat
{
    public class Combat
    {

        [Key]
        public long Id { set; get; }
        public long TempID { set; get; }
        public String Name { set; get; }

        public UserCombat DM { set; get; }

        public List<UserCombat> Participants { set; get; }
        public List<PCCombat> PCs { set; get; }
        public List<NPCCombat> NPCs { set; get; }
        public int IndexNPCs { set; get; }
        public int IndexPCs { set; get; }

        

        public void AddUserCombat(List<String> list)
        {
            var NewUserCombat = new List<UserCombat>();

            if (list == null)
                list = new List<String>();

            for (int i = 0; i < list.Count; i++)
            {
                var User = new User();
                User.UserName = list[i];
                User.Read();
                NewUserCombat.Add(new UserCombat() { User = User, RoleCombat = Enum.RoleCombat.Player });
            }

            if (list.Count <= this.Participants.Count)
            {
                this.Participants = this.Participants.Intersect(NewUserCombat, new UserCombat()).ToList();
            }
            else
            {
                NewUserCombat = NewUserCombat.Except(this.Participants, new UserCombat()).ToList();
                this.Participants.AddRange(NewUserCombat);
            }
        }
        

        public int CalculateInitiativeNPC(NPC NPC)
        {
            return (int)10.5 + NPC.AbilitiesScores.Find(con => con.ShortName == "Dex").ModValue;
        }

        public int CalculateInitiativePC(PC PC)
        {
            return (int)10.5 + PC.abilitiesScores.Find(con => con.ShortName == "Dex").ModValue;
            
        }



        #region NPC in combat

        public void InsertNPC(NPC NewNPC)
        {
            lock (new { })
            {
                NPCs.Add(new NPCCombat() {
                    NPC = NewNPC,
                    Initiative = CalculateInitiativeNPC(NewNPC),
                    TempID = IndexNPCs });
                IndexNPCs++;
            }
        }

        public NPCCombat SelectNPC(long TempID)
        {
            return NPCs.Where(npc => npc.TempID == TempID).First();
        }

        public void RemoveNPC(long TempID)
        {
            lock (new { })
            {
                NPCs.RemoveAll(npc => npc.TempID == TempID);
            }
        }

        #endregion

        #region PC in combat

        public Boolean InsertPC(PC NewPC, User User)
        {
            lock (new { })
            {
                if (PCs.Exists(pc => pc.User.UserName == User.UserName))
                {
                    return false;
                }
                else
                {
                    PCs.Add(new PCCombat()
                    {
                        PC = NewPC,
                        User = User,
                        Initiative = CalculateInitiativePC(NewPC),
                        TempID = IndexPCs
                    });
                    IndexPCs++;
                    return true;
                }
            }
        }

        public PCCombat SelectPC(long TempID)
        {
            return PCs.Where(pc => pc.TempID == TempID).First();
        }

        public void RemovePC(long TempID)
        {
            lock (new { })
            {
                PCs.RemoveAll(pc => pc.TempID == TempID);
            }
        }

        #endregion

        
    }
}
