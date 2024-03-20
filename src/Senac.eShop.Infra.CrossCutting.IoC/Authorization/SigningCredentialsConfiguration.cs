using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Senac.eShop.Infra.CrossCutting.IoC.Authorization
{
    public class SigningCredentialsConfiguration
    {
        private const string SecretKey = "senac@90ddc8111f4941e2b110e54115893ac9";
        public static readonly SymmetricSecurityKey Key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
        public SigningCredentials SigningCredentials { get; }

        public SigningCredentialsConfiguration()
        {
            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
