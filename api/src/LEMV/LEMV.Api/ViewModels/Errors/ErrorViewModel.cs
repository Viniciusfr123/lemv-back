using LEMV.Domain.Notifications;
using System.Collections.Generic;

namespace LEMV.Api.ViewModels
{
    public class ErrorViewModel
    {
        public int StatusCode { get; set; }
        public ICollection<Notification> Errors { get; set; }
    }
}
