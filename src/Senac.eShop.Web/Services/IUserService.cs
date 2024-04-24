using System.Security.Claims;

namespace Senac.eShop.Web.Services
{
    public interface IUserService
    {
        string Name { get; }
        Guid GetUserId();
        string GetUserEmail();
        string GetUserToken();
        bool IsAuthenticated();
    }
}
