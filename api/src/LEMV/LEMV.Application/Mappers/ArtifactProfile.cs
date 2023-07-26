using AutoMapper;
using LEMV.Application.ViewModels;
using LEMV.Domain.Entities;

namespace LEMV.Application.Mappers
{
    public class ArtifactProfile : Profile
    {
        public ArtifactProfile()
        {
            CreateMap<Artifact, ArtifactSaveViewModel>().ReverseMap();
            CreateMap<Artifact, ArtifactViewModel>().ReverseMap();
        }
    }
}