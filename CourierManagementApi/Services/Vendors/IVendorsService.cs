using CourierManagementAPI.Models.Vendor;

namespace CourierManagementAPI.Services.Vendors
{
    public interface IVendorsService
    {
        public Vendor GetById(int Id, int UserId);
        public List<Vendor> GetList(int UserId, Boolean Deleted = false);
        public Vendor Save(Vendor Vendor, int UserId);
    }
}