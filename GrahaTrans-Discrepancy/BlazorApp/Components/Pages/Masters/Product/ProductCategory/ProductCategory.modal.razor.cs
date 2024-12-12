using BlazorApp.Components.Pages.Masters.Product.ProductCategory;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using System.Net;

public partial class ProductCategoryBase
{
    [Inject]
    protected IDialogService DialogService { get; set; }
    [CascadingParameter]
    protected MudDialogInstance MudDialog { get; set; }
    protected MudForm form;
    protected bool formInvalid = true;
    protected long _ProductCategoryID;
    protected string _CategoryName;
    protected string _Description;
    protected byte _Status;
    protected byte _StatusGet;
    protected string _ApproveBy { get; set; }
    protected DateTime _ApproveDt;

    [Parameter] public bool IsEditMode { get; set; }

    [Parameter] public long Id { get; set; }

    protected async Task OpenDialog()
    {
        var options = new DialogOptions { CloseOnEscapeKey = true };
        var dialog = DialogService.Show<ProductCategory_modal>("Add Product category", options);
        var result = await dialog.Result;
        if (!result.Canceled)
        {
            await LoadTable();
        }
    }
    protected override async Task OnParametersSetAsync()
    {
        if (IsEditMode && Id > 0)
        {
            var a = _ApproveBy;
            // Load the existing category details
            var category = await GetIdAsync(Id);
            if (category != null)
            {
                _ProductCategoryID = category.ProductCategoryId;
                _CategoryName = category.CategoryName;
                _Description = category.Description;
                _Status = category.Status;
                _ApproveBy = string.IsNullOrWhiteSpace(category.ApproveBy) ? "" : category.ApproveBy;
                _StatusGet = category.Status;
                //_ApproveDt = category.ApproveDt ?? DateTime.Today;

            }
        }
    }
    protected async Task OpenEditDialog(long ProductCategoryID)
    {
        try
        {
            if (ProductCategoryID > 0)
            {
                IsEditMode = true;
            }
            var parameters = new DialogParameters { ["Id"] = ProductCategoryID, ["IsEditMode"] = true }; 
            var options = new DialogOptions { CloseOnEscapeKey = true , CloseButton = true};
            var dialog = DialogService.Show<ProductCategory_modal>("Edit Product Category", parameters, options);
            await LoadCategory(ProductCategoryID);
            var result = await dialog.Result;
            if (!result.Canceled)
            {
                await LoadTable();
            }

        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public async Task LoadCategory(long? id)
    {
        IsEditMode = id.HasValue;                                                           
        if (IsEditMode && id.HasValue)
        {
            Id = id.Value;                                                                       
            await LoadCategoryDetail(Id);
        }
        else
        {
            _CategoryName = string.Empty;
            _Description = string.Empty;
        }
    }
    protected async Task LoadCategoryDetail(long id)
    {
        var category = await GetIdAsync(id);
        if (category != null)
        {
            IsEditMode = true;
            Id = category.ProductCategoryId;
            _CategoryName = category.CategoryName;
            _Description = category.Description;
            _Status = category.Status;
            _StatusGet = category.Status;
            _ApproveBy = category.ApproveBy;
        }
    }
    protected async Task Submit(bool IsApproval)
    {
        await form.Validate();
        if (form.IsValid)
        {
            var data = new Entities.Domain.ProductCategory();
            Entities.Domain.VMResponse result = new Entities.Domain.VMResponse();
            if (IsEditMode)
            {
                data.ProductCategoryId = _ProductCategoryID;
                data.CategoryName = _CategoryName;
                data.Description = _Description;
                data.UpdateBy = "name";
                data.UpdateDt = DateTime.Now;
                if (IsApproval)
                {
                    data.ApproveBy = "name";
                    data.ApproveDt = DateTime.Now;
                    data.Status = 10;
                }
                else
                {
                    data.ApproveBy = null;
                    data.ApproveDt = null;
                    data.Status = _Status;
                }

                result = await UpdateAsync(data);
            }
            else
            {
                var newCategory = new Entities.Domain.ProductCategory()
                {
                    CategoryName = _CategoryName,
                    Description = _Description,
                    CreateBy = "name"
                };
                result = await StoreAsync(newCategory);
            }
            if (result.statusCode == System.Net.HttpStatusCode.OK || result.statusCode == HttpStatusCode.Created)
            {
                await JavaScript.InvokeVoidAsync("showSweetAlert", "success", "Success!", result.message, null, null);
                MudDialog.Close(DialogResult.Ok(true));
            }
            else
            {
                await JavaScript.InvokeVoidAsync("showSweetAlert", "error","Failed!", result.message, null, null);
                MudDialog.Cancel();
            }
        }
    }

    protected void Cancel() => MudDialog.Cancel();
}
