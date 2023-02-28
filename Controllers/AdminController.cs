using CIPlatform.Data;
using CIPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.PortableExecutable;

namespace CIPlatform.Controllers
{
    public class AdminController : Controller
    {
        private readonly CiPlatformContext _db;

        public AdminController(CiPlatformContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Admin> objAdminList = _db.Admins;
            return View(objAdminList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Register(Admin objAdmin)
        {
            _db.Admins.Add(objAdmin);
            _db.SaveChanges();
            return RedirectToAction("Index","Admin");
        }
    }
}
