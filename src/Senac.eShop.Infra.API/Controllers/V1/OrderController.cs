using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senac.eShop.Application.Interfaces;
using Senac.eShop.Application.ViewModel;
using Senac.eShop.Core.Enums;

namespace Senac.eShop.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/order")]
    public class OrderController : Controller
    {
        protected readonly IOrderAppService _orderAppService;

        public OrderController(IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService;
        }

        [HttpPost("createNewOrder")]
        public ActionResult CreateNewOrderAsync([FromBody] OrderViewModel model)
        {
            var result = _orderAppService.SetCreateNewOrder(model);
            return Ok(result);
        }

        [HttpPost("insertNewItem")]
        public ActionResult<IEnumerable<OrderItemViewModel>> InsertNewItem([FromBody] OrderItemViewModel model,
            Guid orderId)
        {
            var result = _orderAppService.SetInsertNewItem(model, orderId);
            return Ok(result);
        }

        [HttpDelete("{orderItemId}/{orderId}")]
        public ActionResult<IEnumerable<OrderItemViewModel>> DeleteItem(Guid orderItemId, Guid orderId)
        {
            var result = _orderAppService.DeleteItemInOrder(orderItemId, orderId);
            return Ok(result);
        }

        [HttpPut("address-delivery/{orderId}")]
        public ActionResult<OrderViewModel> SetAddressDelivery(Guid orderId, [FromBody] AddressViewModel addressModel)
        {
            var result = _orderAppService.SetAddressDelivery(orderId, addressModel);
            return result;
        }

        [HttpPut("quantity-item/{orderItemId}/{newQuantity}")]
        public bool UpdateQuantityItem(Guid orderItemId, int newQuantity)
        {
            _orderAppService.UpdateQuantityItemInOrder(orderItemId, newQuantity);
            return true;
        }

        [HttpPut("update-status-order/{orderId}/{newStatus}")]
        public ActionResult<OrderViewModel> UpdateStatus(Guid orderId, OrderStatus newStatus)
        {
            var result = _orderAppService.UpdateStatusOrder(orderId, newStatus);
            return result;
        }

        [HttpPut("apply-voucher/{orderId}/{code}")]
        public ActionResult<OrderViewModel> SetApplyVoucher(Guid orderId, string code)
        {
            var result = _orderAppService.SetApplyVoucher(orderId, code);
            return result;
        }
    }
}
