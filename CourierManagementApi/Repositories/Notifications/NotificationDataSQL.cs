using ApproveX_API.Models.Notifications;
using ApproveX_API.Repositories.DB;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApproveX_API.Repositories.Notifications
{
    public class NotificationDataSQL : INotificationData
    {
        private readonly ApproveXContext _aux;
        private readonly IConfiguration _config;

        public NotificationDataSQL(ApproveXContext paramContext, IConfiguration param)
        {
            _aux = paramContext;
            _config = param;
        }

        public Notification GetById(Guid id, int userId)
        {
            try
            {
                var query = "execute sp_notifications_GetList @userId = @userId,  @id = @id ";
                object[] parameters = {
                    new SqlParameter(parameterName: "@userId", value: userId),
                    new SqlParameter(parameterName: "@id", value: id),
                };


                var result = _aux.Notifications.FromSqlRaw(query, parameters).ToList().FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Notification> GetNotifications(int userId)
        {
            try
            {
                var query = "execute sp_notifications_GetList @userId = @userId";
                object[] parameters = {
                    new SqlParameter(parameterName: "@userId", value: userId),
                };
                var result = _aux.Notifications.FromSqlRaw(query, parameters).ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Notification SaveNotification(Notification notification, int userId)
        {
            try
            {
                var query = @"execute sp_notifications_Save @userId = @userId,
                                    @id = @id,
                                    @subject = @subject,
                                    @resultId = @resultId,
                                    @resultComments = @resultComments,
                                    @transactionId = @transactionId,
                                    @data = @data,
                                    @statusId = @statusId,
                                    @fromName = @fromName,
                                    @payload = @payload,
                                    @toUserId = @toUserId

                                    ";
                object[] parameters = {
                    new SqlParameter(parameterName: "@userId", value: userId),
                    new SqlParameter(parameterName: "@id", value: notification.id),
                    new SqlParameter(parameterName: "@subject", value: notification.subject),
                    new SqlParameter(parameterName: "@resultId", value: notification.resultId),
                    new SqlParameter(parameterName: "@resultComments", value: notification.resultComments),
                    new SqlParameter(parameterName: "@transactionId", value: notification.transactionId),
                    new SqlParameter(parameterName: "@data", value: notification.data),
                    new SqlParameter(parameterName: "@statusId", value: notification.statusId),
                    new SqlParameter(parameterName: "@fromName", value: notification.fromName),
                    new SqlParameter(parameterName: "@payload", value: notification.payload),
                    new SqlParameter(parameterName: "@toUserId", value: notification.toUserId),

                };
                var result = _aux.Notifications.FromSqlRaw(query, parameters).ToList().FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
