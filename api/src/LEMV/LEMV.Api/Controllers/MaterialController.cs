using LEMV.Application.ViewModels;
using LEMV.Domain.Interfaces;
using LEMV.Domain.Interfaces.Repositories;
using LEMV.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace LEMV.Api.Controllers
{
    public class MaterialController : BaseController
    {
        private readonly IMaterialAppService _materialApp;
        private readonly IMaterialRepository _materialRepository;

        public MaterialController(INotificator notificator, IMaterialAppService materialApp, IMaterialRepository materialRepository) : base(notificator)
        {
            _materialApp = materialApp;
            _materialRepository = materialRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_materialRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var teste = _materialRepository.GetById(id);

            if (teste == null)
                _notificator.Handle(new Notification("Notícia não encontrada."));

            return CustomResponse(teste);
        }

        [HttpPost()]
        public IActionResult PostAsync(MaterialViewModel news)
        {
            var result = _materialApp.CreateMaterial(news);

            return CustomResponse(result);
        }

        [HttpPut()]
        public IActionResult PutAsync(MaterialViewModel news)
        {
            var result = _materialApp.UpdateMaterial(news);

            return CustomResponse(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _materialApp.DeleteMaterial(id);

            return CustomResponse(id);
        }
    }
}