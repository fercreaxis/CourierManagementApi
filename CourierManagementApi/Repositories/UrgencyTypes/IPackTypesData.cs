using System.Collections.Generic;
using CourierManagementAPI.Models.UrgencyType;
using CourierManagementAPI.Models.Users;

namespace CourierManagementAPI.Repositories.UrgencyTypes
{
    public interface IUrgencyTypesData
    {
        public UrgencyType GetById(int Id, int UserId);
        public List<UrgencyType> GetList(int UserId, Boolean Deleted = false);
        public UrgencyType Save(UrgencyType UrgencyType, int UserId);

    }
}