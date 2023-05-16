using CourierManagementAPI.Models.CollectorType;

namespace CourierManagementAPI.Repositories.CollectorTypes
{
    public interface ICollectorTypesDataSQL
    {
        public CollectorType GetById(int Id, int UserId);
        public List<CollectorType> GetList(int UserId, Boolean Deleted = false);
        public CollectorType Save(CollectorType Collector, int UserId);

    }
}
