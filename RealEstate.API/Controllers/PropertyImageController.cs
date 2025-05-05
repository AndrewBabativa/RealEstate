using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.UseCases;
using RealEstate.Common.Contracts.Auth.Request;

namespace RealEstate.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyImageController : ControllerBase
    {
        private readonly AddImageToPropertyHandler _addImageToPropertyHandler;

        public PropertyImageController(AddImageToPropertyHandler addImageToPropertyHandler)
        {
            _addImageToPropertyHandler = addImageToPropertyHandler;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage([FromForm] AddImageRequest request)
        {
            if (request.Image == null || request.Image.Length == 0)
            {
                return BadRequest("No image provided.");
            }

            await _addImageToPropertyHandler.Handle(request);
            return Ok("Image uploaded and property updated successfully.");
        }
    }

}
