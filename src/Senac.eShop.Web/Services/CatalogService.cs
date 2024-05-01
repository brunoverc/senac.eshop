﻿using Microsoft.Extensions.Options;
using Senac.eShop.Web.Extensions;
using Senac.eShop.Web.Models;

namespace Senac.eShop.Web.Services
{
    public interface ICatalogService
    {
        Task<PagedViewModel<ProductViewModel>> GetAll(int pageSize, int pageIndex, string query = null);
        Task<ProductViewModel> GetById(Guid id);
    }
    public class CatalogService : Service, ICatalogService
    {
        private readonly HttpClient _httpClient;

        public CatalogService(HttpClient httpClient,
            IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.Url);

            _httpClient = httpClient;
        }

        public async Task<ProductViewModel> GetById(Guid id)
        {
            var response = await _httpClient.GetAsync($"/product/{id}");

            HandleErrosResponse(response);

            return await DeserializeObjectResponse<ProductViewModel>(response);
        }

        public async Task<PagedViewModel<ProductViewModel>> GetAll(
            int pageSize, 
            int pageIndex, 
            string productName)
        {
            var response = await _httpClient.GetAsync($"/product/{pageSize}/{pageIndex}/{productName}");

            HandleErrosResponse(response);

            return await DeserializeObjectResponse<PagedViewModel<ProductViewModel>>(response);
        }
    }
}
