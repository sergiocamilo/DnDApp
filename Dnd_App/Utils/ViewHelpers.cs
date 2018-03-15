using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dnd_App.Models;
using Dnd_App.Entitites;

namespace Dnd_App.Utils
{
    public class ViewHelpers
    {
        
        public List<Models.User> AllUsernames()
        {
            var UsernamesList = new List<Models.User>();
            try
            {
                using (var DB = new DnDAppDBEntities())
                {
                    foreach (var u in DB.User)
                    {
                        UsernamesList.Add(new Models.User() {
                            Id = u.id,
                            UserName = u.username
                        });
                    }
                    return UsernamesList;
                }
            }
            catch (Exception)
            {
                return UsernamesList;
            }
        }

    }
}