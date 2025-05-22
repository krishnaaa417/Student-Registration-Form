// InchargeController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student_Registration_Form.Models;

namespace Student_Registration_Form.Controllers
{
    public class InchargeController : Controller
    {
        private readonly AppDbContext _context;

        public InchargeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var incharges = _context.Incharges.Include(i => i.Course).ToList();
            return View(incharges);
        }

        public IActionResult Create()
        {
            ViewBag.CourseId = new SelectList(_context.Courses, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,PhoneNumber,Email,Address,CourseId")] Incharge incharge)
        {
            if (ModelState.IsValid)
            {
                _context.Incharges.Add(incharge);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CourseId = new SelectList(_context.Courses, "Id", "Id", incharge.CourseId);
            return View(incharge);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var incharge = _context.Incharges.Find(id);
            if (incharge == null) return NotFound();

            ViewBag.CourseId = new SelectList(_context.Courses, "Id", "Id", incharge.CourseId);
            return View(incharge);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,PhoneNumber,Email,Address,CourseId")] Incharge incharge)
        {
            if (id != incharge.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(incharge);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CourseId = new SelectList(_context.Courses, "Id", "Id", incharge.CourseId);
            return View(incharge);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var incharge = _context.Incharges.Include(i => i.Course).FirstOrDefault(i => i.Id == id);
            if (incharge == null) return NotFound();

            return View(incharge);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var incharge = _context.Incharges.Find(id);
            _context.Incharges.Remove(incharge);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
