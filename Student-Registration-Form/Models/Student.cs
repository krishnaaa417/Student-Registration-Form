using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Registration_Form.Models
{
    public class Student
    {
        public int Id { get; set; }
       

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public long PhoneNumber { get; set; }

        [Required(ErrorMessage = "Date of joining is required")]
        public DateOnly DOJ { get; set; }

        [Required(ErrorMessage = "Email ID is required")]
        public string EmailId { get; set; }

        public string Address { get; set; }

       
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        
        public int InchargeId { get; set; }

        [ForeignKey("InchargeId")]
        public Incharge Incharge { get; set; }
    }
}
