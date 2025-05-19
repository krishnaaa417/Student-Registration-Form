using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Student_Registration_Form.Models;

namespace Student_Registration_Form.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
