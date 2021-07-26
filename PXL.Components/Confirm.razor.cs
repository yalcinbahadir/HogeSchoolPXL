using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PXL.Components
{
    public partial class Confirm
    {
        public bool ShowConfirmation { get; set; }
        [Parameter]
        public string ConfirmationTitle { get; set; }
        [Parameter]
        public string ConfirmationMessage { get; set; }
        public string Name { get; set; }
        public void Show()
        {
            ShowConfirmation = true;
            StateHasChanged();
        }

        [Parameter]
        public EventCallback<bool> ConfirmationChanged { get; set; }

        private async Task OnConfirmationChanged(bool value)
        {
            ShowConfirmation = false;
            await ConfirmationChanged.InvokeAsync(value);
        }
    }
}
