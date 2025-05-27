using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StudentFormWithADO.NET.Data;
using StudentFormWithADO.NET.Models;
using System.Data;

namespace StudentFormWithADO.NET.Controllers
{
    public class CourseController : Controller
    {
        private readonly Helper _helper;

        public CourseController(Helper helper)
        {
            _helper = helper;
        }

        public IActionResult Index()
        {
            List<Course> courses = new List<Course>();
            using (SqlConnection conn = _helper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllCourses", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    courses.Add(new Course
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString()
                    });
                }
            }
            return View(courses);
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
                using (SqlConnection conn = _helper.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("dbo.sp_InsertCourse", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", course.Name);
                    cmd.Parameters.AddWithValue("@Description", course.Description);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                return RedirectToAction("Index");
            }
            return View(course);
        }

        public IActionResult Edit(int id)
        {
            Course course = new Course();
            using (SqlConnection conn = _helper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Course WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    course.Id = (int)reader["Id"];
                    course.Name = reader["Name"].ToString();
                    course.Description = reader["Description"].ToString();
                }
            }
            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(Course course)
        {
            using (SqlConnection conn = _helper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateCourse", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", course.Id);
                cmd.Parameters.AddWithValue("@Name", course.Name);
                cmd.Parameters.AddWithValue("@Description", course.Description);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            using (SqlConnection conn = _helper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteCourse", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
    }
}
