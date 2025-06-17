using HealthStream.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthStream.Controllers
{
    public class SampleController : Controller
    {
        [HttpGet]
        public IActionResult Sample()
        {
            //List<Product> products = new List<Product>()
            //{
            //    new Product(){Id=1,Name="Venkata"},
            //    new Product(){Id=2,Name="Krishna"},
            //    new Product(){Id=3,Name="Muhammed"},
            //    new Product(){Id=1,Name="Karnaa"},
            //};
            return View();
        }

        [HttpPost]
        public IActionResult Login(Person p)
        {
            return View();
        }

        public IActionResult Logout(int id)
        {
            return View();
        }
    }

    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
