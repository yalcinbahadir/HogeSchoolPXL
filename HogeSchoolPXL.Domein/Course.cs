using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogeSchoolPXL.Domein
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public double StudyPoints { get; set; }
        public Handbook Handbook { get; set; }
        public int? HandbookId { get; set; }
    }
}
