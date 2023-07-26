using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces;
using LEMV.Domain.Interfaces.Repositories;
using System;
using System.IO;

namespace LEMV.Domain.Services
{
    public class FilesService : IFilesService
    {
        private readonly IFilesRepository _filesRepository;

        public FilesService(IFilesRepository filesRepository)
        {
            _filesRepository = filesRepository;
        }

        public MediaInfo Upload(string fileName, Stream fileStream, string contentType)
        {
            return _filesRepository.Upload(fileName, fileStream, contentType);
        }

        public void Download(string id, Stream fileStream)
        {
            _filesRepository.Download(id, fileStream);
        }

        public MediaInfo Details(string id)
        {
            return _filesRepository.Details(id);
        }
    }
}
