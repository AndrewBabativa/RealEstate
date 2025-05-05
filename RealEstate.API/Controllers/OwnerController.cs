using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.UseCases;
using RealEstate.Common.Contracts.Owner.Request;
using RealEstate.Common.Contracts.Owner.Responses;
using Microsoft.AspNetCore.Authorization;

namespace RealEstate.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OwnersController : ControllerBase
    {
        private readonly CreateOwnerHandler _createOwnerHandler;

        public OwnersController(CreateOwnerHandler createOwnerHandler)
        {
            _createOwnerHandler = createOwnerHandler; 
        }

        [HttpPost]
        public async Task<ActionResult<OwnerResponse>> CreateOwner([FromForm] CreateOwnerRequest request, CancellationToken cancellationToken)
        {
            var response = await _createOwnerHandler.Handle(request, cancellationToken); 
            return CreatedAtAction(nameof(GetOwnerById), new { id = response.OwnerId }, response);
        }

        [HttpGet("{id}")]
        public IActionResult GetOwnerById(int id)
        {
            return Ok(); 
        }
    }
}
