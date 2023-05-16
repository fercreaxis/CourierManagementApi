using CourierManagementAPI.Models.UrgencyType;
using CourierManagementAPI.Repositories.UrgencyTypes;
using CourierManagementAPI.Repositories.DB;

namespace CourierManagementAPI.Services.UrgencyTypes
{
    public class UrgencyTypesService : IUrgencyTypesService
    {

        private readonly IUrgencyTypesData _aux;

        public UrgencyTypesService(IUrgencyTypesData ParamContext)
        {
            _aux = ParamContext;
        }



        public UrgencyType GetById(int Id, int UserId)
        {
            return _aux.GetById(Id, UserId);
        }

        public List<UrgencyType> GetList(int UserId, bool Deleted = false)
        {
            return _aux.GetList(UserId, Deleted);
        }

        public UrgencyType Save(UrgencyType UrgencyType, int UserId)
        {
            return _aux.Save(UrgencyType, UserId);
        }
    }
}