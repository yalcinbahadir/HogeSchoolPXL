using HogeSchoolPXL.UI.Infrastructure;
using HogeSchoolPXL.UI.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeSchoolPXL.UI.Pages
{
    public partial class Login
    {
        public LoginModel Model { get; set; } = new LoginModel();
        public string Message { get; set; }
        public bool ShowMessage { get; set; }
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        protected override void OnInitialized()
        {
            Model = new LoginModel();
            ShowMessage = Messanger.Message != null;
            if (ShowMessage)
            {
                Message = Messanger.Message;
                ShowMessage = Message != null;
            }
            
           
            base.OnInitialized();
        }

        private async Task HandelValidSubmit()
        {
            await JSRuntime.InvokeVoidAsync("submitForm");
        }
    }
}
