using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using StudentFormWithADO.NET.Data;
using StudentFormWithADO.NET.Models;
using System.Data;

namespace StudentFormWithADO.NET.Controllers
{
    public class StudentController : Controller
    {
        private readonly Helper _db;

        public StudentController(Helper db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var list = new List<Student>();
            using (SqlConnection conn = _db.GetConnection())
            {
                var cmd = new SqlCommand("sp_GetAllStudents", conn) { CommandType = CommandType.StoredProcedure };
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Student
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        PhoneNumber = (long)reader["PhoneNumber"],
                        Email = reader["Email"].ToString(),
                        Address = reader["Address"].ToString(),
                        DOJ = (DateTime)reader["DOJ"],
                        CourseId = (int)reader["CourseId"],
                        CourseName = reader["CourseName"].ToString(),
                        InchargeId = (int)reader["InchargeId"],
                        InchargeName = reader["InchargeName"].ToString()
                    });
                }
            }
            return View(list);
        }

        public IActionResult Create()
        {
            ViewBag.CourseId = new SelectList(GetCourses(), "Id", "Name");
            ViewBag.InchargeId = new SelectList(GetIncharges(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student model)
        {
            using (SqlConnection conn = _db.GetConnection())
            {
                var cmd = new SqlCommand("sp_InsertStudent", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", model.Email);
                cmd.Parameters.AddWithValue("@Address", model.Address);
                cmd.Parameters.AddWithValue("@DOJ", model.DOJ);
                cmd.Parameters.AddWithValue("@CourseId", model.CourseId);
                cmd.Parameters.AddWithValue("@InchargeId", model.InchargeId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var student = new Student();
            using (SqlConnection conn = _db.GetConnection())
            {
                var cmd = new SqlCommand("SELECT * FROM Student WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    student.Id = (int)reader["Id"];
                    student.Name = reader["Name"].ToString();
                    student.PhoneNumber = (long)reader["PhoneNumber"];
                    student.Email = reader["Email"].ToString();
                    student.Address = reader["Address"].ToString();
                    student.DOJ = (DateTime)reader["DOJ"];
                    student.CourseId = (int)reader["CourseId"];
                    student.InchargeId = (int)reader["InchargeId"];
                }
            }
            ViewBag.CourseId = new SelectList(GetCourses(), "Id", "Name", student.CourseId);
            ViewBag.InchargeId = new SelectList(GetIncharges(), "Id", "Name", student.InchargeId);
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student model)
        {
            using (SqlConnection conn = _db.GetConnection())
            {
                var cmd = new SqlCommand("sp_UpdateStudent", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", model.Id);
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", model.Email);
                cmd.Parameters.AddWithValue("@Address", model.Address);
                cmd.Parameters.AddWithValue("@DOJ", model.DOJ);
                cmd.Parameters.AddWithValue("@CourseId", model.CourseId);
                cmd.Parameters.AddWithValue("@InchargeId", model.InchargeId);
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

        private List<Incharge> GetIncharges()
        {
            var incharges = new List<Incharge>();
            using (SqlConnection conn = _db.GetConnection())
            {
                var cmd = new SqlCommand("sp_GetAllIncharges", conn) { CommandType = CommandType.StoredProcedure };
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    incharges.Add(new Incharge
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString()
                    });
                }
            }
            return incharges;
        }
    }
}

    

