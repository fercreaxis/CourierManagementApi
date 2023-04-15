using System.Collections.Generic;
using ApproveX_API.Models.Users;
using ApproveX_API.Repositories.Users;


namespace ApproveX_API.Services.Users
{

    public class UserService : IUsersService
    {
        private readonly IUsersData _aux;

        public UserService(IUsersData Param)
        {
            _aux = Param;
        }

        public User UpdateUser(User User, bool EncryptPassword = false)
        {   
            return _aux.UpdateUser(User, EncryptPassword);

        }

        public User CreateUser(User User)
        {
            return _aux.CreateUser(User);
        }

        public User LoginUser(string Username, string Password, string SessionId)
        {
            return _aux.LoginUser(Username, Password, SessionId);
        }

        public User GetUser(int UserId)
        {
            return _aux.GetUser(UserId);
        }

        public User GetUser(string Username)
        {
            return _aux.GetUser(Username);  
        }

        public List<User> GetUsers()
        {
            return _aux.GetUsers();
        }

        public List<UserRole> GetUserRoles()
        {
            return _aux.GetUserRoles();
        }

        public void LogUserActivity(UserActivity Activity)
        {
             _aux.LogUserActivity(Activity);
        }

        public List<RoleEntity> GetRoleEntities()
        {
            return _aux.GetRoleEntities();
        }
    }
}
