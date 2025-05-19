using Microsoft.AspNetCore.Mvc;

namespace Student_Registration_Form.Controllers
{
    [Route("Home")]
    public class EmployeeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
