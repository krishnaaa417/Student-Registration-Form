using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using StudentFormWithADO.NET.Data;
using StudentFormWithADO.NET.Models;
using System.Data;
//using System.Data.SqlClient;

namespace StudentFormWithADO.NET.Controllers
{
    public class InchargeController : Controller
    {
        private readonly Helper _db;

        public InchargeController(Helper db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var list = new List<Incharge>();
            using (SqlConnection conn = _db.GetConnection())
            {
                var cmd = new SqlCommand("sp_GetAllIncharges", conn) { CommandType = CommandType.StoredProcedure };
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Incharge
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        PhoneNumber = (long)reader["PhoneNumber"],
                        Email = reader["Email"].ToString(),
                        Address = reader["Address"].ToString(),
                        CourseId = (int)reader["CourseId"],
                        CourseName = reader["CourseName"].ToString()
                    });
                }
            }
            return View(list);
        }

        public IActionResult Create()
        {
            ViewBag.CourseId = new SelectList(GetCourses(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Incharge model)
        {
            using (SqlConnection conn = _db.GetConnection())
            {
                var cmd = new SqlCommand("sp_InsertIncharge", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", model.Email);
                cmd.Parameters.AddWithValue("@Address", model.Address);
                cmd.Parameters.AddWithValue("@CourseId", model.CourseId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        private List<Course> GetCourses()
        {
            var courses = new List<Course>();
            using (SqlConnection conn = _db.GetConnection())
            {
                var cmd = new SqlCommand("sp_GetAllCourses", conn) { CommandType = CommandType.StoredProcedure };
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    courses.Add(new Course
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString()
                    });
                }
            }
            return courses;
        }

        public IActionResult Edit(int id)
        {
            var incharge = new Incharge();
            using (SqlConnection conn = _db.GetConnection())
            {
                var cmd = new SqlCommand("SELECT * FROM Incharge WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    incharge.Id = (int)reader["Id"];
                    incharge.Name = reader["Name"].ToString();
                    incharge.PhoneNumber = (long)reader["PhoneNumber"];
                    incharge.Email = reader["Email"].ToString();
                    incharge.Address = reader["Address"].ToString();
                    incharge.CourseId = (int)reader["CourseId"];
                }
            }
            ViewBag.CourseId = new SelectList(GetCourses(), "Id", "Name", incharge.CourseId);
            return View(incharge);
        }
    }
}
