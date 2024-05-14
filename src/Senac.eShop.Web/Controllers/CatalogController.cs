using Microsoft.AspNetCore.Mvc;
using Senac.eShop.Web.Services;

namespace Senac.eShop.Web.Controllers
{
    public class CatalogController : MainController
    {
        private readonly ICatalogService _catalogService;

        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpGet]
        [Route("catalog")]
        [Route("catalog/showcase")]
        public async Task<IActionResult> Index([FromQuery] int pageSize = 8,
            [FromQuery] int page = 1,
            [FromQuery] string productName = null)
        {
            var products = await _catalogService.GetAll(pageSize, page, productName);

            ViewBag.ProductName = productName;
            products.ReferenceAction = "Index";

            return View(products);
        }

        [HttpGet]
        [Route("product-detail/{id}")]
        public async Task<IActionResult> ProductDetail(Guid id)
        {
            var product = await _catalogService.GetById(id);
            return View(product);
        }
    }
}
