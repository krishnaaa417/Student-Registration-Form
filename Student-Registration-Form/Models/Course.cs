using System.ComponentModel.DataAnnotations;

namespace Student_Registration_Form.Models
{
    public class Course
    {
        
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        //Navigation Properties

        public ICollection<Incharge> Incharges { get; set; }

    }
}
