using CIPlatform.Data;
using CIPlatform.Models;
using CIPlatform.Views.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CIPlatform.Controllers
{
    public class UserController : Controller
    {
        private readonly CiPlatformContext _db;
        
        public UserController(CiPlatformContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
         {
            
            return View();
        }

        [HttpPost]
        public IActionResult Login(User objLogin)
        {
            if (_db.Users.Any(u=> u.Email == objLogin.Email && u.Password == objLogin.Password)) 
            { return RedirectToAction("MissionGrid", "Home"); }
            return RedirectToAction("Login", "User");

          
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(User objPass)
        {
            if (_db.Users.Any(u => u.Email == objPass.Email))
            { return RedirectToAction("ResetPassword", "User"); }
            return View();
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Register(User objUser)
        {
            if (objUser.Password == objUser.ConfirmPassword)
            {
                _db.Users.Add(objUser);
                _db.SaveChanges();
                return RedirectToAction("MissionGrid", "Home");
            }
            return RedirectToAction("Login","User");
        }

    }
}
