using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Registration_Form.Models
{
    public class Incharge
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public long PhoneNumber {  get; set; }
        [Required]
        public string Email { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage ="please select a course")]
        [Display(Name="Course")]
        public int CourseId { get; set; }

      //  [ForeignKey("CourseId")]
        public Course Course { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
