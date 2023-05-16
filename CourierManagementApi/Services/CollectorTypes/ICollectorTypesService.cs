using CourierManagementAPI.Models.CollectorType;

namespace CourierManagementAPI.Services.CollectorTypes
{
    public interface ICollectorTypesService
    {
        public CollectorType GetById(int Id, int UserId);
        public List<CollectorType> GetList(int UserId, Boolean Deleted = false);
        public CollectorType Save(CollectorType CollectorType, int UserId);
    }
}