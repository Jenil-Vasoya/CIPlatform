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
        public IActionResult Login(Login objLogin)
        {
            SqlConnection objConn = new SqlConnection("Server=MRKHEDUT;Initial Catalog=CI Platform;Trusted_Connection=True;TrustServerCertificate=True;");

            SqlCommand com = new SqlCommand("PR_User_SelectByUserNamePassword", objConn);
            objConn.Open();
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Email", objLogin.Email);
                com.Parameters.AddWithValue("@Password", objLogin.Password);
                com.ExecuteNonQuery();
                objConn.Close();
                return RedirectToAction("Index","Admin");
            
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
                return RedirectToAction("MissionGrid", "Home");
            }
            return RedirectToAction("Login","User");
        }

    }
}
