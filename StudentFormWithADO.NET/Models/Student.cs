namespace StudentFormWithADO.NET.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public long PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public DateTime DOJ { get; set; }

        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public int InchargeId { get; set; }
        public string InchargeName { get; set; }
    }
}
