using Microsoft.AspNetCore.Mvc;
using Student_Registration_Form.Models;

namespace Student_Registration_Form.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public AdminController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Email, string Password)
        {
            var admin = _appDbContext.Admins.FirstOrDefault(a => a.Email == Email && a.Password == Password );

            if (admin != null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Message = "please provide valid Username and password";
            return View();

        }
    }
}
