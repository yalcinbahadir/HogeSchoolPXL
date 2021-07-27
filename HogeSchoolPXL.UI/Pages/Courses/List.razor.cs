using HogeSchoolPXL.Data.Repositories.Abstract;
using HogeSchoolPXL.Domein;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeSchoolPXL.UI.Pages.Courses
{
    public partial class List
    {
        public List<Course> Courses { get; set; } = new List<Course>();
        [Inject]
        public IUnitOfWork UnitOfWork { get; set; }

        protected override void OnInitialized()
        {
            Courses = UnitOfWork.CourseRepo.GetCoursesWithHandbooks();
          
        }

        private void Delete_Click(Course course)
        {

        }
    }
}
