using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dnd_App.Utils
{
    public class Security
    {
        
        //genera el hash
        public static string EncryptPassBCrypt(String password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        //Prueba si la cotraseña es correcta
        public static Boolean CheckPassBCrypt(String Password, String DBPass)
        {
            return BCrypt.Net.BCrypt.Verify(Password,DBPass);
        }

        //genera token
        public static string GenerateToken()
        {
            Random random = new Random();
            const string chars = "bcdfghjklmnpqrstvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, 5)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


    }
}