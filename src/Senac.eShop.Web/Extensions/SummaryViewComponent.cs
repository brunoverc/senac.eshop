using Microsoft.AspNetCore.Mvc;

namespace Senac.eShop.Web.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            // ReSharper disable once Mvc.ViewComponentViewNotResolved
            return View();
        }
    }
}
