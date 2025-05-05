using Microsoft.AspNetCore.Http;

namespace RealEstate.Common.Contracts.Auth.Request
{
    public class LoginAuthRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

}
