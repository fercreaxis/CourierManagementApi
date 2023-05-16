using CourierManagementAPI.Models.Brand;
using CourierManagementAPI.Repositories.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;


namespace CourierManagementAPI.Repositories.Brands
{
    public class BrandsDataSQL : IBrandsData
    {
        private readonly CourierManagementContext _aux;
        private readonly IConfiguration _config;

        public BrandsDataSQL(CourierManagementContext ParamContext, IConfiguration Param)
        {
            _aux = ParamContext;
            _config = Param;
        }


        public List<Brand> GetList(int UserId, bool Deleted)
        {
            try
            {
                var query = @"execute  sp_Brands_GetList 
                                @userId = @userId,
                                @id = 0,
                                @deleted = @deleted
                    ";
                object[] parameters = {
                    new SqlParameter(parameterName: "@deleted", value: Deleted),
                    new SqlParameter(parameterName: "@userId", value: UserId),
                };

                var s = _aux.brands.FromSqlRaw(query, parameters).ToList();

                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public Brand GetById(int Id, int UserId)
        {
            try
            {
                var query = @"execute  sp_Brands_GetList 
                                @userId = @userId,
                                @id = @id
                    ";
                object[] parameters = {
                    new SqlParameter(parameterName: "@id", value: Id),
                    new SqlParameter(parameterName: "@userId", value: UserId),

                };

                var s = _aux.brands.FromSqlRaw(query, parameters).ToList().FirstOrDefault();

                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Brand Save(Brand Brand, int UserId)
        {
            try
            {
                var query = @"execute  sp_Brands_Save 
                              @id = @id
                            , @brandName = @brandName
                            , @deleted = @deleted
                            , @userId = @userId 
                                
                    ";
                object[] parameters = {
                    new SqlParameter(parameterName: "@id", value: Brand.id),
                    new SqlParameter(parameterName: "@brandName", value: Brand.brandName),
                    new SqlParameter(parameterName: "@deleted", value: Brand.deleted),
                    new SqlParameter(parameterName: "@userId", value: UserId),

                };

                var s = _aux.brands.FromSqlRaw(query, parameters).ToList().FirstOrDefault();

                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}


