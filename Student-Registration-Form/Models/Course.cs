using System.ComponentModel.DataAnnotations;

namespace Student_Registration_Form.Models
{
    public class Course
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage ="Course name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Description is required")]
        public string Description { get; set; }

        //Navigation Properties

        public ICollection<Incharge> Incharges { get; set; } = new List<Incharge>();

    }
}
