using Microsoft.AspNetCore.Mvc;
using Senac.eShop.Web.Models;
using Senac.eShop.Web.Services;

namespace Senac.eShop.Web.Controllers
{
    public class BasketController : MainController
    {
        private readonly IOrderBffService _orderBffService;
        private readonly IUserService _userService;

        private Guid userId;
        
        public BasketController(IOrderBffService orderBffService,
            IUserService userService)
        {
            _orderBffService = orderBffService;
            _userService = userService;

            userId = _userService.GetUserId();
        }

        [Route("basket")]
        public async Task<IActionResult> Index()
        {
            return View(await _orderBffService.GetBasket(userId));
        }

        [HttpPost]
        [Route("basket/add-item")]
        public async Task<IActionResult> AddBasketItem(BasketItemViewModel itemCarrinho)
        {
            var response = await _orderBffService.AddBasketItem(itemCarrinho);

            if (ResponseWithError(response)) return View("Index", await _orderBffService.GetBasket(itemCarrinho.BasketId));

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("basket/update-item")]
        public async Task<IActionResult> UpdateBasketItem(Guid productId, int amount)
        {
            var item = new BasketItemViewModel { ProductId = productId, Amount = amount };
            var resposta = await _orderBffService.UpdateBasketItem(item, amount);

            if (ResponseWithError(resposta)) return View("Index", await _orderBffService.GetBasket(userId));

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("basket/remove-item")]
        public async Task<IActionResult> DeleteBasketItem(Guid basketId, Guid productId)
        {
            var resposta = await _orderBffService.DeleteBasketItem(basketId, productId);

            if (ResponseWithError(resposta)) return View("Index", await _orderBffService.GetBasket(userId));

            return RedirectToAction("Index");
        }

        
    }
}
