using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.DTOs.Auth;
using RealEstate.Application.Interfaces.Auth;
using AutoMapper;

namespace RealEstate.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IRegisterHandler _registerHandler;
        private readonly ILoginHandler _loginHandler;
        private readonly IMapper _mapper;

        public AuthController(IRegisterHandler registerHandler, ILoginHandler loginHandler, IMapper mapper)
        {
            _registerHandler = registerHandler;
            _loginHandler = loginHandler;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var result = await _registerHandler.Handle(registerDto);

            if (!result.Success)
                return BadRequest(new { message = result.Message });

            return Ok(new { message = result.Message });
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResultDto>> Login([FromBody] LoginDto loginDto)
        {
            var response = await _loginHandler.Handle(loginDto);
            if (response == null)
                return Unauthorized(new { message = "Credenciales inválidas." });

            return Ok(response);
        }
    }
}
