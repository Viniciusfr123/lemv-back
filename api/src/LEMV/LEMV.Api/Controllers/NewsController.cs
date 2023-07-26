using LEMV.Application.Services.Interfaces;
using LEMV.Application.ViewModels;
using LEMV.Domain.Interfaces;
using LEMV.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LEMV.Api.Controllers
{
    public class NewsController : BaseController
    {
        private readonly INewsAppService _newsApp;

        public NewsController(INotificator notificator, INewsAppService newsApp) : base(notificator)
        {
            _newsApp = newsApp;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_newsApp.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var teste = _newsApp.GetById(id);

            if (teste == null)
                _notificator.Handle(new Notification("Notícia não encontrada."));

            return CustomResponse(teste);
        }

        [HttpPost()]
        public IActionResult PostAsync(NewsSaveViewModel news)
        {
            NewsViewModel result =  _newsApp.CreateNews(news);

            return CustomResponse(result);
        }

        [HttpPut]
        public IActionResult PutAsync(NewsSaveViewModel news)
        {
            NewsViewModel result =  _newsApp.UpdateNews(news);

            return CustomResponse(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _newsApp.DeleteNews(id);

            return CustomResponse(id);
        }
    }
}