using CourierManagementAPI.Repositories.UserSessions;

namespace CourierManagementAPI.Services.UserSessions
{
    public class ValidateSessionService : IValidateSessionService
    {

        private readonly IValidateSessionData _aux;

        public ValidateSessionService(IValidateSessionData Param)
        {
            _aux = Param;
        }


        public int ValidateSession(int UserId, string SessionId, string Token)
        {

            return _aux.ValidateSession(UserId, SessionId, Token);
        }

    }
}
