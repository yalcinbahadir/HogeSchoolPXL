using Blazored.Modal;
using Blazored.Modal.Services;
using HogeSchoolPXL.Data.Repositories.Abstract;
using HogeSchoolPXL.Domein;
using HogeSchoolPXL.UI.Models;
using Microsoft.AspNetCore.Components;
using PXL.Components;
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
        //public MessageBox MessageBox { get; set; }
        protected override void OnInitialized()
        {
            Handbooks = UnitOfWork.HandbookRepo.GetAll();
        }
        [Inject]
        public IModalService ModalService { get; set; }
        private void HandelValidSubmit()
        {
            var course = CourseModel.MapCourse(Model);
            var isCreated=UnitOfWork.CourseRepo.Create(course);
            if (isCreated)
            {
                ModalParameters parameters = new ModalParameters();
                parameters.Add("Message", $"New course {course.CourseName} is created");
                parameters.Add("CSS", $"bg-success text-white");
                ModalOptions modalOptions = new ModalOptions();               
                modalOptions.Animation = new ModalAnimation(ModalAnimationType.FadeInOut,1);
                modalOptions.HideCloseButton = true;
                ModalService.Show<MessageBox>("",parameters:parameters, options: modalOptions);
                Model = new CourseModel();
            }
        }
    }
}
