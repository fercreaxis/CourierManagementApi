using System.Collections.Generic;
using CourierManagementAPI.Models.Users;

namespace CourierManagementAPI.Repositories.Users
{
    public interface IUsersData
    {
        User UpdateUser(User User, bool EncryptPassword = false);
        User CreateUser(User User);
        User LoginUser(string Username, string Password, string SessionId);
        User GetUser(int UserId);
        User GetUser(string Username);
        List<User> GetUsers();
        List<UserRole> GetUserRoles();
        void LogUserActivity (UserActivity Activity);
        List<RoleEntity> GetRoleEntities();

    }
}
