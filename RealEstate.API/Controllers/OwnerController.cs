using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.DTOs.Owner;
using RealEstate.Application.Interfaces.Owner;

namespace RealEstate.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OwnersController : ControllerBase
    {
        private readonly ICreateOwnerHandler _createOwnerHandler;

        public OwnersController(ICreateOwnerHandler createOwnerHandler)
        {
            _createOwnerHandler = createOwnerHandler;
        }

        [HttpPost]
        public async Task<ActionResult<OwnerDto>> CreateOwner([FromForm] CreateOwnerDto createOwnerDto, CancellationToken cancellationToken)
        {
            var response = await _createOwnerHandler.Handle(createOwnerDto, cancellationToken);
            return CreatedAtAction(nameof(GetOwnerById), new { id = response.OwnerId }, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OwnerDto>> GetOwnerById(int id)
        {
            return StatusCode(StatusCodes.Status501NotImplemented, "This endpoint is not yet implemented.");
        }
    }
}
