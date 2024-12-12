using Api.Document.Controllers;
using Entities.Data;
using Entities.Domain;
using App.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using Microsoft.Data.SqlClient;

namespace App.Api.Services.ProductCategory
{
    public interface ImsProductCategoryService
    {
        Task<Entities.Domain.VMResponse> GetData();
        Task<VMResponse> GetData(Entities.ViewModels.VMMasterSearchForm crit);
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
                var data = await _category.TableNoTracking.ToListAsync();
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
        public async Task<VMResponse> GetData(Entities.ViewModels.VMMasterSearchForm crit)
        {
            try
            {
                var data = await _category.TableNoTracking.ToListAsync();

                var approval = crit.Approval;

                if (!crit.Name.IsNullOrEmpty())
                {
                    data = data.Where(w => w.CategoryName.ToLower().Contains((crit.Name + "").ToLower())).ToList();
                }
                if (crit.Approval.HasValue)
                {
                    data = approval == true ? data.Where(w => !w.ApproveBy.IsNullOrEmpty()).ToList()
                            : approval == false ? data.Where(w => w.ApproveBy.IsNullOrEmpty()).ToList()
                            : data;
                }
                if (crit.Status == 11)
                {
                    data = data.Where(w => w.Status == 11).ToList(); // 11 : deleted
                }
                else if(crit.Status == 10)
                {
                    data = data.Where(w => w.Status == 10).ToList(); // 10 : activce
                }
                else if (crit.Status == 99)
                {
                    data = data.Where(w => w.Status == 99).ToList(); // 99 : waiting approval
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
                        Status = 99,
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
                    await dbTran.RollbackAsync(); 
                    response.statusCode = System.Net.HttpStatusCode.InternalServerError;

                    if (ex.InnerException is DbUpdateException sqlEx)
                    {
                        response.message = ex.InnerException.InnerException.Message.ToLower().Contains("unique key constraint")
                            ? $"Product Category {request.CategoryName} Already Exists!"
                            : $"SQL Error: Failed to create product category - {sqlEx.Message}";
                    }
                    else
                    {
                        response.message = $"Unexpected Error: {ex.Message}";
                    }
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
                            ApproveBy = request.ApproveBy,
                            ApproveDt = request.ApproveDt,
                            UpdateDt = DateTime.Today,
                            Status = request.Status
                        };
                        await _category.UpdateAsync(data);
                        await _category.SaveChangesAsync();
                        await dbTran.CommitAsync();

                        response.statusCode = System.Net.HttpStatusCode.OK;
                        response.message = "success edit data category : " + data.CategoryName;
                        response.data = data;
                    }
                }
                catch(Exception ex)
                {
                    await dbTran.RollbackAsync();
                    response.statusCode = System.Net.HttpStatusCode.InternalServerError;

                    if (ex.InnerException is DbUpdateException sqlEx)
                    {
                        response.message = ex.InnerException.InnerException.Message.ToLower().Contains("unique key constraint")
                            ? $"Product Category {request.CategoryName} Already Exists!"
                            : $"SQL Error: Failed to update product category - {sqlEx.Message}";
                    }
                    else
                    {
                        response.message = $"Failed to update product category : {ex.Message}";
                    }
                }
            }
            return response;
        }
        public async Task<VMResponse> Delete(long id, string userName)
        {
            using (var dbTran = await _category.BeginTransactionAsync())
            {
                string title = "";
                try
                {
                    Entities.Domain.ProductCategory data = new Entities.Domain.ProductCategory();
                    var apiResponse = await GetID(id);
                    object? dataResponse = apiResponse.data;
                    var existingData = (Entities.Domain.ProductCategory)dataResponse;
                    if (existingData != null)
                    {
                        if (existingData.Status != 99)
                        {
                            data = new Entities.Domain.ProductCategory()
                            {
                                ProductCategoryId = existingData.ProductCategoryId,
                                CategoryName = existingData.CategoryName,
                                Description = existingData.Description,
                                CreateBy = existingData.CreateBy,
                                CreateDt = existingData.CreateDt,
                                UpdateBy = userName,
                                UpdateDt = DateTime.Now,
                                ApproveBy = existingData.UpdateBy,
                                ApproveDt = existingData.UpdateDt,
                            };
                            data.Status = 11;
                            await _category.UpdateAsync(data);
                            title = "deactivate";
                        }
                        else
                        {
                            _category.Delete(existingData);
                            title = "deleted";
                        }
                        await _category.SaveChangesAsync();
                        await dbTran.CommitAsync();

                        response.statusCode = System.Net.HttpStatusCode.OK;
                        response.message = $"success {title} data product category";
                        response.data = data;
                    }
                }
                catch (Exception ex)
                {
                    dbTran.Rollback();
                    response.statusCode = System.Net.HttpStatusCode.InternalServerError;
                    response.message = $"failed to {title} data category : {ex.Message}";
                }
            }
            return response;
        }
    }
}
