using Microsoft.Extensions.Options;
using Senac.eShop.Core.Communication;
using Senac.eShop.Web.Extensions;
using Senac.eShop.Web.Models;
using System.Net;

namespace Senac.eShop.Web.Services
{
    public interface IClienteService
    {
        Task<AddressViewModel> GetAddress();
        Task<ResponseResult> SetAddress(AddressViewModel address, Guid clientId);
    }

    public class ClienteService : Service, IClienteService
    {
        private readonly HttpClient _httpClient;

        public ClienteService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.ClientUrl);
        }

        public async Task<AddressViewModel> GetAddress()
        {
            var response = await _httpClient.GetAsync("/client");

            if (response.StatusCode == HttpStatusCode.NotFound) return null;

            HandleErrosResponse(response);

            return await DeserializeObjectResponse<AddressViewModel>(response);
        }

        public async Task<ResponseResult> SetAddress(AddressViewModel address, Guid clientId)
        {
            var enderecoContent = GetContent(address);

            var response = await _httpClient.
                PostAsync($"/client/set-address-client/{clientId}/", enderecoContent);

            if (!HandleErrosResponse(response))
            {
                return await DeserializeObjectResponse<ResponseResult>(response);
            }

            return ReturnOk();
        }
    }
}
