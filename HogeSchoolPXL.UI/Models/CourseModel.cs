using HogeSchoolPXL.Domein;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HogeSchoolPXL.UI.Models
{
    public class CourseModel
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public double StudyPoints { get; set; }
      
        public string HandbookId { get; set; }

        public static Course MapCourse(CourseModel model)
        {
            var course = new Course();

            course.CourseName = model.CourseName;
            course.StudyPoints = model.StudyPoints;

            course.HandbookId = int.TryParse(model.HandbookId, out int id) ? id : null;
           

            return course;
        }
    }
}
