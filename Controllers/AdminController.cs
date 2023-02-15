using CIPlatform.Data;
using CIPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.PortableExecutable;

namespace CIPlatform.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Admin> objAdminList = _db.Admin;
            return View(objAdminList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Register(Admin objAdmin)
        {
            _db.Admin.Add(objAdmin);
            _db.SaveChanges();
            return RedirectToAction("Index","Admin");
        }
    }
}
