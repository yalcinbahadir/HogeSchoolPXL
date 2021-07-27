using HogeSchoolPXL.Data.Repositories.Abstract;
using HogeSchoolPXL.Domein;
using HogeSchoolPXL.UI.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeSchoolPXL.UI.Pages.Registrations
{
    public partial class Create
    {
        public RegistrationModel Model { get; set; } = new RegistrationModel();
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Course> Courses { get; set; } = new List<Course>();
        [Inject]
        public IUnitOfWork UnitOfWork { get; set; }
        [Inject]
        public NavigationManager Navigator { get; set; }
        protected override void OnInitialized()
        {
            Students = UnitOfWork.StudentRepo.GetAll();
            Courses = UnitOfWork.CourseRepo.GetAll();
            base.OnInitialized();
        }
        private void HandelValidSubmit()
        {
            var registration = new Registration();
            registration.StudentId = int.Parse(Model.StudentId);
            registration.CourseId = int.Parse(Model.CourseId);
            UnitOfWork.RegistrationRepo.Create(registration);
            Navigator.NavigateTo("registrations/list");
        }
    }
}
