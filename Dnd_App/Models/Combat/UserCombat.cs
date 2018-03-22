using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dnd_App.Models.Combat
{
    public class UserCombat : IEqualityComparer<UserCombat>
    {
        public User User { get; set; }
        public Enum.RoleCombat RoleCombat { get; set; }

        public bool Equals(UserCombat x, UserCombat y)
        {
            if (x.User.UserName == y.User.UserName)
                return true;
            else
                return false;
        }

        public int GetHashCode(UserCombat obj)
        {
            if (obj == null)
            {
                return 0;
            }
            return obj.User.UserName.GetHashCode();
        }
    }
}