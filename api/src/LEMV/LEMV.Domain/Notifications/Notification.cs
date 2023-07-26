namespace LEMV.Domain.Notifications
{
    public class Notification
    {
        private readonly string _message;

        public string Message => _message;

        public Notification(string message)
        {
            _message = message.Trim();
        }
    }
}
