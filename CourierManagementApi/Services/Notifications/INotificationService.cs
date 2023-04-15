using ApproveX_API.Models.Notifications;

namespace ApproveX_API.Services.Notifications
{
    public interface INotificationService
    {
        public Notification GetById(Guid id, int userId);
        public List<Notification> GetNotifications(int userId);
        public Notification SaveNotification(Notification notification, int userId);
        public int BroadcastNotification(Guid id, int userId);

    }
}
