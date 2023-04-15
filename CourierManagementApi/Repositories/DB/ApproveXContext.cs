using ApproveX_API.Models.Devices;
using ApproveX_API.Models.Notifications;
using ApproveX_API.Models.Users;
using ApproveX_API.Models.UserSessions;
using ApproveX_API.Models.Shared;
using Microsoft.EntityFrameworkCore;

namespace ApproveX_API.Repositories.DB
{
    public class ApproveXContext : DbContext
    {
        public ApproveXContext(DbContextOptions<ApproveXContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<ValidateSessionResult> ValidateSessionResults { get; set; }
        public DbSet<JsonResult> JsonResults { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RoleEntity> RoleEntities { get; set; }
        public DbSet<Device> Devices { get; set; }

        public DbSet<Notification> Notifications { get; set; }



    }
}
