using LEMV.Application.Services.Interfaces;
using LEMV.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace LEMV.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFilesAppService _filesAppService;

        public FilesController(IFilesAppService filesAppService)
        {
            _filesAppService = filesAppService;
        }

        [HttpPost("upload")]
        [RequestSizeLimit(15 * 1024 * 1024)]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file.Length > 0)
            {
                try
                {
                    using Stream filestream = new MemoryStream();
                    await file.CopyToAsync(filestream);
                    filestream.Flush();

                    var fileMetadata = _filesAppService.Upload(file.FileName, filestream, file.ContentType);

                    return Ok(new
                    {
                        Status = true,
                        Value = fileMetadata
                    });
                }
                catch (Exception ex)
                {
                    return StatusCode(501, new
                    {
                        Status = false,
                        ex.Message
                    });
                }
            }
            else
            {
                return BadRequest(new
                {
                    Status = false,
                    Message = "Nenhum arquivo selecionado"
                });
            }
        }

        [HttpGet("download/{id}")]
        public IActionResult Download(string id)
        {
            if (id.Equals(""))
                return null;

            using MemoryStream file = new();

            MediaInfoViewModel metadata = _filesAppService.Download(id, file);

            return new FileContentResult(file.ToArray(), metadata.Format);
        }
    }
}
