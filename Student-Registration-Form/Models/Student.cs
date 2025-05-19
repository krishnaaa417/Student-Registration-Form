namespace Student_Registration_Form.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public long PhoneNumber { get; set; }

        public DateOnly DOJ { get; set; }

        public string EmailId { get; set; }

        public string Address { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int InchargeId { get; set; }
        public Incharge Incharge { get; set; }
    }
}
