using Blazored.Modal;
using Blazored.Modal.Services;
using HogeSchoolPXL.Data.Repositories.Abstract;
using HogeSchoolPXL.Domein;
using HogeSchoolPXL.UI.Models;
using HogeSchoolPXL.UI.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeSchoolPXL.UI.Pages
{
    public partial class StudentEdit
    {
        [Parameter]
        public string Id { get; set; }
        public StudentModel Model { get; set; } = new StudentModel();
        public Student Student { get; set; }
        [Inject]
        public IUnitOfWork UnitOfWork { get; set; }
        [Inject]
        public NavigationManager Navigator { get; set; }
        [Inject]
        public IModalService ModalService { get; set; }

        public bool ShowMessageBox { get; set; } = false;
        public string Message { get; set; }
        protected override void OnParametersSet()
        {
            if (int.TryParse(Id, out int id))
            {
                Student = UnitOfWork.StudentRepo.GetById(id);
                MapStudentToModel( Model, Student);
            } 
            else
            {
                ShowMessageBox = true;
                Message = "Student not found";
            }           
        }

        private void HandelValidSubmit()
        {
            MapModelToStudent(Student,Model);
            var isUpdated=UnitOfWork.StudentRepo.Update(Student);
            if (isUpdated)
            {
                Navigator.NavigateTo("studentlist");
            } else
            {
                ShowMessageBox = true;
                Message = "Student not updated.";
            }

        }

        private void GetPhotoPath(string path)
        {
            if (path is not null)
            {
                Model.PhotoUrl = path;
            }
        }

        private StudentModel MapStudentToModel(StudentModel model, Student student)
        {
            model.StudentId = student.StudentId;
            model.Name = student.Name;
            model.LastName = student.LastName;
            model.Email = student.Email;
            model.PhotoUrl = student.PhotoUrl;
            return model;
        }
        private void MapModelToStudent(Student student, StudentModel model)
        {
            student.Name = model.Name;
            student.LastName = model.LastName;
            student.Email = model.Email;
            student.PhotoUrl = model.PhotoUrl;
           
        }
    
        private void ConfirmDelete(int studentId)
        {
            ModalParameters customParameters = new ModalParameters();
            customParameters.Add("Title", "Confirm delete");
            customParameters.Add("Message", $"Are you sure you want to delete {Model.Name}?");
            customParameters.Add("Id", studentId);
            ModalOptions customOptions = new ModalOptions();
           // customOptions.HideCloseButton = true;
           // customOptions.HideHeader = true;
            customOptions.UseCustomLayout = false;
            customOptions.Position = ModalPosition.Center;
            ModalService.Show<ConfirmDelete>("Confirm delete", parameters: customParameters, options:customOptions);
           
        }



    }
}
