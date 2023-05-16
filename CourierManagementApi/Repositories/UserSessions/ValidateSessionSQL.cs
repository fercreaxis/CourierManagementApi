using System;
using System.Linq;
using CourierManagementAPI.Repositories.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace CourierManagementAPI.Repositories.UserSessions
{
    public class ValidateSessionSql : IValidateSessionData
    {
        private CourierManagementContext _aux;

        public ValidateSessionSql(CourierManagementContext ParamContext)
        {
            _aux = ParamContext;
        }

        public int ValidateSession(int UserId, string SessionId, string Token)
        {
            try
            {
                var query = "exec sp_SYS_validateSession @userId=@userId, @sessionId=@sessionId, @token=@token";

                object[] parameters = { new SqlParameter(parameterName: "@userId", value: UserId),
                new SqlParameter(parameterName: "@sessionId", value: SessionId),
                new SqlParameter(parameterName: "@token", value: Token),

                };

                var result = _aux.validateSessionResults.FromSqlRaw(query, parameters).ToList().FirstOrDefault()!.code;
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
