using AntDesign;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MyAntDesignApp.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAntDesignApp.Layouts
{
    public partial class DropdownDemo
    {
        [Inject]
        public ModalService ModalService { get; set; }

        private ModalRef ModalRef;

        private void OnClick()
        {
            ModalService.Confirm(new ConfirmOptions()
            {
                Icon = AntDesignComponents.CreateIcon("exclamation-circle", "outline"),
                Title = $"Title",
                Content = $"Are you sure to do this?",
                OnOk = async (e) => await ShowModalDialog(),
            });
        }

        private async Task ShowModalDialog()
        {
            ModalRef = await CreateModalAsync("Open Dialog");
        }

        private Task<ModalRef> CreateModalAsync(string title)
        {
            RenderFragment dialog = builder =>
            {
                builder.OpenComponent<ProcessingResult>(0);
                builder.AddAttribute(1, "Title", title);
                builder.AddAttribute(2, "OnOkButtonClicked", EventCallback.Factory.Create<MouseEventArgs>(this, CloseModal));
                builder.CloseComponent();
            };

            return ModalService.CreateModalAsync(new ModalOptions()
            {
                Title = title,
                MaskClosable = false,
                Keyboard = false,
                Content = dialog,
                Footer = null
            });
        }

        private async Task CloseModal()
        {
            await ModalRef.CloseAsync();
        }
    }
}
