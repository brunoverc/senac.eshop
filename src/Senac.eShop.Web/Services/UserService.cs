
namespace Senac.eShop.Web.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _accessor;

        public UserService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Name => throw new NotImplementedException();

        public string GetUserEmail()
        {
            return "bruno@senac.br";
        }

        public Guid GetUserId()
        {
            return Guid.NewGuid();
        }

        public string GetUserToken()
        {
            return "";
        }

        public bool IsAuthenticated()
        {
            return true;
        }

        public HttpContext GetHttpContext()
        {
            return _accessor.HttpContext;
        }
    }
}
