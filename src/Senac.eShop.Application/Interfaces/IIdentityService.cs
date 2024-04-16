using Senac.eShop.Application.DTOs.Request;
using Senac.eShop.Application.DTOs.Response;

namespace Senac.eShop.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<UserRegisteredResponse> RegisterUser(UserRegisteredRequest request);
        Task<UserLoginResponse> Login(UserLoginRequest request);
    }
}
