using HogeSchoolPXL.Data.Repositories.Abstract;
using HogeSchoolPXL.Domein;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeSchoolPXL.UI.Pages.Registrations
{
    public partial class List
    {
        public List<Registration> Registrations { get; set; } = new List<Registration>();
        [Inject]
        public IUnitOfWork UnitOfWork { get; set; }


        protected override void OnInitialized()
        {
            Registrations = UnitOfWork.RegistrationRepo.GetRegistrationsWithStudentsAndCourses().OrderBy(r=>r.Student.Name).ToList();
           
        }

        private void Delete_Click(Registration registration)
        {

        }
    }
}
