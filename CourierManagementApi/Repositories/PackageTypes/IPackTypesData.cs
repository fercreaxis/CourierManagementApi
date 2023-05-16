using System.Collections.Generic;
using CourierManagementAPI.Models.PackageType;
using CourierManagementAPI.Models.Users;

namespace CourierManagementAPI.Repositories.PackageTypes
{
    public interface IPackageTypesData
    {
        public PackageType GetById(int Id, int UserId);
        public List<PackageType> GetList(int UserId, Boolean Deleted = false);
        public PackageType Save(PackageType PackageType, int UserId);

    }
}