﻿namespace StudentFormWithADO.NET.Models
{
    public class Incharge
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int CourseId { get; set; }

        public string CourseName { get; set; } // For display only
    }
}
