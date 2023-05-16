using CourierManagementAPI.Models.Shared;
using CourierManagementAPI.Models.Users;
using CourierManagementAPI.Models.UserSessions;
using CourierManagementAPI.Models.Brand;
using Microsoft.EntityFrameworkCore;
using CourierManagementAPI.Models.Collector;
using CourierManagementAPI.Models.CollectorType;
using CourierManagementAPI.Models.Geo;
using CourierManagementAPI.Models.PackageType;
using CourierManagementAPI.Models.UrgencyType;
using CourierManagementAPI.Models.Vendor;


namespace CourierManagementAPI.Repositories.DB
{
    public class CourierManagementContext : DbContext
    {
        public CourierManagementContext(DbContextOptions<CourierManagementContext> options) : base(options)
        {

        }

        public DbSet<User> users { get; set; }
        public DbSet<ValidateSessionResult> validateSessionResults { get; set; }
        public DbSet<JsonResult> jsonResults { get; set; }
        public DbSet<UserRole> userRoles { get; set; }
        public DbSet<RoleEntity> roleEntities { get; set; }
        public DbSet<Brand> brands { get; set; }
        public DbSet<Collector> collectors { get; set; }
        public DbSet<CollectorType> collectorTypes { get; set; }
        public DbSet<PackageType> packageTypes { get; set; }
        public DbSet<UrgencyType> urgencyTypes { get; set; }
        public DbSet<Vendor> vendors { get; set; }
        public DbSet<GeoCity> geoCities { get; set; }
        public DbSet<GeoState> geoStates { get; set; }
        public DbSet<GeoCountry> geoCountries { get; set; }












    }
}
