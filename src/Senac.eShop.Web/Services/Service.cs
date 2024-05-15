using Senac.eShop.Web.Extensions;
using System.Text.Json;
using System.Text;
using Senac.eShop.Core.Communication;
using Senac.eShop.Web.Models;

namespace Senac.eShop.Web.Services
{
    public abstract class Service
    {
        protected StringContent GetContent(object data)
        {
            return new StringContent(
                JsonSerializer.Serialize(data),
                Encoding.UTF8,
                "application/json");
        }

        protected async Task<T> DeserializeObjectResponse<T>(HttpResponseMessage responseMessage)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            try
            {
                var productTest = await responseMessage.Content.ReadAsStringAsync();
                var jsonTest = JsonSerializer.Deserialize<List<ProductViewModel>>(productTest,
                options);

            }
            catch (Exception ex)
            {
                throw;
            }
                    

            return JsonSerializer.Deserialize<T>(await responseMessage.Content.ReadAsStringAsync(), 
                options);
        }

        protected bool HandleErrosResponse(HttpResponseMessage response)
        {
            switch ((int)response.StatusCode)
            {
                case 401:
                case 403:
                case 404:
                case 500:
                    throw new CustomHttpRequestException(response.StatusCode);

                case 400:
                    return false;
            }

            response.EnsureSuccessStatusCode();
            return true;
        }

        protected ResponseResult ReturnOk()
        {
            return new ResponseResult();
        }
    }
}
