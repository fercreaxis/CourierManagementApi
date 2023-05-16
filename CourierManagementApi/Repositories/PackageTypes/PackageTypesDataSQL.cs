using CourierManagementAPI.Models.PackageType;
using CourierManagementAPI.Repositories.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;


namespace CourierManagementAPI.Repositories.PackageTypes
{
    public class PackageTypeDataSql : IPackageTypesData
    {
        private readonly CourierManagementContext _aux;
        private readonly IConfiguration _config;

        public PackageTypeDataSql(CourierManagementContext ParamContext, IConfiguration Param)
        {
            _aux = ParamContext;
            _config = Param;
        }


        public List<PackageType> GetList(int UserId, bool Deleted)
        {
            try
            {
                var query = @"execute  sp_PackageTypes_GetList 
                                @userId = @userId,
                                @id = 0,
                                @deleted = @deleted
                    ";
                object[] parameters = {
                    new SqlParameter(parameterName: "@deleted", value: Deleted),
                    new SqlParameter(parameterName: "@userId", value: UserId),
                };

                var s = _aux.packageTypes.FromSqlRaw(query, parameters).ToList();

                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public PackageType GetById(int Id, int UserId)
        {
            try
            {
                var query = @"execute  sp_PackageTypes_GetList 
                                @userId = @userId,
                                @id = @id
                    ";
                object[] parameters = {
                    new SqlParameter(parameterName: "@id", value: Id),
                    new SqlParameter(parameterName: "@userId", value: UserId),

                };

                var s = _aux.packageTypes.FromSqlRaw(query, parameters).ToList().FirstOrDefault();

                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PackageType Save(PackageType PackageType, int UserId)
        {
            try
            {
                var query = @"execute  sp_PackageTypes_Save 
                              @id = @id
                            , @packageType = @packageType
                            , @measuresRequired = @measuresRequired
                            , @deleted = @deleted
                            , @userId = @userId 
                                
                    ";
                object[] parameters = {
                    new SqlParameter(parameterName: "@id", value: PackageType.id),
                    new SqlParameter(parameterName: "@packageType", value: PackageType.packageType),
                    new SqlParameter(parameterName: "@measuresRequired", value: PackageType.measuresRequired),
                    new SqlParameter(parameterName: "@deleted", value: PackageType.deleted),
                    new SqlParameter(parameterName: "@userId", value: UserId),

                };

                var s = _aux.packageTypes.FromSqlRaw(query, parameters).ToList().FirstOrDefault();

                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}


