using Microsoft.AspNetCore.Mvc;

namespace HealthStream.Controllers
{
    public class RazorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
