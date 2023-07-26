using LEMV.Domain.Notifications;
using System.Collections.Generic;

namespace LEMV.Domain.Interfaces
{
    public interface INotificator
    {
        void Handle(Notification notificacao);
        ICollection<Notification> GetNotifications();
        bool HasNotification();
    }
}
