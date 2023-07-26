using AutoMapper;
using LEMV.Application.ViewModels;
using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces;
using LEMV.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LEMV.Application.Services
{
    public class ArtifactAppService : IArtifactAppService
    {
        private readonly IMapper _mapper;
        private readonly IArtifactService _service;
        private readonly IArtifactRepository _artifactRepository;
        private readonly ISkillsRepository _skillsRepository;

        public ArtifactAppService(IMapper mapper, IArtifactService service, IArtifactRepository artifactRepository, ISkillsRepository skillsRepository)
        {
            _mapper = mapper;
            _service = service;
            _artifactRepository = artifactRepository;
            _skillsRepository = skillsRepository;
        }

        public ArtifactViewModel GetById(string id)
        {
            var entity = _artifactRepository.GetById(id);

            var result = _mapper.Map<ArtifactViewModel>(entity);

            result.Skill =  BuildSkill (entity.SkillId, entity.AbilitieIds.ToArray());

            return result;
        }

        public ICollection<ArtifactViewModel> GetAll()
        {
            var entities =  _artifactRepository.GetAll();

            var result = _mapper.Map<ICollection<ArtifactViewModel>>(entities);

            foreach (var entity in entities)
            {
                if (entity.SkillId.Equals("") || entity.AbilitieIds == null)
                    continue;

                var item = result.FirstOrDefault(x => x.Id == entity.Id);
                item.Skill = BuildSkill(entity.SkillId, entity.AbilitieIds.ToArray());
            }

            return result;
        }

        public ArtifactViewModel CreateArtifact(ArtifactSaveViewModel artifact)
        {
            var entity = _mapper.Map<Artifact>(artifact);

            entity = _service.Create(entity);

            var result = _mapper.Map<ArtifactViewModel>(entity);

            if (!entity.SkillId.Equals("") && entity.AbilitieIds != null)
                result.Skill = BuildSkill(entity.SkillId, entity.AbilitieIds.ToArray());

            return result;
        }

        public ArtifactViewModel UpdateArtifact(ArtifactSaveViewModel artifact)
        {
            var entity = _mapper.Map<Artifact>(artifact);

            entity = _service.Update(entity);

            var result = _mapper.Map<ArtifactViewModel>(entity);

            if (!entity.SkillId.Equals("") && entity.AbilitieIds != null)
                result.Skill = BuildSkill(entity.SkillId, entity.AbilitieIds.ToArray());

            return result;
        }

        public void DeleteArtifact(string id)
        {
            _service.Delete(id);
        }

        private SkillViewModel BuildSkill(string skillId, params string[] abilitieIds)
        {
            var skill =  _skillsRepository.GetById(skillId);

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