using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.UseCases.Auth;
using RealEstate.Common.Contracts.Auth.Request;
using RealEstate.Common.Contracts.Auth.Responses;
using RealEstate.Common.Contracts.PropertyImage.Request;

namespace RealEstate.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly RegisterHandler _registerHandler;
        private readonly LoginHandler _loginHandler;

        public AuthController(RegisterHandler registerHandler, LoginHandler loginHandler)
        {
            _registerHandler = registerHandler;
            _loginHandler = loginHandler;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterAuthRequest request)
        {
            var result = await _registerHandler.Handle(request);
            if (!result.Success)
                return BadRequest(new { message = result.Message });

            return Ok(new { message = result.Message });
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginAuthRequest request)
        {
            var response = await _loginHandler.Handle(request);
            if (response == null)
                return Unauthorized(new { message = "Credenciales invalidas." });

            return Ok(response);
        }
    }
}
