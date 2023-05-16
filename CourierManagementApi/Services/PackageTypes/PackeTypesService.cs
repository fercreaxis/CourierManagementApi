using CourierManagementAPI.Models.PackageType;
using CourierManagementAPI.Repositories.PackageTypes;
using CourierManagementAPI.Repositories.DB;

namespace CourierManagementAPI.Services.PackageTypes
{
    public class PackageTypesService : IPackageTypesService
    {

        private readonly IPackageTypesData _aux;

        public PackageTypesService(IPackageTypesData ParamContext)
        {
            _aux = ParamContext;
        }



        public PackageType GetById(int Id, int UserId)
        {
            return _aux.GetById(Id, UserId);
        }

        public List<PackageType> GetList(int UserId, bool Deleted = false)
        {
            return _aux.GetList(UserId, Deleted);
        }

        public PackageType Save(PackageType PackageType, int UserId)
        {
            return _aux.Save(PackageType, UserId);
        }
    }
}