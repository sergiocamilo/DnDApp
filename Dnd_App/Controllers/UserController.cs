using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dnd_App.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Panel()
        {
            if (!Util.Session.IsLogged())
            {
                return RedirectToAction("Login");
            }
            if (TempData["CurrentAction"] == null || TempData["CurrentController"] == null)
            {
                TempData["CurrentAction"] = "_Dashboard";
                TempData["CurrentController"] = "User";
            }
            
            return View();
        }

        [HttpGet]
        public ActionResult _Dashboard()
        {
            TempData["CurrentAction"] = "_Dashboard";
            TempData["CurrentController"] = "User";
            return PartialView();
        }

        #region Register - Login - Sesion

        [HttpGet]
        public ActionResult Register()
        {
            if (Util.Session.IsLogged())
            {
                return RedirectToAction("Panel");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(String Username, String Email, String Password, String RPassword)
        {
            var newUser = new Models.User();
            newUser.UserName = Username;
            newUser.Email = Email;
            newUser.Password = Password;
            newUser.Role = Models.Enum.Role.User;

            if (newUser.VerifyUser(RPassword))
            {
                if (newUser.RegistryUser())
                {
                    //Mostrar que se creo
                    return RedirectToAction("Panel");
                }
            }
            //mostrar error
            return RedirectToAction("Register");
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (Util.Session.IsLogged())
            {
                return RedirectToAction("Panel");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(String Username, String Password)
        {
            Models.User user = new Models.User();
            user.UserName = Username;
            user.Password = Password;

            if (user.LogIn())
            {
                Util.Session.LogIn(user);
                return RedirectToAction("Panel");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            Util.Session.LogOut();
            return RedirectToAction("Login");
        }
        #endregion

    }
}