using CourierManagementAPI.Models.UrgencyType;

namespace CourierManagementAPI.Services.UrgencyTypes
{
    public interface IUrgencyTypesService
    {
        public UrgencyType GetById(int Id, int UserId);
        public List<UrgencyType> GetList(int UserId, Boolean Deleted = false);
        public UrgencyType Save(UrgencyType UrgencyType, int UserId);
    }
}