using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Registration_Form.Models;

namespace Student_Registration_Form.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public CourseController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var course = _appDbContext.Courses.ToList();
            return View(course);
        }

   
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Courses.Add(course);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            return View(course);
        }

   
        public IActionResult Edit(int id)
        {
            var course = _appDbContext.Courses.Find(id);
            if(course == null) return NotFound();
            return View(course);
        }

        
        [HttpPost]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Courses.Update(course);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            

            return View(course);
        }

        
        public IActionResult Delete(int id)
        {
            var course = _appDbContext.Courses.Find(id);
            if (course == null) return NotFound();
            return View(course);
        }

        
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var course = _appDbContext.Courses.Find(id);
            _appDbContext.Courses.Remove(course);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

       
        public IActionResult Details(int id)
        {
            var course = _appDbContext.Courses.Find(id);
            if (course == null) return NotFound();
            return View(course);
        }
    }
}
