using AutoMapper;
using LEMV.Application.Services.Interfaces;
using LEMV.Application.ViewModels;
using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces;
using LEMV.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LEMV.Application.Services
{
    public class NewsAppService : INewsAppService
    {
        private readonly IMapper _mapper;
        private readonly INewsService _service;
        private readonly ISkillsRepository _skillsRepository;
        private readonly INewsRepository _newsRepository;

        public NewsAppService(IMapper mapper, INewsService service, ISkillsRepository skillsRepository, INewsRepository newsRepository)
        {
            _mapper = mapper;
            _service = service;
            _skillsRepository = skillsRepository;
            _newsRepository = newsRepository;
        }

        public NewsViewModel GetById(string id)
        {
            var entity =  _newsRepository.GetById(id);

            var result = _mapper.Map<NewsViewModel>(entity);

            if (entity != null && !entity.SkillId.Equals("") && entity.AbilitieIds != null)
                result.Skill = BuildSkill(entity.SkillId, entity.AbilitieIds.ToArray());

            return result;
        }

        public ICollection<NewsViewModel> GetAll()
        {
            var entities = _newsRepository.GetAll();

            var result = _mapper.Map<ICollection<NewsViewModel>>(entities);

            foreach (var entity in entities)
            {
                if (entity.SkillId.Equals("")|| entity.AbilitieIds == null)
                    continue;

                var item = result.FirstOrDefault(x => x.Id.Equals(entity.Id));
                item.Skill = BuildSkill(entity.SkillId, entity.AbilitieIds.ToArray());
            }

            return result;
        }

        public NewsViewModel CreateNews(NewsSaveViewModel news)
        {
            var entity = _mapper.Map<News>(news);

            entity =  _service.Create(entity);

            var result = _mapper.Map<NewsViewModel>(entity);

            if (!entity.SkillId.Equals("") && entity.AbilitieIds != null)
                result.Skill = BuildSkill(entity.SkillId, entity.AbilitieIds.ToArray());

            return result;
        }

        public NewsViewModel UpdateNews(NewsSaveViewModel news)
        {
            var entity = _mapper.Map<News>(news);

            entity =  _service.Update(entity);

            var result = _mapper.Map<NewsViewModel>(entity);

            if (!entity.SkillId.Equals("") && entity.AbilitieIds != null)
                result.Skill = BuildSkill(entity.SkillId, entity.AbilitieIds.ToArray());

            return result;
        }

        public void DeleteNews(string id)
        {
            _service.Delete(id);
        }

        private SkillViewModel BuildSkill(string skillId, params string[] abilitieIds)
        {
            var skill = _skillsRepository.GetById(skillId);

            var resultado = new SkillViewModel
            {
                Id = skill.Id,
                Code = skill.Code,
                Description = skill.Description,
                Abilities = _mapper.Map<ICollection<AbilityViewModel>>(
                    skill.Abilities.Where(x => abilitieIds.Contains(x.Id))
                )
            };

            return resultado;
        }
    }
}