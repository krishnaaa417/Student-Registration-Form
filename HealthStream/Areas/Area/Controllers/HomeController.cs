using Microsoft.AspNetCore.Mvc;

namespace HealthStream.Areas.Area.Controllers
{
    [Area("Area")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
