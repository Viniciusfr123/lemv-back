using LEMV.Domain.Interfaces;
using System.Collections.Generic;

namespace LEMV.Domain.Notifications
{
    public class Notificator : INotificator
    {
        private ICollection<Notification> _notifications;

        public Notificator()
        {
            _notifications = new List<Notification>();
        }

        public ICollection<Notification> GetNotifications()
        {
            return _notifications;
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }

        public bool HasNotification()
        {
            return _notifications.Count > 0;
        }
    }
}
