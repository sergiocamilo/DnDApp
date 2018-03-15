using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dnd_App.Models.Enum;
using Dnd_App.Models.Characters;
using System.Data.Entity;
using Dnd_App.Entitites;

namespace Dnd_App.Models
{
    public class User
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        //public string Password { get; set; }
        public Role Role { get; set; }
        public Boolean IsActive { get; set; }
        public string Token { get; set; }

        //Colections
        public Dictionary<int, NPC> Npcs { get; set; }
        public Dictionary<int, PC> PCs { get; set; }

        public Boolean LogIn(String UserNameIn, String PassIn)
        {
            try
            {
                using (var DB = new DnDAppDBEntities())
                {
                    String pass = DB.User.Where(u => u.username == UserNameIn).First().password;
                    if (pass != null)
                    {
                        return Utils.Security.CheckPassBCrypt(PassIn, pass);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        #region CRUD
        public Boolean Create(String Pass)
        {
            try
            {
                using (var DB = new DnDAppDBEntities())
                {
                    var UserEntity = new Entitites.User()
                    {
                        username = this.UserName,
                        email = this.Email,
                        password = Utils.Security.EncryptPassBCrypt(Pass),
                        role = 1,
                        isActive = false,
                        token = "default_token"
                    };

                    DB.User.Add(UserEntity);
                    DB.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean Read()
        {
            try
            {
                using (var DB = new DnDAppDBEntities())
                {
                    var UserEntity = DB.User.Where(u => u.username == this.UserName).First();
                    if (UserEntity != null)
                    {
                        this.UserName = UserEntity.username;
                        this.Role = (Role) UserEntity.role;
                        this.Email = UserEntity.email;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
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
        
    }
}