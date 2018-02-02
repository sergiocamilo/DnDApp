using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dnd_App.Util
{
    public class AuxDB
    {
        private static AuxDB instance;
        public Models.User User;

        private AuxDB()
        {
            User = new Models.User();
            User.Id = 1;
            User.UserName = "sergio";
            User.Password = "123";
            User.Role = Models.Enum.Role.Admin;
        }

        public static AuxDB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AuxDB();
                }
                return instance;
            }
        }
    }
}