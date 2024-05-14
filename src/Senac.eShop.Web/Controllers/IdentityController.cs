using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senac.eShop.Web.Models;
using Senac.eShop.Web.Services;

namespace Senac.eShop.Web.Controllers
{
    public class IdentityController : MainController
    {
        private readonly IAuthService _authenticationService;

        public IdentityController(
            IAuthService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpGet]
        [Route("new-account")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("new-account")]
        public async Task<IActionResult> Register(UserRegister user)
        {
            if (!ModelState.IsValid) return View(user);

            var response = await _authenticationService.NewUSer(user);

            if (ResponseWithError(response.ResponseResult)) return View(user);

            await _authenticationService.AccomplishLogin(response);

            return RedirectToAction("Index", "Catalog");
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLogin userLogin, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (!ModelState.IsValid) return View(userLogin);

            var resposta = await _authenticationService.Login(userLogin);

            if (ResponseWithError(resposta.ResponseResult)) return View(userLogin);

            await _authenticationService.AccomplishLogin(resposta);

            if (string.IsNullOrEmpty(returnUrl)) return RedirectToAction("Index", "Catalog");

            return LocalRedirect(returnUrl);
        }

        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authenticationService.Logout();
            return RedirectToAction("Index", "Catalog");
        }
    }
}
