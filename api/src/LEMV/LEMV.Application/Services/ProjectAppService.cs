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
    public class ProjectAppService : IProjectAppService
    {
        private readonly IMapper _mapper;
        private readonly IProjectService _service;
        private readonly IProjectRepository _projectRepository;
        private readonly ISkillsRepository _skillsRepository;

        public ProjectAppService(IMapper mapper, IProjectService service, IProjectRepository projectRepository, ISkillsRepository skillsRepository)
        {
            _mapper = mapper;
            _service = service;
            _projectRepository = projectRepository;
            _skillsRepository = skillsRepository;
        }

        public ProjectViewModel GetById(string id)
        {
            var entity = _projectRepository.GetById(id);

            var result = _mapper.Map<ProjectViewModel>(entity);

            result.Skill =  BuildSkill(entity.SkillId, entity.AbilitieIds.ToArray());

            return result;
        }

        public ICollection<ProjectViewModel> GetAll()
        {
            var entities = _projectRepository.GetAll();

            var result = _mapper.Map<ICollection<ProjectViewModel>>(entities);

            foreach (var entity in entities)
            {
                if (entity.SkillId.Equals("") || entity.AbilitieIds == null)
                    continue;

                var item = result.FirstOrDefault(x => x.Id.Equals(entity.Id));
                item.Skill =  BuildSkill (entity.SkillId, entity.AbilitieIds.ToArray());
            }

            return result;
        }

        public ProjectViewModel CreateProject(ProjectSaveViewModel news)
        {
            var entity = _mapper.Map<Project>(news);

            entity = _service.Create(entity);

            var result = _mapper.Map<ProjectViewModel>(entity);

            if (!entity.SkillId.Equals("") && entity.AbilitieIds != null)
                result.Skill =  BuildSkill(entity.SkillId, entity.AbilitieIds.ToArray());

            return result;
        }

        public ProjectViewModel UpdateProject(ProjectSaveViewModel news)
        {
            var entity = _mapper.Map<Project>(news);

            entity = _service.Update(entity);

            var result = _mapper.Map<ProjectViewModel>(entity);

            if (!entity.SkillId.Equals("") && entity.AbilitieIds != null)
                result.Skill = BuildSkill(entity.SkillId, entity.AbilitieIds.ToArray());

            return result;
        }

        public void DeleteProject(string id)
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