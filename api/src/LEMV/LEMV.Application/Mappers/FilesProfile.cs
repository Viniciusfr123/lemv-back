using AutoMapper;
using LEMV.Application.ViewModels;
using LEMV.Domain.Entities;

namespace LEMV.Application.Mappers
{
    public class FilesProfile : Profile
    {
        public FilesProfile()
        {
            CreateMap<MediaInfo, MediaInfoViewModel>().ReverseMap();
        }
    }
}