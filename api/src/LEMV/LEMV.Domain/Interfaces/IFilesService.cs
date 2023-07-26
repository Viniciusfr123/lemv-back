using LEMV.Domain.Entities;
using System;
using System.IO;

namespace LEMV.Domain.Interfaces
{
    public interface IFilesService
    {
        MediaInfo Upload(string fileName, Stream fileStream, string contentType);
        void Download(string id, Stream fileStream);
        MediaInfo Details(string id);
    }
}
