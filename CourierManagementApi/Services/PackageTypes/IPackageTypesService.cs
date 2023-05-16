using CourierManagementAPI.Models.PackageType;

namespace CourierManagementAPI.Services.PackageTypes
{
    public interface IPackageTypesService
    {
        public PackageType GetById(int Id, int UserId);
        public List<PackageType> GetList(int UserId, Boolean Deleted = false);
        public PackageType Save(PackageType PackageType, int UserId);
    }
}