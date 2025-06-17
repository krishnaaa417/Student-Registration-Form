using Microsoft.AspNetCore.Mvc;

namespace HealthStream.Controllers
{
    public class DataPassTechniquesController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Welcome to the ASP.NET MVC";
            ViewData["Year"] = DateTime.Now;
            return View();
        }

        public ActionResult SubmitForm()
        {
            TempData["message"] = "Form submit successfully..";
            return RedirectToAction("Confirmation");
        }

        public ActionResult Confirmation()
        {
            return View();
        }

        public IActionResult Ex()
        {
            ViewData["first"] = "This is the first view passing from controller to view";
            ViewBag.second = "This is the VIEWBAG from controller to view";
            return View();
        }

        public IActionResult Redirect()
        {
            ViewData["Info"] = "Example for redirecting by Viewdata";
            ViewBag.Note = "Example for redirecting by Viewbag";

            //redirect the things here
            return RedirectToAction("Target");
        }

        public IActionResult Target()
        {
            return View();
        }
    }
}
