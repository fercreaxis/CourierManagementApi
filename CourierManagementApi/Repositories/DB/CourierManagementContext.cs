using CourierManagementAPI.Models.Shared;
using CourierManagementAPI.Models.Users;
using CourierManagementAPI.Models.UserSessions;
using Microsoft.EntityFrameworkCore;

namespace CourierManagementAPI.Repositories.DB
{
    public class CourierManagementContext : DbContext
    {
        public CourierManagementContext(DbContextOptions<CourierManagementContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<ValidateSessionResult> ValidateSessionResults { get; set; }
        public DbSet<JsonResult> JsonResults { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RoleEntity> RoleEntities { get; set; }

    }
}
