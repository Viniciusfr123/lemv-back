using LEMV.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LEMV.Api.Controllers
{
    public class PermissionsController : BaseController
    {
        public PermissionsController(INotificator notificator) : base(notificator)
        {
        }

        [HttpGet]
        public void Get()
        {

            throw new NotImplementedException();
        }
    }
}
