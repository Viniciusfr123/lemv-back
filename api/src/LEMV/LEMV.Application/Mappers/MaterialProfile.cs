using AutoMapper;
using LEMV.Application.ViewModels;
using LEMV.Domain.Entities;

namespace LEMV.Application.Mappers
{
    public class MaterialProfile : Profile
    {
        public MaterialProfile()
        {
            CreateMap<Material, MaterialViewModel>().ReverseMap();
        }
    }
}