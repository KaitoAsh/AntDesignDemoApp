using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;

namespace MyAntDesignApp.Components
{
    public partial class ProcessingResult
    {
        [Parameter]
        public EventCallback<MouseEventArgs> OnOkButtonClicked { get; set; }

        [Parameter]
        public string Title { get; set; }

        private async void OkButtonOnClick()
        {
            if (OnOkButtonClicked.HasDelegate)
            {
                await OnOkButtonClicked.InvokeAsync();
            }

            StateHasChanged();
        }
    }
}
