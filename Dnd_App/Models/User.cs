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
        public List<Models.Characters.NPC> Npcs { get; set; }
        public List<Models.Characters.PC> Pcs { get; set; }


        public Boolean LogIn(String UserNameIn, String PassIn)
        {
            try
            {
                using (var DB = new DnDAppDBEntities())
                {
                    String pass = DB.User.Where(u => u.username == UserNameIn).First().password;
                    if (pass != null)
                    {
                        if (Utils.Security.CheckPassBCrypt(PassIn, pass) &&
                            DB.User.Where(u => u.username == UserNameIn).First().isActive)
                        {
                            return true;
                        }
                        else
                        {
                            return false; //pass incorrecta o usuario no activo
                        }
                    }
                    else
                    {
                        return false; //no es usuario
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
                        role = (int) Role.User,
                        isActive = false,
                        token = Utils.Security.GenerateToken()
                    };
                    DB.User.Add(UserEntity);
                    Utils.Services.SendTokenEmail(UserEntity.email,UserEntity.token);
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
                        this.Id = UserEntity.id;
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

        public Boolean VerifyUser()
        {
            try
            {
                using (var DB = new DnDAppDBEntities())
                {
                    int CountUsername = DB.User.Where(u => u.username == this.UserName).Count();
                    int CountEmail = DB.User.Where(u => u.email == this.Email).Count();

                    if ((CountEmail+ CountUsername) == 0)
                    {
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

        public Boolean Validate()
        {
            try
            {
                using (var DB = new DnDAppDBEntities())
                {
                    var UserValidate = DB.User.Where(u => u.username == this.UserName).First();
                    if (UserValidate.token == this.Token)
                    {
                        UserValidate.isActive = true;
                        DB.SaveChanges();
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

        public Boolean LoadNPCs()
        {
            this.Npcs = new List<Characters.NPC>();
            try
            {
                Utils.Presets Preset = new Utils.Presets();
                
                using (var DB = new DnDAppDBEntities())
                {
                    var NPCIds = DB.User_NPC.Where(u => u.User_id == this.Id).Select(n => n.NPC_id).ToList();
                    foreach (var _id in NPCIds)
                    {
                        var npc = Preset.initVoidNPC();
                        npc.Id = _id;
                        npc.Select();
                        this.Npcs.Add(npc);
                    }
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }

        public Boolean AddNPC(int NPCID)
        {
            try
            {
                using (var DB = new DnDAppDBEntities())
                {
                    DB.User_NPC.Add(new User_NPC() { User_id =(int)this.Id, NPC_id = NPCID });
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public Boolean LoadPCs()
        {
            this.Pcs = new List<Characters.PC>();
            try
            {
                Utils.Presets Preset = new Utils.Presets();

                using (var DB = new DnDAppDBEntities())
                {
                    var PCIds = DB.User_PC.Where(u => u.User_id == this.Id).Select(n => n.PC_id).ToList();
                    foreach (var _id in PCIds)
                    {
                        var pc = Preset.initVoidPC();
                        pc.id = _id;
                        pc.Select();
                        this.Pcs.Add(pc);
                    }
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }

        public Boolean AddPC(int PCID)
        {
            try
            {
                using (var DB = new DnDAppDBEntities())
                {
                    DB.User_PC.Add(new User_PC() { User_id = (int)this.Id, PC_id = PCID });
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }




    }
}