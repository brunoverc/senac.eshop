using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Senac.eShop.Core.Communication;
using Senac.eShop.Web.Extensions;
using Senac.eShop.Web.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UserLoginResponse = Senac.eShop.Web.Models.UserLoginResponse; //Necessário pois é ambiguo

namespace Senac.eShop.Web.Services
{
    public interface IAuthService
    {
    }

    public class AuthenticationService
    {
    }
}
