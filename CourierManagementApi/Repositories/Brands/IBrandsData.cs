using System.Collections.Generic;
using CourierManagementAPI.Models.Brand;
using CourierManagementAPI.Models.Users;

namespace CourierManagementAPI.Repositories.Brands
{
    public interface IBrandsData
    {
        public Brand GetById(int Id, int UserId);
        public List<Brand> GetList(int UserId, Boolean Deleted = false);
        public Brand Save(Brand Brand, int UserId);

    }
}