using HogeSchoolPXL.Data.Repositories.Abstract;
using HogeSchoolPXL.Domein;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeSchoolPXL.UI.Pages.Hanbooks
{
    public partial class List
    {
        public List<Handbook> Handbooks { get; set; } = new List<Handbook>();
        [Inject]
        public IUnitOfWork UnitOfWork { get; set; }

        protected override void OnInitialized()
        {
            Handbooks = UnitOfWork.HandbookRepo.GetHandbooksWithCourses();
            base.OnInitialized();
        }

        private void Delete_Click(Handbook handbook)
        {

        }
    }
}
