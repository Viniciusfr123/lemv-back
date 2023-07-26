using AutoMapper;
using LEMV.Application.Services.Interfaces;
using LEMV.Application.ViewModels;
using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces;
using System.Threading.Tasks;

namespace LEMV.Application.Services
{
    public class SkillsAppService : ISkillsAppService
    {
        private readonly IMapper _mapper;
        private readonly ISkillsService _service;

        public SkillsAppService(IMapper mapper, ISkillsService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public SkillViewModel CreateSkill(SkillViewModel news)
        {
            var entity = _mapper.Map<Skill>(news);

            entity =  _service.Create(entity);

            return _mapper.Map<SkillViewModel>(entity);
        }

        public SkillViewModel UpdateSkill(SkillViewModel news)
        {
            var entity = _mapper.Map<Skill>(news);

            entity = _service.Update(entity);

            return _mapper.Map<SkillViewModel>(entity);
        }

        public void DeleteSkill(string id)
        {
            _service.Delete(id);
        }
    }
}