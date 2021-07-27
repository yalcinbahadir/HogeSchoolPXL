using HogeSchoolPXL.Data.Repositories.Abstract;
using HogeSchoolPXL.Domein;
using HogeSchoolPXL.UI.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeSchoolPXL.UI.Pages.Courses
{
    public partial class Create
    {
        public CourseModel Model { get; set; } = new CourseModel();
        public List<Handbook> Handbooks { get; set; } = new List<Handbook>();
        [Inject]
        public IUnitOfWork UnitOfWork { get; set; }
        [Inject]
        public NavigationManager Navigator { get; set; }

        protected override void OnInitialized()
        {
            Handbooks = UnitOfWork.HandbookRepo.GetAll();
        }

        private void HandelValidSubmit()
        {
            var course = CourseModel.MapCourse(Model);
            UnitOfWork.CourseRepo.Create(course);
            Navigator.NavigateTo("courses/list");
        }

    }
}
