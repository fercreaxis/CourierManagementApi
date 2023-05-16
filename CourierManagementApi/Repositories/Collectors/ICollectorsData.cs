using System.Collections.Generic;
using CourierManagementAPI.Models.Collector;
using CourierManagementAPI.Models.Users;

namespace CourierManagementAPI.Repositories.Collectors
{
    public interface ICollectorsData
    {
        public Collector GetById(int Id, int UserId);
        public List<Collector> GetList(int UserId, Boolean Deleted = false);
        public Collector Save(Collector Collector, int UserId);

    }
}
