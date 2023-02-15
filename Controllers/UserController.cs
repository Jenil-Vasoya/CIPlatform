using CIPlatform.Data;
using CIPlatform.Models;
using CIPlatform.Views.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CIPlatform.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        
        public UserController(ApplicationDbContext db)
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
        [Route("Login")]
        public IActionResult Login(Login objLogin)
        {
            User user = _userRepository.Login(objLogin);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        public IActionResult Register()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Register(User objUser)
        {
            if (objUser.Password == objUser.ConfirmPassword)
            {
                _db.User.Add(objUser);
                _db.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("Login","User");
        }

    }
}
