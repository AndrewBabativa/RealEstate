using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.UseCases;
using RealEstate.Common.Contracts.Property.Filters;
using RealEstate.Common.Contracts.Property.Request;
using RealEstate.Common.Contracts.Property.Responses;

namespace RealEstate.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly ListPropertiesHandler _listPropertiesHandler;
        private readonly CreatePropertyHandler _createPropertyHandler;
        private readonly GetPropertyByIdHandler _getPropertyByIdHandler;
        private readonly ChangePriceHandler _changePriceHandler;
        private readonly UpdatePropertyHandler _updatePropertyHandler;

        public PropertyController(ListPropertiesHandler listPropertiesHandler,
                                  CreatePropertyHandler createPropertyHandler,
                                  GetPropertyByIdHandler getPropertyByIdHandler,
                                  ChangePriceHandler changePriceHandler,
                                  UpdatePropertyHandler updatePropertyHandler)
        {
            _listPropertiesHandler = listPropertiesHandler;
            _createPropertyHandler = createPropertyHandler;
            _getPropertyByIdHandler = getPropertyByIdHandler;
            _changePriceHandler = changePriceHandler;
            _updatePropertyHandler = updatePropertyHandler;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyResponse>>> GetAllProperties([FromQuery] PropertyFilter filter)
        {
            var properties = await _listPropertiesHandler.Handle(filter, CancellationToken.None);
            return Ok(properties);
        }

        [HttpPost]
        public async Task<ActionResult<PropertyResponse>> CreateProperty([FromBody] CreatePropertyRequest request)
        {
            var result = await _createPropertyHandler.Handle(request, CancellationToken.None);
            return CreatedAtAction(nameof(GetPropertyById), new { id = result.PropertyId }, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPropertyById(int id, CancellationToken cancellationToken)
        {
            var property = await _getPropertyByIdHandler.Handle(id, cancellationToken);
            return Ok(property);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProperty([FromBody] UpdatePropertyRequest request)
        {
            var updatedProperty = await _updatePropertyHandler.Handle(request, CancellationToken.None);
            return Ok(updatedProperty);
        }


        [HttpPatch]
        public async Task<IActionResult> ChangePrice([FromBody] ChangePriceRequest request)
        {
            var updatedProperty = await _changePriceHandler.Handle(request, CancellationToken.None);
            return Ok(updatedProperty);
        }
    }
}
