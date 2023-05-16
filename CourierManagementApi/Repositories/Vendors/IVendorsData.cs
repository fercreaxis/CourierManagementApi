using System.Collections.Generic;
using CourierManagementAPI.Models.Vendor;

namespace CourierManagementAPI.Repositories.Vendors
{
    public interface IVendorsData
    {
        public Vendor GetById(int Id, int UserId);
        public List<Vendor> GetList(int UserId, Boolean Deleted = false);
        public Vendor Save(Vendor Vendor, int UserId);

    }
}