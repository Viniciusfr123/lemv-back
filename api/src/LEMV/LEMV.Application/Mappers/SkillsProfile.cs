using AutoMapper;
using LEMV.Application.ViewModels;
using LEMV.Domain.Entities;

namespace LEMV.Application.Mappers
{
    public class SkillsProfile : Profile
    {
        public SkillsProfile()
        {
            CreateMap<Skill, SkillViewModel>().ReverseMap();
            CreateMap<Ability, AbilityViewModel>().ReverseMap();
        }
    }
}