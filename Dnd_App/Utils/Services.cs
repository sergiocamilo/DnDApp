using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace Dnd_App.Utils
{
    public class Services
    {
        public static String EMAIL = ConfigurationManager.AppSettings["email"].ToString();
        public static String PASS = ConfigurationManager.AppSettings["passwordemail"].ToString();
        public static String DOMAIN = ConfigurationManager.AppSettings["domainname"].ToString();

        public static void SendTokenEmail(String Email, String Token)
        {
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(EMAIL, PASS);

            MailMessage mm = new MailMessage(EMAIL,
                Email,
                "Your token is:" + Token,
                "Go to: "+ DOMAIN +"/validate"
                );
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);
        }



    }
}