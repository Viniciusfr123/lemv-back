using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using LEMV.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEMV.Application.Services.Cloudinary
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Account _account;
        private readonly CloudinaryDotNet.Cloudinary _cloudinary;

        public CloudinaryService(Account account)
        {
            _account = account;

            var cloudinaryConfig = new CloudinaryDotNet.Cloudinary(new Account(
                _account.Cloud,
                _account.ApiKey,
                _account.ApiSecret
            ));
            _cloudinary = cloudinaryConfig;
        }

        public async Task<CloudinaryDotNet.Actions.UploadResult> UploadAsync(IFormFile file)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
                Folder = "lemv", // opcional: nome da pasta onde o arquivo será armazenado
                Overwrite = false // opcional: se deve sobrescrever arquivos com o mesmo nome
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            return uploadResult;
        }
    }
}
