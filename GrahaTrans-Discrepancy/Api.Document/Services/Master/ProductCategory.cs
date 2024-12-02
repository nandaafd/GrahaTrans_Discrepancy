using Api.Document.Controllers;
using Entities.Data;
using Entities.Domain;
using App.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.IdentityModel.Tokens;
using System.Data;

namespace App.Api.Services.ProductCategory
{
    public interface ImsProductCategoryService
    {
        Task<Entities.Domain.VMResponse> GetData();
        Task<VMResponse> GetData(string? name, int? approval, bool? isDelete);
        Task<VMResponse> GetID(long id);
        Task<VMResponse> Create(Entities.Domain.ProductCategory request);
        Task<VMResponse> Update(Entities.Domain.ProductCategory request);
        Task<VMResponse> Delete(long id, string userName);
    }
    public class msProductCategoryService : ImsProductCategoryService
    {
        private readonly IRepository<Entities.Domain.ProductCategory> _category;
        private VMResponse response = new VMResponse();

        public msProductCategoryService(IRepository<Entities.Domain.ProductCategory> category)
        {
            _category = category;
        }
        public async Task<VMResponse> GetData()
        {
            try
            {
                var data = await _category.TableNoTracking.Where(w => w.IsDeleted == false).ToListAsync();
                if (data != null)
                {
                    response.statusCode = System.Net.HttpStatusCode.OK;
                    response.data = data;
                    response.message = "success get data";
                }
                else
                {
                    throw new Exception("product category has no data");
                }
            }
            catch(Exception ex)
            {
                response.statusCode = System.Net.HttpStatusCode.NoContent;
                response.message = $"failed to get data, {ex.Message}";
            }
            return response;
        }
        public async Task<VMResponse> GetData(string? name, int? approval, bool? isDelete)
        {
            try
            {
                var data = await _category.TableNoTracking.ToListAsync();

                if (!name.IsNullOrEmpty())
                {
                    data = data.Where(w => w.CategoryName.ToLower().Contains((name + "").ToLower())).ToList();
                }
                if (approval != null || approval != 0)
                {
                    data = approval == 1 ? data.Where(w => !w.ApproveBy.IsNullOrEmpty()).ToList()
                            : approval == 2 ? data.Where(w => w.ApproveBy.IsNullOrEmpty()).ToList()
                            : data;
                }
                if (isDelete == false)
                {
                    data = data.Where(w => w.IsDeleted == false).ToList();
                }
                else if(isDelete == true)
                {
                    data = data.Where(w => w.IsDeleted == true).ToList();
                }
                
                if (data != null)
                {
                    response.statusCode = System.Net.HttpStatusCode.OK;
                    response.data = data;
                    response.message = "success get data";
                }
                else
                {
                    throw new Exception("product category has no data");
                }
            }
            catch (Exception ex)
            {
                response.statusCode = System.Net.HttpStatusCode.NoContent;
                response.message = $"failed to get data, {ex.Message}";
            }
            return response;
        }
        public async Task<VMResponse> GetID(long id)
        {
            try
            {
                var data = await _category.TableNoTracking.Where(w => w.ProductCategoryId == id).FirstOrDefaultAsync();
                if (data != null)
                {
                    response.statusCode = System.Net.HttpStatusCode.OK;
                    response.data = data;
                    response.message = "success get data with id " + id;
                }
                else
                {
                    throw new Exception($"data with id {id} not found or product category has no data");
                }
            }
            catch (Exception ex)
            {
                response.statusCode = System.Net.HttpStatusCode.NoContent;
                response.message = $"failed to get data, {ex.Message}";
            }
            return response;
        }
        public async Task<VMResponse> Create(Entities.Domain.ProductCategory request)
        {
            using(var dbTran = await _category.BeginTransactionAsync())
            {
                try
                {
                    var data = new Entities.Domain.ProductCategory()
                    {
                        CategoryName = request.CategoryName,
                        Description = request.Description,
                        CreateBy = request.CreateBy,
                        CreateDt = DateTime.Now,
                        IsDeleted = false,
                    };
                    _category.Add(data);
                    await _category.SaveChangesAsync();
                    await dbTran.CommitAsync();

                    response.statusCode = System.Net.HttpStatusCode.Created;
                    response.message = "success create data category";
                    response.data = data;
                }
                catch (Exception ex)
                {
                    dbTran.Rollback();
                    response.statusCode = System.Net.HttpStatusCode.InternalServerError;
                    response.message = $"failed to create data category : {ex.Message}";
                }
            }
            return response;
        }
        public async Task<VMResponse> Update(Entities.Domain.ProductCategory request)
        {
            using(var dbTran = await _category.BeginTransactionAsync())
            {
                try
                {
                    var apiResponse = await GetID(request.ProductCategoryId);
                    object? dataResponse = apiResponse.data;
                    var existingData = (Entities.Domain.ProductCategory)dataResponse;
                    if (existingData != null)
                    {
                        Entities.Domain.ProductCategory data = new Entities.Domain.ProductCategory()
                        {
                            ProductCategoryId = existingData.ProductCategoryId,
                            CategoryName = request.CategoryName,
                            Description = request.Description,
                            CreateBy = existingData.CreateBy,
                            CreateDt = existingData.CreateDt,
                            UpdateBy = request.UpdateBy,
                            UpdateDt = DateTime.Now,
                            IsDeleted = request.IsDeleted
                        };
                        _category.Update(data);
                        await _category.SaveChangesAsync();
                        await dbTran.CommitAsync();

                        response.statusCode = System.Net.HttpStatusCode.OK;
                        response.message = "success edit data category with id : " + data.ProductCategoryId;
                        response.data = data;
                    }
                }
                catch(Exception ex)
                {
                    dbTran.Rollback();
                    response.message = $"failed to edit data category : {ex.Message}";
                    response.statusCode = System.Net.HttpStatusCode.InternalServerError;
                }
            }
            return response;
        }
        public async Task<VMResponse> Delete(long id, string userName)
        {
            using (var dbTran = await _category.BeginTransactionAsync())
            {
                try
                {
                    var apiResponse = await GetID(id);
                    object? dataResponse = apiResponse.data;
                    var existingData = (Entities.Domain.ProductCategory)dataResponse;
                    if (existingData != null)
                    {
                        Entities.Domain.ProductCategory data = new Entities.Domain.ProductCategory()
                        {
                            ProductCategoryId = existingData.ProductCategoryId,
                            CategoryName = existingData.CategoryName,
                            Description = existingData.Description,
                            CreateBy = existingData.CreateBy,
                            CreateDt = existingData.CreateDt,
                            UpdateBy = userName,
                            UpdateDt = DateTime.Now,
                            IsDeleted = true
                        };
                        _category.Update(data);
                        await _category.SaveChangesAsync();
                        await dbTran.CommitAsync();

                        response.statusCode = System.Net.HttpStatusCode.OK;
                        response.message = "success deactivate data category with id : " + data.ProductCategoryId;
                        response.data = data;
                    }
                }
                catch (Exception ex)
                {
                    dbTran.Rollback();
                    response.statusCode = System.Net.HttpStatusCode.InternalServerError;
                    response.message = $"failed to deactivate data category : {ex.Message}";
                }
            }
            return response;
        }
    }
}
