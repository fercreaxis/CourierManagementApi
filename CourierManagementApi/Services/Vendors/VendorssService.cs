using CourierManagementAPI.Models.Vendor;
using CourierManagementAPI.Repositories.Vendors;
using CourierManagementAPI.Repositories.DB;

namespace CourierManagementAPI.Services.Vendors
{
    public class VendorsService : IVendorsService
    {

        private readonly IVendorsData _aux;

        public VendorsService(IVendorsData ParamContext)
        {
            _aux = ParamContext;
        }

        public Vendor GetById(int Id, int UserId)
        {
            return _aux.GetById(Id, UserId);
        }

        public List<Vendor> GetList(int UserId, bool Deleted = false)
        {
            return _aux.GetList(UserId, Deleted);
        }

        public Vendor Save(Vendor Vendor, int UserId)
        {
            return _aux.Save(Vendor, UserId);
        }
    }
}