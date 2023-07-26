using AutoMapper;
using LEMV.Application.ViewModels;
using LEMV.Domain.Entities;

namespace LEMV.Application.Mappers
{
    public class MediaInfoProfile : Profile
    {
        public MediaInfoProfile()
        {
            CreateMap<MediaInfoViewModel, MediaInfo>().ReverseMap();
        }
    }
}
