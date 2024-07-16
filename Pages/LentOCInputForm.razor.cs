using AntDesign;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using MyAntDesignApp.Model;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyAntDesignApp.Pages;

public partial class LentOCInputForm
{
    [Parameter] public EventCallback<MouseEventArgs> OnModalCancel { get; set; }
    [Parameter] public EventCallback<EditContext> OnFormValidSubmit { get; set; }
    [Parameter] public EventCallback<EditContext> OnFormInvalidSubmit { get; set; }

    private Modal ModalRef;
    private LentOCInputModel InputModel = new();
    private Form<LentOCInputModel> FormRef;
    private CancellationTokenSource _cts = new();

    private List<OpCentreModel> OperatingCentreDropdown = new();
    private List<LookupViewModel> StatusDropdown = new();
    private List<OpCentreModel> OcList = new();

    private const string TITLE = "Input Lent OC";
    private string Title = TITLE;
    private bool Visible, Loading, IsEdit;
    private string OK = "Save";

    public void Add()
    {
        Title = TITLE + " - [Add]";
        IsEdit = false;
        Show();
    }

    private void Show()
    {
        Visible = true;
        //StateHasChanged();
    }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            Loading = true;

            //OcList = await OperatingCentreService.GetAll(_cts.Token);
            await LoadListing();
        }
        catch (Exception ex)
        {
            //Error.ProcessError(ex);
        }
        finally
        {
            Loading = false;
        }
    }

    private async Task LoadListing()
    {
        OperatingCentreDropdown = new()
        {
            new OpCentreModel() {Code = "003", Name = "Glenary"},
            new OpCentreModel() {Code = "154", Name = "Lekir"}
        };

        StatusDropdown = new()
        {
            new LookupViewModel() {Id = Guid.NewGuid(), Code = "001", Description = "Test1"},
            new LookupViewModel() {Id = Guid.NewGuid(), Code = "002", Description = "Test2"}
        };     
    }

    private void OkButtonOnClick(MouseEventArgs e) => FormRef.Submit();

    private void CancelButtonOnClick(MouseEventArgs e)
    {
        CloseReset();
        if (OnModalCancel.HasDelegate)
            OnModalCancel.InvokeAsync(e);
    }

    private async Task OnFinish(EditContext editContext)
    {
        bool isOCProcessing = false;

        if (isOCProcessing)//if (IsOCProcessing())
        {
            return;
        }

        try
        {
            bool isSuccess = await Save() != null;
            Console.WriteLine("Record has been saved successfully." );

            if (!isSuccess)
                return;

            if (OnFormValidSubmit.HasDelegate)
                await OnFormValidSubmit.InvokeAsync(editContext);
            CloseReset();
        }
        catch (Exception ex)
        {
            //Error.ProcessError(ex);
        }
        finally
        {
            Loading = false;
        }
    }

    private void OnFinishFailed(EditContext editContext)
    {
        Console.WriteLine("FAIL");
        if (OnFormInvalidSubmit.HasDelegate)
            OnFormInvalidSubmit.InvokeAsync(editContext);
    }

    private void CloseReset()
    {
        Visible = IsEdit = false;

        InputModel = new();
        //StateHasChanged();
    }

    private async Task<LentOCInputModel> Save()
    {
        return new LentOCInputModel();
    }

    public async Task EditAsync(LentOCInputModel model)
    {
        Title = TITLE + " - [Edit]";
        IsEdit = true;
        InputModel = model;

        OperatingCentreDropdown = new()
        {
            new OpCentreModel() {Code = "003", Name = "Glenary"},
            new OpCentreModel() {Code = "154", Name = "Lekir"}
        };

        Show();
    }

    //protected override void Dispose(bool disposing)
    //{
    //    ModalRef = null;
    //    InputModel = null;
    //    OperatingCentreDropdown = null;
    //    StatusDropdown = null;
    //    OcList = null;
    //    FormRef = null;
    //    _cts.Cancel();
    //    base.Dispose(disposing);
    //}
}