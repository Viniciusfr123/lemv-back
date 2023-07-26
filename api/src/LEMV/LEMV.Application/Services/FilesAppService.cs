using AutoMapper;
using LEMV.Application.Services.Interfaces;
using LEMV.Application.ViewModels;
using LEMV.Domain.Interfaces;
using System;
using System.IO;

namespace LEMV.Application.Services
{
    public class FilesAppService : IFilesAppService
    {
        private readonly IMapper _mapper;
        private readonly IFilesService _filesService;

        public FilesAppService(IMapper mapper, IFilesService filesService)
        {
            _mapper = mapper;
            _filesService = filesService;
        }

        public MediaInfoViewModel Upload(string fileName, Stream fileStream, string contentType)
        {
            return _mapper.Map<MediaInfoViewModel>(
                _filesService.Upload(fileName, fileStream, contentType));
        }

        public MediaInfoViewModel Download(string id, Stream fileStream)
        {
            _filesService.Download(id, fileStream);

            return _mapper.Map<MediaInfoViewModel>(
                _filesService.Details(id));
        }

    }
}
