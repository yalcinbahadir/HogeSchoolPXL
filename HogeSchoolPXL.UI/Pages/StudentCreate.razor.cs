using HogeSchoolPXL.Data.Repositories.Abstract;
using HogeSchoolPXL.Domein;
using HogeSchoolPXL.UI.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeSchoolPXL.UI.Pages
{
    public partial class StudentCreate
    {
        public Student Student { get; set; }
        public StudentModel Model { get; set; } = new StudentModel();
        [Inject]
        public IUnitOfWork UnitOfWork { get; set; }
        [Inject]
        public NavigationManager Navigator { get; set; }
        public bool ShowMessageBox { get; set; } = false;
        public string Message { get; set; }    
        public bool ShowPhoto { get; set; } = false;
        private void HandelValidSubmit()
        {
            Student = StudentModel.MapStudent(Model);
            var isCreated=UnitOfWork.StudentRepo.Create(Student);
            if (isCreated)
            {
                Navigator.NavigateTo("studentlist");
            }
            else
            {
                ShowMessageBox = true;
                Message = "Resource is not created.";
            }

        }


        private void GetPhotoPath(string path)
        {
            if (path is not null)
            {
                Model.PhotoUrl = path;
                ShowPhoto = true;
            }
           
        }
    }
}
