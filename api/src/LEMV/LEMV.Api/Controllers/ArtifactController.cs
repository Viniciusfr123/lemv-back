using LEMV.Application.ViewModels;
using LEMV.Domain.Interfaces;
using LEMV.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace LEMV.Api.Controllers
{
    public class ArtifactController : BaseController
    {
        private readonly IArtifactAppService _artifactAppService;

        public ArtifactController(INotificator notificator, IArtifactAppService artifactAppService) : base(notificator)
        {
            _artifactAppService = artifactAppService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_artifactAppService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var teste = _artifactAppService.GetById(id);

            if (teste == null)
                _notificator.Handle(new Notification("Notícia não encontrada."));

            return CustomResponse(teste);
        }

        [HttpPost()]
        public IActionResult PostAsync(ArtifactSaveViewModel news)
        {
            ArtifactViewModel result = _artifactAppService.CreateArtifact(news);

            return CustomResponse(result);
        }

        [HttpPut]
        public IActionResult PutAsync(ArtifactSaveViewModel news)
        {
            ArtifactViewModel result = _artifactAppService.UpdateArtifact(news);

            return CustomResponse(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _artifactAppService.DeleteArtifact(id);

            return CustomResponse(id);
        }
    }
}