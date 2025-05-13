using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.DTOs.PropertyImage;
using RealEstate.Application.Interfaces.Property;

namespace RealEstate.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyImageController : ControllerBase
    {
        private readonly IAddImageToPropertyHandler _addImageToPropertyHandler;

        public PropertyImageController(IAddImageToPropertyHandler addImageToPropertyHandler)
        {
            _addImageToPropertyHandler = addImageToPropertyHandler;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage([FromForm] PropertyImageDto propertyImageDto)
        {
            await _addImageToPropertyHandler.Handle(propertyImageDto);
            return Ok("Se cargó la imagen correctamente.");
        }
    }

}
