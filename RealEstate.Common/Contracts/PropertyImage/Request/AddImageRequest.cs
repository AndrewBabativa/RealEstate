using Microsoft.AspNetCore.Http;

namespace RealEstate.Common.Contracts.PropertyImage.Request
{
    public class RegisterAuthRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

}
