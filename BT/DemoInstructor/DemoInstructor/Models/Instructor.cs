using System;
using System.Collections.Generic;

namespace DemoInstructor.Models
{
    public partial class Instructor
    {
        public Instructor()
        {
            CourseId = new HashSet<Course>();
        }

        public int InstructorId { get; set; }
        public string? InstructorFirstName { get; set; }
        public string? InstructorMidName { get; set; }
        public string? InstructorLastName { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Department? Department { get; set; }
        public virtual ICollection<Course> CourseId { get; set; }
    }
}
