using Microsoft.AspNetCore.Mvc;
using Senac.eShop.Application.Interfaces;
using Senac.eShop.Application.ViewModel;

namespace Senac.eShop.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/basket")]
    public class BasketController : Controller
    {
        protected readonly IBasketAppService _basketAppService;

        public BasketController(IBasketAppService basketAppService)
        {
            _basketAppService = basketAppService;
        }

        [HttpPost]
        public ActionResult<BasketViewModel> AddBasket([FromBody] BasketViewModel viewModel)
        {
            var result = _basketAppService.AddBasket(viewModel);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<BasketViewModel> GetById(Guid id)
        {
            var result = _basketAppService.GetById(id);
            return Ok(result);
        }

        [HttpPost("add-item")]
        public ActionResult<IEnumerable<BasketItemViewModel>> AddItemBasket([FromBody] BasketItemViewModel viewModel)
        {
            var result = _basketAppService.AddItemBasket(viewModel);
            return Ok(result);
        }

        [HttpDelete("remove-item/{idBasketItem}")]
        public ActionResult<IEnumerable<BasketItemViewModel>> RemoveItemBasket(Guid idBasketItem)
        {
            var result = _basketAppService.RemoveItemBasket(idBasketItem);
            return Ok(result);
        }

        [HttpPut("update-item/{idBasketItem}/{quantity}")]
        public ActionResult UpdateItemQuantity(Guid idBasketItem, int quantity)
        {
            _basketAppService.UpdateItemQuantity(idBasketItem, quantity);
            return Ok();
        }

        public ActionResult ClearBasket(Guid basketId)
        public ActionResult ClearBasket(Guid basketId)
        {
            _basketAppService.ClearBasket(basketId);
            return Ok();
        }
    }
}
