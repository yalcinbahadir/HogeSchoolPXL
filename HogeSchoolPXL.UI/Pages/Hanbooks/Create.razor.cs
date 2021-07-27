using HogeSchoolPXL.Data.Repositories.Abstract;
using HogeSchoolPXL.Domein;
using HogeSchoolPXL.UI.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeSchoolPXL.UI.Pages.Hanbooks
{
    public partial class Create
    {
        public HandbookModel Model { get; set; } = new HandbookModel();
        public List<Course> Courses { get; set; } = new List<Course>();
        [Inject]
        public IUnitOfWork UnitOfWork { get; set; }
        [Inject]
        public NavigationManager Navigator { get; set; }
        protected override void OnInitialized()
        {
            Courses=UnitOfWork.CourseRepo.GetAll();

            
        }
        private void HandelValidSubmit()
        {
            var handbook = HandbookModel.MapHandbook(Model);
            UnitOfWork.HandbookRepo.Create(handbook);
            Navigator.NavigateTo("handbooks/list");

        }
    }
}
