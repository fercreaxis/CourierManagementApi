using ApproveX_API.Repositories.Devices;
using ApproveX_API.Repositories.Notifications;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Builder.Extensions;
using Notification = ApproveX_API.Models.Notifications.Notification;

namespace ApproveX_API.Services.Notifications
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationData _data;
        private readonly IDeviceData _device;

        public NotificationService(INotificationData paramContext, IDeviceData device)
        {
            _data = paramContext;
            _device = device;
        }

        public Notification GetById(Guid id, int userId)
        {
            return _data.GetById(id, userId);
        }

        public List<Notification> GetNotifications(int userId)
        {
            return _data.GetNotifications(userId);
        }

        public Notification SaveNotification(Notification notification, int userId)
        {
            return _data.SaveNotification(notification, userId);
        }

        public int BroadcastNotification(Guid id, int userId)
        {
            var notification = GetById(id, userId);
            {
                var devices = _device.GetDevicesByUser(notification.toUserId);

                foreach (var device in devices)
                {
                    _ = SendNotification(device.token, notification);
                }

                return devices.Count;
            }
        }

        private async Task<string> SendNotification(string token, Notification notification)
        {
            try
            {
                var credential = GoogleCredential.FromServiceAccountCredential(GetServiceAccountCredential());
                var app = FirebaseApp.GetInstance("[DEFAULT]") ?? FirebaseApp.Create( new AppOptions()
                {
                    ProjectId = "approve-x",
                    ServiceAccountId = "firebase-adminsdk-uwzvi@approve-x.iam.gserviceaccount.com",
                    Credential = credential,
                    
                });

                var message = new Message()
                {
                    Token = token,
                    Notification = new FirebaseAdmin.Messaging.Notification()
                    {
                        Title = "Nuevo Mensaje!",
                        Body = notification.subject

                    },
                    Data = new Dictionary<string, string>()
                    {
                        {"subject", notification.subject},
                        {"data", notification.data},
                        {"date", notification.lastUpdateDate.ToString() ?? string.Empty},
                        {"fromName", notification.fromName},
                        {"id", notification.id.ToString()},
                        {"status", string.Empty}
                    },
                };
                var messaging = FirebaseMessaging.GetMessaging(app);
                var response = await messaging.SendAsync(message).ConfigureAwait(true);
                return "";

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "";
            }
        }

        private static ServiceAccountCredential GetServiceAccountCredential()
        {
            // service account email address
            const string serviceAccount = "firebase-adminsdk-uwzvi@approve-x.iam.gserviceaccount.com";

            // import service account key p12 certificate.
            //var certificate = new X509Certificate2(GetCertificate(),"notasecret", X509KeyStorageFlags.DefaultKeySet);

            string privateKey =
                "-----BEGIN PRIVATE KEY-----MIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQD5vuxXYWP1EEQJhzFdolkNJrI2Gpd7+Lr77f7m75XB6AMVEcRwTy+313Oktw120I7FqOE5HlffgV+tmYhWY+gMupRI6jsDZFqT2pv9UjgKcYDCyOkqZZ8hvN34D2Wz8Hpx64fg0XzCXybckSDC8uLi9guh/56U1QjaqsLMV+Y+ZPOc9X+MZeMlhjC01ZtuL5Hbrr6MbwkOEW9Hq6yuV/yNMrkey58NouJah876vOPAD7sIAccNNVOGSuMCWMib34/qUr5hvgJ61onOItZrUIh+YWi7AFVjYHObRQ02JH7QDIki4oxuNkFZZNDQaN6g+4cAWyfhn34U2cQik8gigF6/AgMBAAECggEAXZYofXQO34H5ZPKm0pYoNa/m/zRGyNuDwi1EpGhqX4/gO9B9IrLhyEvx12sLHhd4MOSghWVz+1rBLk4G04y7o611LL+tXo+IC7jTVIGvY2Z2IEfmbA9JqvxZ1395lozKbY8by2jlDfdXGjc+Jh+bWv5ljI6777zHBR4RQj68FmvDhyD1V2uqHqHYoGY3DnfL81YRg6BFpySKHA0Sr21TGwIrduAa3E58I82xxHVv8DqpczEoDYKoledbTCOlWhgB+lVYig9M2B9acNuRvyS727WgC8tpSlFKERifLoxFcjlcr2US7zGzpDw/OoP66BA6b2g2bQIHdRqh33yUxv3T2QKBgQD82vMvs/22G2hw2DCVoP9US28ODe+hOh7CP7ymZHhvG0tohSNsSgisZ+9bmMxzvgTYnf54eupJnwvV4a/tSIBeo9qtwS0HRkox9QNQLaS7TR/tsRFVI8iceWYon8tEZ3U3tt90iuOUfUnnb8CfTwExQzhyFTIn5aMHyF/dtrhV5wKBgQD82hK8QH3M38t1gRoXQoyxTP4Ll+tGv3pucEg560jzPOeWDjKXXNfkADi1vaCbEB0umvVHXIis4h+a29chHh8xaust838xjVQAEzoWzh+E8ud99AMeWyNQ3bNL5g/iYzmEkKZqHZjvcGjpBo9ETsVkF2QaKiKJ+aIP+naV3tdlaQKBgQDlEcY2dS1oCTR45qI9K/mkeCJH7UAmI+0xtWRGqcahgWyzZ8pLlFZ/OjmSFb9DK+ZgB+I9a71MrRWf0jH7GS+SjYbS2qrcaEVXNMynmnIebSR7xWoaY6yedSyjqQARHFkI/Fc70YeTQl3tmUQ8DurZojhEwgcKNfOYXWLcDWi6CQKBgHrVAXb8KWDGcxNhJSiZhrl2+o7tPTmAOVy/JQcl+qlXM/Wcbg1D6Aj15pa7SPMrL9H9KxyAolDCBLJ5C5gmBuc91oPbHzYWPvFOZdDAT2WJjtWMHZu4kH5vRPOhDqReqYlxr7YrLKlcxUo2ipCXZ6LJDjL7tw2p/IWgmc0SlTbJAoGBAOJVk8SOnoxg2I9hRMcJqc3wOQ64vnBxgaez5BqqAR4k7HStmStcPT3LiWlElUYLDh8Cyf3Lgx8Ax+8kGryF6U/4WizjMHPIUmVnQneByiBez8dEsapdFc1PnhgVdLayL3yvrGXlGnuW3H4kroyJzAlO48D8uIuAYRgupHb+3PP8-----END PRIVATE KEY-----";

            string serviceURL = "https://www.googleapis.com/auth/firebase.messaging";

            var serviceAccountCredentialInitializer = new ServiceAccountCredential.Initializer(serviceAccount)
            {
                Scopes = new[] { serviceURL }

            }.FromPrivateKey(privateKey);

            // request access token
            var credential = new ServiceAccountCredential(serviceAccountCredentialInitializer);
            if (!credential.RequestAccessTokenAsync(CancellationToken.None).Result)
                throw new InvalidOperationException("Access token failed.");

            return credential;
        }

    }
}
