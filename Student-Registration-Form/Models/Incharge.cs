using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Registration_Form.Models
{
    public class Incharge
    {
        public int Id { get; set; }

     
        public string Name { get; set; }
       
        public long PhoneNumber {  get; set; }
       
        public string Email { get; set; }

        public string Address { get; set; }

        
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
