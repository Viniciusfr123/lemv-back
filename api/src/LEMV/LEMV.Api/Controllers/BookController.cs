using LEMV.Application.Services.Interfaces;
using LEMV.Application.ViewModels;
using LEMV.Domain.Interfaces;
using LEMV.Domain.Interfaces.Repositories;
using LEMV.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace LEMV.Api.Controllers
{
    public class BookController : BaseController
    {
        private readonly IProjectAppService _projectApp;
        private readonly IProjectRepository _projectRepository;

        public BookController(INotificator notificator, IProjectAppService projectApp, IProjectRepository projectRepository) : base(notificator)
        {
            _projectApp = projectApp;
            _projectRepository = projectRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_projectRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var teste = _projectRepository.GetById(id);

            if (teste == null)
                _notificator.Handle(new Notification("Notícia não encontrada."));

            return CustomResponse(teste);
        }

        [HttpPost()]
        public IActionResult PostAsync(ProjectViewModel news)
        {
            ProjectViewModel result = _projectApp.CreateProject(news);

            return CustomResponse(result);
        }

        [HttpPut()]
        public IActionResult PutAsync(ProjectViewModel news)
        {
            ProjectViewModel result = _projectApp.UpdateProject(news);

            return CustomResponse(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _projectApp.DeleteProject(id);

            return CustomResponse(id);
        }
    }
}