using HogeSchoolPXL.UI.Infrastructure;
using HogeSchoolPXL.UI.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeSchoolPXL.UI.Pages
{
    public partial class Register
    {
        public RegisterModel Model { get; set; } = new RegisterModel();
        [Inject]
        public UserManager<IdentityUser> UserManager { get; set; }
        [Inject]
        public NavigationManager Navigator { get; set; }
        public string Message { get; set; }
        public bool ShowMessage { get; set; }

        protected override void OnInitialized()
        {
            ShowMessage = Messanger.Message !=null;
            if (ShowMessage)
            {
                Message = Messanger.Message;                
            }
            base.OnInitialized();
        }
        private async Task HandelValidSubmit()
        {
            var existing=await UserManager.FindByNameAsync(Model.Email);
            if (existing is not null)
            {
                Messanger.Message = "Email already exists.";
                Navigator.NavigateTo("login");

            }
            else
            {
                var user = new IdentityUser { UserName=Model.Email, Email=Model.Email };
                var result=await UserManager.CreateAsync(user, Model.Password);
                if (result.Succeeded)
                {
                    Navigator.NavigateTo("login",true);
                }
                else
                {
                    Messanger.Message = "Registration failed. Try again.";
                    Navigator.NavigateTo("register", true);

                }
            }

            
        }
    }
}
