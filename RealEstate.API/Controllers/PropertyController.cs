using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.DTOs.Property;
using RealEstate.Application.Interfaces.Property;

namespace RealEstate.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IListPropertiesHandler _listPropertiesHandler;
        private readonly ICreatePropertyHandler _createPropertyHandler;
        private readonly IGetPropertyByIdHandler _getPropertyByIdHandler;
        private readonly IChangePriceHandler _changePriceHandler;
        private readonly IUpdatePropertyHandler _updatePropertyHandler;

        public PropertyController(
            IListPropertiesHandler listPropertiesHandler,
            ICreatePropertyHandler createPropertyHandler,
            IGetPropertyByIdHandler getPropertyByIdHandler,
            IChangePriceHandler changePriceHandler,
            IUpdatePropertyHandler updatePropertyHandler)
        {
            _listPropertiesHandler = listPropertiesHandler;
            _createPropertyHandler = createPropertyHandler;
            _getPropertyByIdHandler = getPropertyByIdHandler;
            _changePriceHandler = changePriceHandler;
            _updatePropertyHandler = updatePropertyHandler;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyDto>>> GetAllProperties([FromQuery] PropertyFilterDto propertyFilterDto)
        {
            var properties = await _listPropertiesHandler.Handle(propertyFilterDto, CancellationToken.None);
            return Ok(properties);
        }

        [HttpPost]
        public async Task<ActionResult<PropertyDto>> CreateProperty([FromBody] CreatePropertyDto createPropertyDto)
        {
            var result = await _createPropertyHandler.Handle(createPropertyDto, CancellationToken.None);
            return CreatedAtAction(nameof(GetPropertyById), new { id = result.PropertyId }, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyDto>> GetPropertyById(int id, CancellationToken cancellationToken)
        {
            var property = await _getPropertyByIdHandler.Handle(id, cancellationToken);
            if (property == null)
            {
                return NotFound();
            }
            return Ok(property);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProperty([FromBody] UpdatePropertyDto updatePropertyDto)
        {
            var updatedProperty = await _updatePropertyHandler.Handle(updatePropertyDto, CancellationToken.None);
            return Ok(updatedProperty);
        }

        [HttpPatch]
        public async Task<IActionResult> ChangePrice([FromBody] ChangePriceDto changePriceDto)
        {
            var updatedProperty = await _changePriceHandler.Handle(changePriceDto, CancellationToken.None);
            return Ok(updatedProperty);
        }
    }
}
