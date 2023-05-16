using CourierManagementAPI.Models.Brand;
using CourierManagementAPI.Repositories.Brands;
using CourierManagementAPI.Repositories.DB;

namespace CourierManagementAPI.Services.Brands
{
    public class BrandsService : IBrandsService
    {

        private readonly IBrandsData _aux;

        public BrandsService(IBrandsData ParamContext)
        {
            _aux = ParamContext;
        }

        public Brand GetById(int Id, int UserId)
        {
            return _aux.GetById(Id, UserId);
        }

        public List<Brand> GetList(int UserId, bool Deleted = false)
        {
            return _aux.GetList(UserId, Deleted);
        }

        public Brand Save(Brand Brand, int UserId)
        {
            return _aux.Save(Brand, UserId);
        }
    }
}
