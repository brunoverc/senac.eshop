namespace Senac.eShop.Application.DTOs.Response
{
    public class UserRegisteredResponse
    {
        public bool Sucess { get; private set; }
        public List<string> Errors { get; private set; }

        public UserRegisteredResponse() =>
            Errors = new List<string>();

        public UserRegisteredResponse(bool success = true) : this() =>
            Sucess = success;

        public void AddErrors(IEnumerable<string> errors) =>
            Errors.AddRange(errors);
    }
}
