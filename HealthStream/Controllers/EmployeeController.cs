using Microsoft.AspNetCore.Mvc;

namespace HealthStream.Controllers
{
    [Route("Employee")]
    public class EmployeeController : Controller
    {
        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Love")]
        public IActionResult Love()
        {
            return View();
        }
    }
}
