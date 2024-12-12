
using BlazorApp.Components.Pages.Masters.Product.ProductCategory;
using Entities.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.IdentityModel.Tokens;
using Microsoft.JSInterop;
using MudBlazor;
using Newtonsoft.Json;
using System.Text;

using static MudBlazor.CategoryTypes;
public partial class ProductCategoryBase : Microsoft.AspNetCore.Components.ComponentBase
{
    
    [Inject]
    protected IJSRuntime JavaScript { get; set; }
    protected bool _loading;
    private readonly string apiUrl = "https://localhost:7108/api/";
    private readonly HttpClient httpClient = new HttpClient();
    private VMResponse? apiResponse;
    private HttpContent content;
    private string jsonData;
    private DotNetObjectReference<ProductCategoryBase>? _dotNetRef;
    protected List<Entities.Domain.ProductCategory>? productCategories = new List<Entities.Domain.ProductCategory>();
    protected bool _sortNameByLength;
    protected SortMode _sortMode = SortMode.Multiple;
    protected string searchString = string.Empty;
    protected byte _selStatus = 10;
    MudDataGrid<Entities.Domain.ProductCategory> dataGrid;


    protected List<BreadcrumbItem> _items = new List<BreadcrumbItem>
    {
        new BreadcrumbItem("Dashboard", href: "/", icon: Icons.Material.Outlined.Dashboard),
        new BreadcrumbItem("Master Product Category", href: null, disabled:true, icon: Icons.Material.Outlined.TableView),
        // new BreadcrumbItem("Create", href: null, disabled: true, icon: Icons.Material.Filled.Create)
    };
    protected Func<Entities.Domain.ProductCategory, object> _sortBy => x =>
    {
        if (_sortNameByLength)
            return x.CategoryName.Length;
        else
            return x.CategoryName;
    };
    protected override async Task OnInitializedAsync()
    {
        productCategories = GetDataAsync().Result.Where(w => w.Status == _selStatus).ToList();
    }
  
    protected async Task LoadTable()
    {
        productCategories = await GetDataAsync() ?? new List<Entities.Domain.ProductCategory>();
        if (productCategories != null || productCategories.Count > 0)
        {
            if (!searchString.IsNullOrEmpty() || (_selStatus != null && _selStatus > 0))
            {
                productCategories = productCategories.Where(w => (w.CategoryName.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                    || w.Description.Contains(searchString, StringComparison.OrdinalIgnoreCase)) && w.Status == _selStatus).ToList();
            }
        }
    }
    protected Task OnSearch(string text)
    {
        searchString = text;
        return LoadTable();
    }
    protected void SelStatus(byte value)
    {
        _selStatus = value;
        LoadTable();
    }
   
    protected async Task StatusChange(long id, string name)
    {
        _dotNetRef = DotNetObjectReference.Create(this);
        if (id > 0 && !name.IsNullOrEmpty())
        {
            await JavaScript.InvokeVoidAsync("showSweetAlert", "warning", "Are you sure?","want to delete this", _dotNetRef, id);
        }
    }
    [JSInvokable]
    public async Task DeleteData(long id)
    {
        Entities.Domain.VMResponse result = await DeleteAsync(id, "name");
        _loading = true;
        if (result.statusCode == System.Net.HttpStatusCode.OK)
        {
            _loading = false;
            await JavaScript.InvokeVoidAsync("showSweetAlert", "success", "Success", result.message, null, null);
            await LoadTable();
            StateHasChanged();
        }
        else
        {
            await JavaScript.InvokeVoidAsync("showSweetAlert", "error", "Failed", result.message, null, null);
        }
    }
    #region api connection
    public async Task<List<Entities.Domain.ProductCategory>>? GetDataAsync()
    {
        List<Entities.Domain.ProductCategory>? data = null;
        try
        {
            apiResponse = JsonConvert.DeserializeObject<VMResponse>(httpClient.GetStringAsync(apiUrl + "ProductCategory").Result);
            if (apiResponse != null)
            {
                if (apiResponse.statusCode == System.Net.HttpStatusCode.OK)
                {
                    data = JsonConvert.DeserializeObject<List<Entities.Domain.ProductCategory>?>
                        (JsonConvert.SerializeObject(apiResponse.data));
                }
                else
                {
                    throw new Exception(apiResponse.message);
                }
            }
            else
            {
                throw new Exception(apiResponse.message);
            }
        }
        catch (Exception ex)
        {
            data = null;
        }
        return data;
    }
    public async Task<List<Entities.Domain.ProductCategory>?> GetByFilterAsync(Entities.ViewModels.VMMasterSearchForm crit)
    {
        List<Entities.Domain.ProductCategory>? data = null;
        try
        {

            jsonData = JsonConvert.SerializeObject(crit);
            content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            apiResponse = JsonConvert.DeserializeObject<VMResponse?>(
                await httpClient.PostAsync(apiUrl + "ProductCategory/GetByFilter", content).Result.Content.ReadAsStringAsync()
            );
            if (apiResponse != null)
            {
                if (apiResponse.statusCode == System.Net.HttpStatusCode.OK || apiResponse.statusCode == System.Net.HttpStatusCode.Created)
                {
                    data = JsonConvert.DeserializeObject<List<Entities.Domain.ProductCategory>?>(
                        JsonConvert.SerializeObject(apiResponse.data));
                }
                else
                {
                    throw new Exception(apiResponse.message);
                }
            }
            else
            {
                throw new Exception("Product Category API cannot be reached");
            }
        }
        catch (Exception ex)
        {
        }
        return data;
    }
    public async Task<Entities.Domain.VMResponse>? StoreAsync(Entities.Domain.ProductCategory data)
    {
        try
        {
            jsonData = JsonConvert.SerializeObject(data);
            content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            apiResponse = JsonConvert.DeserializeObject<VMResponse?>(
                await httpClient.PostAsync(apiUrl + "ProductCategory", content).Result.Content.ReadAsStringAsync()
            );
            if (apiResponse != null)
            {
                if (apiResponse.statusCode == System.Net.HttpStatusCode.OK || apiResponse.statusCode == System.Net.HttpStatusCode.Created)
                {
                    apiResponse.data = JsonConvert.DeserializeObject<Entities.Domain.ProductCategory?>(
                        JsonConvert.SerializeObject(apiResponse.data));
                }
                else
                {
                    throw new Exception (apiResponse.message);
                }
            }
            else
            {
                throw new Exception("Product Category API cannot be reached");
            }
        }
        catch (Exception ex)
        {
        }
        return apiResponse;
    }
    public async Task<Entities.Domain.ProductCategory> GetIdAsync(long id)
    {
        var data = new Entities.Domain.ProductCategory();
        try
        {
            apiResponse = JsonConvert.DeserializeObject<VMResponse>(httpClient.GetStringAsync(apiUrl + "ProductCategory/GetID/" + id).Result);
            if (apiResponse != null)
            {
                if (apiResponse.statusCode == System.Net.HttpStatusCode.OK)
                {
                    data = JsonConvert.DeserializeObject<Entities.Domain.ProductCategory?>(JsonConvert.SerializeObject(apiResponse.data));
                }
                else
                {
                    throw new Exception(apiResponse.message);
                }
            }
            else
            {
                throw new Exception("Product Category API cannot be reached!");
            }
        }
        catch(Exception ex)
        {
            data = null;
        }
        return data;
    }
    public async Task<Entities.Domain.VMResponse> UpdateAsync(Entities.Domain.ProductCategory data)
    {
        try
        {
            jsonData = JsonConvert.SerializeObject(data);
            content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            apiResponse = JsonConvert.DeserializeObject<VMResponse?>(
                await httpClient.PutAsync(apiUrl + "ProductCategory", content).Result.Content.ReadAsStringAsync()
            );
            if (apiResponse != null)
            {
                if (apiResponse.statusCode == System.Net.HttpStatusCode.OK || apiResponse.statusCode == System.Net.HttpStatusCode.Created)
                {
                    apiResponse.data = JsonConvert.DeserializeObject<Entities.Domain.ProductCategory?>(
                        JsonConvert.SerializeObject(apiResponse.data));
                }
                else
                {
                    throw new Exception(apiResponse.message);
                }
            }
            else
            {
                throw new Exception("Product Category API cannot be reached");
            }
        }
        catch (Exception ex)
        {
        }
        return apiResponse;
    }
    public async Task<Entities.Domain.VMResponse> DeleteAsync(long id, string DeletedBy)
    {
        try
        {
            apiResponse = JsonConvert.DeserializeObject<VMResponse?>(
                    await httpClient.DeleteAsync($"{apiUrl}ProductCategory?id={id}&userName={DeletedBy}").Result.Content.ReadAsStringAsync()
                );

            if (apiResponse == null)
            {
                throw new Exception("ProductCategory API cannot be reached !");
            }
        }
        catch (Exception ex)
        {
            apiResponse.message += $" {ex.Message}";
        }
        return apiResponse;
    }
    #endregion
}