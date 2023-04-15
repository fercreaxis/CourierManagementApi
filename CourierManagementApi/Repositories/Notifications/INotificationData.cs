using ApproveX_API.Models.Notifications;

namespace ApproveX_API.Repositories.Notifications
{
    public interface INotificationData
    {
        public Notification GetById(Guid id, int userId);
        public List<Notification> GetNotifications(int userId);
        public Notification SaveNotification(Notification notification, int userId);

    }
}
