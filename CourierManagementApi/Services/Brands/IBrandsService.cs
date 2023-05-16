using CourierManagementAPI.Models.Brand;

namespace CourierManagementAPI.Services.Brands
{
    public interface IBrandsService
    {
        public Brand GetById(int Id, int UserId);
        public List<Brand> GetList(int UserId, Boolean Deleted = false);
        public Brand Save(Brand Brand, int UserId);
    }
}
