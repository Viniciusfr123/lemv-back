using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEMV.Application.Services.Interfaces
{
    public interface ICloudinaryService
    {
        public Task<CloudinaryDotNet.Actions.UploadResult> UploadAsync(IFormFile file);
    }
}
