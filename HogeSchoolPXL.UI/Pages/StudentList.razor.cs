using HogeSchoolPXL.Data.Repositories.Abstract;
using HogeSchoolPXL.Domein;
using Microsoft.AspNetCore.Components;
using PXL.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeSchoolPXL.UI.Pages
{
    public partial class StudentList
    {
        public List<Student> Students { get; set; } = new List<Student>();
        public Student StudentToDelete { get; set; }
        [Inject]
        public IUnitOfWork UnitOfWork { get; set; }
        [Inject]
        public NavigationManager Navigator { get; set; }

        public Confirm DeleteConfirmation { get; set; }

        protected override void OnInitialized()
        {
            Students = UnitOfWork.StudentRepo.GetAll();
            base.OnInitialized();
        }

        private void Delete_Click(Student student)
        {
            StudentToDelete = student;
            DeleteConfirmation.Name = StudentToDelete.Name;
            DeleteConfirmation.Show();         
        }

        private void ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                UnitOfWork.StudentRepo.Delete(StudentToDelete);
                Navigator.NavigateTo("studentlist", true);
            }
            else
            {
                StudentToDelete = null;
            }           
        }
    }
}
