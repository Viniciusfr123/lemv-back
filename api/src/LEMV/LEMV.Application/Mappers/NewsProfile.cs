using AutoMapper;
using LEMV.Application.ViewModels;
using LEMV.Domain.Entities;

namespace LEMV.Application.Mappers
{
    public class NewsProfile : Profile
    {
        public NewsProfile()
        {
            CreateMap<News, NewsSaveViewModel>().ReverseMap();
            CreateMap<News, NewsViewModel>().ReverseMap();
        }
    }
}