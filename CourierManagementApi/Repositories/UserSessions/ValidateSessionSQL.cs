using System;
using System.Linq;
using ApproveX_API.Repositories.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace ApproveX_API.Repositories.UserSessions
{
    public class ValidateSessionSql : IValidateSessionData
    {
        private ApproveXContext _aux;

        public ValidateSessionSql(ApproveXContext ParamContext)
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

                var result = _aux.ValidateSessionResults.FromSqlRaw(query, parameters).ToList().FirstOrDefault()!.code;
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
