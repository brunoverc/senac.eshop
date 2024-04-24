using Microsoft.AspNetCore.Mvc;
using Senac.eShop.Web.Models;

namespace Senac.eShop.Web.Extensions
{
    public class PaginacaoViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IPagedList pagedModel)
        {
            // ReSharper disable once Mvc.ViewComponentViewNotResolved
            return base.View(pagedModel);
        }
    }
}
