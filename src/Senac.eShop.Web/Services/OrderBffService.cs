using Microsoft.Extensions.Options;
using Senac.eShop.Core.Communication;
using Senac.eShop.Web.Extensions;
using Senac.eShop.Web.Models;

namespace Senac.eShop.Web.Services
{
    public interface IOrderBffService
    {
        #region Carrinho
        Task<OrderViewModel> GetBasket(Guid basketId);
        Task<int> GetAmountBasket(Guid basketId);
        Task<ResponseResult> AddBasketItem(BasketItemViewModel item);
        Task<ResponseResult> UpdateBasketItem(BasketItemViewModel item, int amount);
        Task<ResponseResult> DeleteBasketItem(Guid basketId, Guid productId);

        #endregion

        #region Pedido
        Task<ResponseResult> ApplyVoucherCode(Guid orderId, string voucher);
        Task<ResponseResult> CreateOrder(OrderTransactionViewModel orderTransaction);
        Task<OrderViewModel> GetLastOrderClient(Guid clientId);
        Task<IEnumerable<OrderViewModel>> GetOrdersByClient(Guid clientId);
        OrderTransactionViewModel MapToOrder(OrderViewModel order, AddressViewModel address);
        #endregion
    }

    public class OrderBffService : Service, IOrderBffService
    {
        private readonly HttpClient _httpClient;

        public OrderBffService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.Url);
        }

        #region Carrinho

        public async Task<ResponseResult> AddBasketItem(BasketItemViewModel item)
        {
            var itemContent = GetContent(item);

            var response = await _httpClient.PostAsync($"/basket/add-item",
                itemContent);

            if (!HandleErrosResponse(response))
                return await DeserializeObjectResponse<ResponseResult>(response);

            return ReturnOk();
        }

        public async Task<OrderViewModel> GetBasket(Guid basketId)
        {

            var response = await _httpClient.GetAsync($"/basket/{basketId}");

            HandleErrosResponse(response);

            return await DeserializeObjectResponse<OrderViewModel>(response);
        }
        public async Task<int> GetAmountBasket(Guid basketId)
        {
            var response = await _httpClient.GetAsync($"/basket/amount-items/{basketId}");

            HandleErrosResponse(response);

            return await DeserializeObjectResponse<int>(response);
        }

        public async Task<ResponseResult> UpdateBasketItem(BasketItemViewModel item, int quantity)
        {
            var itemContent = GetContent(item);

            var response = await _httpClient.PutAsync($"/basket/update-item/{quantity}", 
                itemContent);

            if (!HandleErrosResponse(response)) 
                return await DeserializeObjectResponse<ResponseResult>(response);

            return ReturnOk();
        }
        public async Task<ResponseResult> DeleteBasketItem(Guid basketId, Guid productId)
        {
            var response = await _httpClient.DeleteAsync($"/basket/remove-item/{basketId}/" +
                $"{productId}");

            if (!HandleErrosResponse(response)) 
                return await DeserializeObjectResponse<ResponseResult>(response);

            return ReturnOk();
        }
        #endregion

        #region Pedido

        public async Task<ResponseResult> ApplyVoucherCode(Guid orderId, string voucher)
        {
            var itemContent = GetContent(voucher);

            var response = await _httpClient.PostAsync($"/order/apply-voucher/{orderId}",
                itemContent);

            if (!HandleErrosResponse(response))
                return await DeserializeObjectResponse<ResponseResult>(response);

            return ReturnOk();
        }

        public async Task<ResponseResult> CreateOrder(OrderTransactionViewModel orderTransaction)
        {
            var orderContent = GetContent(orderTransaction);

            var response = await _httpClient.PostAsync("/order/create-new-order", orderContent);

            if (!HandleErrosResponse(response)) 
                return await DeserializeObjectResponse<ResponseResult>(response);

            return ReturnOk();
        }

        public async Task<OrderViewModel> GetLastOrderClient(Guid clientId)
        {
            var response = await _httpClient.GetAsync($"/order/last-order-client/{clientId}");

            HandleErrosResponse(response);

            return await DeserializeObjectResponse<OrderViewModel>(response);
        }

        public async Task<IEnumerable<OrderViewModel>> GetOrdersByClient(Guid clientId)
        {
            var response = await _httpClient.GetAsync($"/order/list-orders/{clientId}");

            HandleErrosResponse(response);

            return await DeserializeObjectResponse<IEnumerable<OrderViewModel>>(response);
        }

        public OrderTransactionViewModel MapToOrder(OrderViewModel order, 
            AddressViewModel address)
        {
            var orderViewModel = new OrderTransactionViewModel
            {
                TotalValue = order.TotalValue,
                Itens = order.OrderItems,
                Discount = order.DiscountValue,
                VoucherUsed = order.Voucher != null,
                VoucherCode = order.Voucher?.Code
            };

            if (address != null)
            {
                orderViewModel.Address = new AddressViewModel
                {
                    Street = address.Street,
                    Number = address.Number,
                    Neighborhood = address.Neighborhood,
                    PostalCode = address.PostalCode,
                    Complement = address.Complement,
                    City = address.City,
                    State = address.State
                };
            }

            return orderViewModel;
        }

        #endregion
    }
}
