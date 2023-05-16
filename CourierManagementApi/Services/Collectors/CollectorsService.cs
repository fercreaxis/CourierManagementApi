using CourierManagementAPI.Models.Collector;
using CourierManagementAPI.Repositories.Collectors;
using CourierManagementAPI.Repositories.DB;

namespace CourierManagementAPI.Services.Collectors
{
    public class CollectorsService : ICollectorsService
    {

        private readonly ICollectorsData _aux;

        public CollectorsService(ICollectorsData ParamContext)
        {
            _aux = ParamContext;
        }



        public Collector GetById(int Id, int UserId)
        {
            return _aux.GetById(Id, UserId);
        }

        public List<Collector> GetList(int UserId, bool Deleted = false)
        {
            return _aux.GetList(UserId, Deleted);
        }

        public Collector Save(Collector Collector, int UserId)
        {
            return _aux.Save(Collector, UserId);
        }
    }
}