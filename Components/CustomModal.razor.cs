using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Threading.Tasks;

namespace MyAntDesignApp.Components
{
    public partial class CustomModal
    {
        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string ModalText { get; set; }

        [Parameter]
        public bool Visible { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnOk { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnCancel { get; set; }

        private bool ConfirmLoading = false;

        private async Task OnOkButtonClicked()
        {
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! Loading Now");
            ConfirmLoading = true;

            if (OnOk.HasDelegate)
            {
               await OnOk.InvokeAsync();
            }

            CloseReset();
        }

        private async Task OnCancelButtonClicked()
        {
            if (OnCancel.HasDelegate)
            {
               await OnCancel.InvokeAsync();
            }

            CloseReset();
        }

        public void CloseReset()
        {
            Visible = false;            //what if the form is save & new? new PARAM (RemainOpenAfterSave)?
            ConfirmLoading = false;

            StateHasChanged();
        }
    }
}
