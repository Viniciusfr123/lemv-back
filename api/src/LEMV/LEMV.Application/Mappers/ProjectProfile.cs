using AutoMapper;
using LEMV.Application.ViewModels;
using LEMV.Domain.Entities;

namespace LEMV.Application.Mappers
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectViewModel>().ReverseMap();
            CreateMap<Project, ProjectSaveViewModel>().ReverseMap();

            CreateMap<ProjectStep, ProjectStepViewModel>().ReverseMap();
        }
    }
}