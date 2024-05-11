using Microsoft.AspNetCore.Mvc;

namespace Senac.eShop.Web.Controllers
{
    public class IdentityController : MainController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
