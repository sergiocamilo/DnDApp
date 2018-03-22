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



        public void AddNPC(NPC NPC, long IdUser)
        {
            try
            {
                this.NPCs.Add(new NPCCombat() {
                    IdNPC = NPC.Id,
                    IdUser = IdUser,
                    Initiative = this.CalculateInitiativeNPC(NPC)
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddPC(PC PC, long IdUser)
        {
            try
            {
                this.PCs.Add(new PCCombat()
                {
                    IdPC = PC.id,
                    IdUser = IdUser,
                    Initiative = this.CalculateInitiativePC(PC)
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

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

        public void DeleteNpc(int IdNPC)
        {
            this.NPCs.RemoveAll(npc => npc.IdNPC == IdNPC);
        }

        public void DeletePc(int IdPC)
        {
            this.PCs.RemoveAll(pc => pc.IdPC == IdPC);
        }

        public int CalculateInitiativeNPC(NPC NPC)
        {
            return (int)10.5 + NPC.AbilitiesScores.Find(con => con.ShortName == "Dex").ModValue;
        }

        public int CalculateInitiativePC(PC PC)
        {
            return (int)10.5 + PC.abilitiesScores.Find(con => con.ShortName == "Dex").ModValue;
            
        }

    }
}
