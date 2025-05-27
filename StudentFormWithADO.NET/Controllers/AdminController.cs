using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StudentFormWithADO.NET.Data;
using StudentFormWithADO.NET.Models;
using System.Data;


namespace StudentFormWithADO.NET.Controllers
{
    public class AdminController : Controller
    {
        private readonly Helper _db;

        public AdminController(Helper db)
        {
            _db = db;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Admin admin)
        {
            using (SqlConnection conn = _db.GetConnection())
            {
                var cmd = new SqlCommand("sp_AdminLogin", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Email", admin.Email);
                cmd.Parameters.AddWithValue("@Password", admin.Password);
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // Login successful
                    return RedirectToAction("Index", "Student");
                }
            }
            ViewBag.Error = "Invalid username or password.";
            return View(admin);
        }
    }
}
