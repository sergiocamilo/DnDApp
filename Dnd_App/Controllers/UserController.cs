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
            if (!Utils.Session.IsLogged())
            {
                return RedirectToAction("Login");
            }
            
            return View();
        }

        [HttpGet]
        public ActionResult _Dashboard()
        {
            return PartialView();
        }

        #region Register - Login - Sesion

        [HttpGet]
        public ActionResult Register()
        {
            if (Utils.Session.IsLogged())
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
            newUser.Role = Models.Enum.Role.User;

            try
            {
                if (newUser.VerifyUser())
                {
                    if (newUser.Create(Password))
                    {
                        TempData["Message"] = "User created successfully";
                        return RedirectToAction("Validate");
                    }
                    else
                    {
                        TempData["Message"] = "Error in Database";
                        return RedirectToAction("Register");
                    }
                }
                else
                {
                    TempData["Message"] = "User is already registered";
                    return RedirectToAction("Register");
                }
            }
            catch (Exception)
            {
                TempData["Message"] = "User is already registered";
                return RedirectToAction("Register");
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            
            if (Utils.Session.IsLogged())
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
            
            if (user.LogIn(Username,Password))
            {
                Utils.Session.LogIn(user);
                return RedirectToAction("Panel");
            }
            else
            {
                TempData["loginerror"] = 1;
                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            Utils.Session.LogOut();
            return RedirectToAction("Index","Home");
        }


        [HttpGet]
        public ActionResult Validate()
        {
            if (Utils.Session.IsLogged())
            {
                return RedirectToAction("Panel");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Validate(String Username, String Password, String Token)
        {
            Models.User user = new Models.User();
            user.UserName = Username;
            user.Token = Token;


            if (user.LogIn(Username, Password))
            {
                if (user.Validate())
                {
                    Utils.Session.LogIn(user);
                    return RedirectToAction("Panel");
                }
                else
                {
                    TempData["validateerror"] = 1;
                    return RedirectToAction("Validate");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        //[HttpGet]
        //public ActionResult ChangePassword()
        //{
        //    if (Utils.Session.IsLogged())
        //    {
        //        return RedirectToAction("Panel");
        //    }
        //    return View();
        //}


        #endregion

    }
}