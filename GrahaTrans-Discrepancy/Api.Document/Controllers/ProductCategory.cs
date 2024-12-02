using App.Api.Services.ProductCategory;
using Entities.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Document.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategory : ControllerBase
    {
        private ImsProductCategoryService _category;
        public ProductCategory(ImsProductCategoryService category)
        {
            _category = category;
        }
        [HttpGet]
        public Task<VMResponse> GetAll() => _category.GetData();
        [HttpGet("[action]/{name?}/{approval?}/{isDelete?}")]
        public Task<VMResponse> GetAll(string? name, int? approval, bool? isDelete) => _category.GetData(name, approval, isDelete);
        [HttpGet("[action]/{id?}")]
        public Task<VMResponse> GetID(int id) => _category.GetID(id);
        [HttpPost]
        public Task<VMResponse> Create(Entities.Domain.ProductCategory request) => _category.Create(request);
        [HttpPut]
        public Task<VMResponse> Update(Entities.Domain.ProductCategory request) => _category.Update(request);
        [HttpDelete]
        public Task<VMResponse> Delete(long id, string userName) => _category.Delete(id, userName);
    }
}
