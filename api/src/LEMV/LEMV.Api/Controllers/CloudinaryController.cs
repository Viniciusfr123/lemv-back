using LEMV.Application.Services.Cloudinary;
using Microsoft.AspNetCore.Mvc;
using LEMV.Application.Services.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace LEMV.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CloudinaryController : ControllerBase
{
        private readonly ICloudinaryService _cloudinaryService;

        public CloudinaryController(ICloudinaryService cloudinaryService)
        {
            _cloudinaryService = cloudinaryService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var result = await _cloudinaryService.UploadAsync(file);

            return Ok(result);
        }
    }
}
