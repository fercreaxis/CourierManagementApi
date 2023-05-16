using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using CourierManagementAPI.Models.Users;
using CourierManagementAPI.Repositories.DB;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;


namespace CourierManagementAPI.Repositories.Users
{
    public class UsersDataSql : IUsersData
    {
        private readonly CourierManagementContext _aux;
        private readonly IConfiguration _config;

        public UsersDataSql(CourierManagementContext ParamContext, IConfiguration Param)
        {
            _aux = ParamContext;
            _config = Param;
        }
        public User GetUser(string Username)
        {
            try
            {
                var query = "execute sp_SYS_GetUser @username = @username ";
                object[] parameters = { new SqlParameter(parameterName: "@username", value: Username) };


                var result = _aux.users.FromSqlRaw(query, parameters).ToList().FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public User GetUser(int UserId)
        {
            try
            {
                var query = "execute sp_SYS_GetUser @userId = @userId ";
                object[] parameters = { new SqlParameter(parameterName: "@userId", value: UserId) };


                var result = _aux.users.FromSqlRaw(query, parameters).ToList().FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<User> GetUsers()
        {
            try
            {
                var query = "execute sp_SYS_GetUsers ";
                var result = _aux.users.FromSqlRaw(query).ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RoleEntity> GetRoleEntities()
        {
            try
            {
                var query = "execute SP_SYS_RoleEntities_GetList ";
                var result = _aux.roleEntities.FromSqlRaw(query).ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public User LoginUser(string Username, string Password, string SessionId)
        {
            User result = null;

            try
            {
                if (!string.IsNullOrEmpty(Username))
                {
                    var auxUser = GetUser(Username);
                    if (auxUser is { active: true })
                    {
                        var salt = Convert.FromBase64String(auxUser.passwordSalt);
                        // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
                        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                            password: Password,
                            salt: salt,
                            prf: KeyDerivationPrf.HMACSHA256,
                            iterationCount: 100000,
                            numBytesRequested: 256 / 8));
                        if (hashed == auxUser.password) // Password is correct
                        {
                            auxUser.sessionId = SessionId;
                            auxUser.authToken = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                               password: SessionId,
                               salt: salt,
                               prf: KeyDerivationPrf.HMACSHA256,
                               iterationCount: 100000,
                               numBytesRequested: 256 / 8));
                            auxUser.lastLoginDate = DateTime.Now;
                            result = UpdateUser(auxUser);

                            //Create user session
                            string query = "execute sp_SYS_CreateUserSession @userId = @userId, @sessionId = @sessionId, @token =  @token";
                            object[] parameters = { new SqlParameter(parameterName: "@userId", value: auxUser.id),
                                new SqlParameter(parameterName: "@sessionId", value: auxUser.sessionId),
                                new SqlParameter(parameterName: "@token", value: auxUser.authToken),
                            };

                            var s = _aux.Database.ExecuteSqlRaw(query, parameters);
                        }
                        else
                        {
                            //Increase failed login attempt count 
                            auxUser.failedLoginAttemptsCount++;

                            //if FailedAttempts are equal or higher than the limit set in the config file, lock the account
                            int maxFailedAttempts = Convert.ToInt32(this._config.GetSection("SecuritySettings").GetSection("MaxFailedLoginAttempts").Value);
                            if (auxUser.failedLoginAttemptsCount  >= maxFailedAttempts)
                            {
                                auxUser.isLocked = true;
                            }
                            auxUser.lastUpdateDate = DateTime.Now;
                            result = UpdateUser(auxUser);

                            return null;
                        }
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public User UpdateUser(User User, bool EncryptPassword = false)
        {
            if (EncryptPassword)
            {
                byte[] salt = new byte[128 / 8];
                using (var rngCsp = new RNGCryptoServiceProvider())
                {
                    rngCsp.GetNonZeroBytes(salt);
                }

                // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: User.password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8));

                User.passwordSalt = Convert.ToBase64String(salt);
                User.password = hashed;
                User.lastPasswordChangedDate = DateTime.Now;
            }
            User.lastUpdateDate = DateTime.Now;

            try
            {
                //Update User
                string query = @"execute sp_SYS_UpdateUser 			
                                @userId	= @userId,
                                @password = @password,
			                    @passwordSalt = @passwordSalt,
			                    @firstName = @firstName,
			                    @lastName = @lastName,
			                    @roleId = @roleId,
			                    @roleEntityId = @roleEntityId,
			                    @lastLogin = @lastLogin,
                                @lastPasswordChangedDate = @lastPasswordChangedDate,
			                    @isLocked = @isLocked,
			                    @failedLoginAttemptsCount = @failedLoginAttemptsCount,
			                    @active = @active";

                List<object> parameters = new List<object> { 
                    new SqlParameter(parameterName: "@userId", value: User.id),
                    new SqlParameter(parameterName: "@firstName", value: User.firstName),
                    new SqlParameter(parameterName: "@lastName", value: User.lastName),
                    new SqlParameter(parameterName: "@roleId", value: User.roleId),
                    new SqlParameter(parameterName: "@roleEntityId", value: User.roleEntityId),
                    new SqlParameter(parameterName: "@lastLogin", value: User.lastLoginDate),
                    new SqlParameter(parameterName: "@isLocked", value: User.isLocked),
                    new SqlParameter(parameterName: "@failedLoginAttemptsCount", value: User.failedLoginAttemptsCount),
                    new SqlParameter(parameterName: "@active", value: User.active),
                };
                if (EncryptPassword)
                {
                    parameters.Add(new SqlParameter(parameterName: "@lastPasswordChangedDate", value: User.lastPasswordChangedDate));
                    parameters.Add(new SqlParameter(parameterName: "@password", value: User.password));
                    parameters.Add(new SqlParameter(parameterName: "@passwordSalt", value: User.passwordSalt));
                }
                else
                {
                    parameters.Add(new SqlParameter(parameterName: "@lastPasswordChangedDate", value: DBNull.Value));
                    parameters.Add(new SqlParameter(parameterName: "@password", value: DBNull.Value));
                    parameters.Add(new SqlParameter(parameterName: "@passwordSalt", value: DBNull.Value));

                }
                var s = _aux.Database.ExecuteSqlRaw(query, parameters);

                return GetUser(User.id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public User CreateUser(User User)
        {
            try
            {
                byte[] salt = new byte[128 / 8];
                using (var rngCsp = new RNGCryptoServiceProvider())
                {
                    rngCsp.GetNonZeroBytes(salt);
                }

                // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: User.password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8));

                User.passwordSalt = Convert.ToBase64String(salt);
                User.password = hashed;

                //Update User
                string query = @"execute sp_SYS_CreateUser 			
                                @username	= @username,
                                @password = @password,
			                    @passwordSalt = @passwordSalt,
			                    @firstName = @firstName,
			                    @lastName = @lastName,
			                    @roleId = @roleId,
                                @roleEntityId = @roleEntityId";

                object[] parameters = {
                    new SqlParameter(parameterName: "@username", value: User.username),
                    new SqlParameter(parameterName: "@password", value: User.password),
                    new SqlParameter(parameterName: "@passwordSalt", value: User.passwordSalt),
                    new SqlParameter(parameterName: "@firstName", value: User.firstName),
                    new SqlParameter(parameterName: "@lastName", value: User.lastName),
                    new SqlParameter(parameterName: "@roleId", value: User.roleId),
                    new SqlParameter(parameterName: "@roleEntityId", value: User.roleEntityId)
                };
                var s = _aux.Database.ExecuteSqlRaw(query, parameters);

                return GetUser(User.username);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<UserRole> GetUserRoles()
        {
            try
            {
                var query = "execute  sp_SYS_GetUserRoles";
                var result = _aux.userRoles.FromSqlRaw(query).ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LogUserActivity(UserActivity Activity)
        {
            try
            {
                var query = @"execute  sp_SYS_LogUserActivity 
                                @userId = @userId,
                                @url = @url,
                                @ipAddress = @ipAddress,
                                @action = @action,
                                @parameters = @parameters";
                object[] parameters = {
                    new SqlParameter(parameterName: "@userId", value: Activity.userId),
                    new SqlParameter(parameterName: "@url", value: Activity.url),
                    new SqlParameter(parameterName: "@ipAddress", value: Activity.ipAddress),
                    new SqlParameter(parameterName: "@action", value: Activity.action),
                    new SqlParameter(parameterName: "@parameters", value: Activity.parameters),

                };
                var s = _aux.Database.ExecuteSqlRaw(query, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}


