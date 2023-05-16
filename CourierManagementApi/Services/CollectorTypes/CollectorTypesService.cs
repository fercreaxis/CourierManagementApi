using CourierManagementAPI.Models.CollectorType;
using CourierManagementAPI.Repositories.CollectorTypes;
using CourierManagementAPI.Repositories.DB;

namespace CourierManagementAPI.Services.CollectorTypes
{
    public class CollectorTypesService : ICollectorTypesService
    {

        private readonly ICollectorTypesDataSQL _aux;

        public CollectorTypesService(ICollectorTypesDataSQL ParamContext)
        {
            _aux = ParamContext;
        }



        public CollectorType GetById(int Id, int UserId)
        {
            return _aux.GetById(Id, UserId);
        }

        public List<CollectorType> GetList(int UserId, bool Deleted = false)
        {
            return _aux.GetList(UserId, Deleted);
        }

        public CollectorType Save(CollectorType CollectorType, int UserId)
        {
            return _aux.Save(CollectorType, UserId);
        }
    }
}