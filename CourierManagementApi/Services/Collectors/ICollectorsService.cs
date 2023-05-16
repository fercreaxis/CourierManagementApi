using CourierManagementAPI.Models.Collector;

namespace CourierManagementAPI.Services.Collectors
{
    public interface ICollectorsService
    {
        public Collector GetById(int Id, int UserId);
        public List<Collector> GetList(int UserId, Boolean Deleted = false);
        public Collector Save(Collector Collector, int UserId);
    }
}