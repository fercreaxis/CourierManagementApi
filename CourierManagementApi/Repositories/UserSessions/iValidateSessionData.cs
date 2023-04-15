namespace CourierManagementAPI.Repositories.UserSessions
{
    public interface IValidateSessionData
    {

        int ValidateSession(int UserId, string SessionId, string Token);

    }
}
