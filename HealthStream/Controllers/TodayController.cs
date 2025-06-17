using HealthStream.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthStream.Controllers
{
    public class TodayController : Controller
    {
        public IActionResult Index(string Username, string Password)
        {
            //if (ModelState.IsValid)
            //{
            //    return View(login);
            //}
            //var errors = ModelState.Select(x => x.Value.Errors);




            return View();
        }
    }
}
