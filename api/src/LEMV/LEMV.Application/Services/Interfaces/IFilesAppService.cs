using LEMV.Application.ViewModels;
using System;
using System.IO;

namespace LEMV.Application.Services.Interfaces
{
    public interface IFilesAppService
    {
        MediaInfoViewModel Upload(string fileName, Stream fileStream, string contentType);
        MediaInfoViewModel Download(string id, Stream fileStream);
    }
}
