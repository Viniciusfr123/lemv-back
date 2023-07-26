using LEMV.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LEMV.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly INotificator _notificator;

        protected BaseController(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected IActionResult CustomResponse(object result)
        {
            if (_notificator.HasNotification())
            {
                return BadRequest(new
                {
                    status = false,
                    data = _notificator.GetNotifications()
                });
            }

            return Ok(new { status = true, data = result });
        }
    }
}
