using LEMV.Domain.Entities;
using MongoDB.Bson;
using System.IO;

namespace LEMV.Domain.Interfaces.Repositories
{
    public interface IFilesRepository
    {
        MediaInfo Upload(string fileName, Stream fileStream, string contentType);
        void Download(string id, Stream fileStream);
        MediaInfo Details(string id);
    }
}
