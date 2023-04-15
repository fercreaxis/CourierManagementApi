namespace CourierManagementAPI.Services.UserSessions
{
    public interface IValidateSessionService
    {

        int ValidateSession(int UserId, string SessionId, string Token);

    }
}
