using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dnd_App.Models.Enum;

namespace Dnd_App.Models
{
    public class User
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public Boolean IsActive { get; set; }
        public string Token { get; set; }

        //Colections
        //public Dictionary<int, NPC> Npcs { get; set; }
        //public Dictionary<int, NPC> PCs { get; set; }

        public Boolean LogIn()
        {
            if (Utils.AuxDB.Instance.User.UserName == this.UserName &&
                Utils.AuxDB.Instance.User.Password == this.Password)
            {
                return true;
            }
            return false;
        }

        #region CRUD
        public Boolean Create()
        {
            return true;
        }

        public Boolean Read()
        {
            return true;
        }

        public Boolean Read(String Username)
        {
            return true;
        }
        

        public Boolean Update()
        {
            return true;
        }

        public Boolean Delete()
        {
            return true;
        }
        #endregion

        internal bool RegistryUser()
        {
            throw new NotImplementedException();
        }

        internal bool VerifyUser(string rPassword)
        {
            throw new NotImplementedException();
        }






    }
}