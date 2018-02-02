using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dnd_App.Util
{
    public class Security
    {
        
        //genera el hash
        public static string EncriptarPassBCrypt(String password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        //Prueba si la cotraseña es correcta
        public static Boolean CheckPassBCrypt(String Password, String DBPass)
        {
            return BCrypt.Net.BCrypt.Verify(Password,DBPass);
        }
    }
}