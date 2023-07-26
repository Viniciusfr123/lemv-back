using LEMV.Application.Services.Interfaces;
using LEMV.Application.ViewModels;
using LEMV.Domain.Interfaces;
using LEMV.Domain.Interfaces.Repositories;
using LEMV.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace LEMV.Api.Controllers
{
    public class SkillsController : BaseController
    {
        private readonly ISkillsAppService _skillsApp;
        private readonly ISkillsRepository _skillsRepository;

        public SkillsController(INotificator notificator, ISkillsAppService skillsApp, ISkillsRepository skillsRepository) : base(notificator)
        {
            _skillsApp = skillsApp;
            _skillsRepository = skillsRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_skillsRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var result = _skillsRepository.GetById(id);

            if (result == null)
                _notificator.Handle(new Notification("Habilidade não encontrada."));

            return CustomResponse(result);
        }

        [HttpPost()]
        public IActionResult PostAsync(SkillViewModel skill)
        {
            SkillViewModel result = _skillsApp.CreateSkill(skill);

            return CustomResponse(result);
        }

        [HttpPut()]
        public IActionResult PutAsync(SkillViewModel skill)
        {
            SkillViewModel result = _skillsApp.UpdateSkill(skill);

            return CustomResponse(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _skillsApp.DeleteSkill(id);

            return CustomResponse(id);
        }
    }
}
