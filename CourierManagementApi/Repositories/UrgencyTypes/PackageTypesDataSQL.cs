using CourierManagementAPI.Models.UrgencyType;
using CourierManagementAPI.Repositories.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;


namespace CourierManagementAPI.Repositories.UrgencyTypes
{
    public class UrgencyTypeDataSql : IUrgencyTypesData
    {
        private readonly CourierManagementContext _aux;
        private readonly IConfiguration _config;

        public UrgencyTypeDataSql(CourierManagementContext ParamContext, IConfiguration Param)
        {
            _aux = ParamContext;
            _config = Param;
        }


        public List<UrgencyType> GetList(int UserId, bool Deleted)
        {
            try
            {
                var query = @"execute  sp_UrgencyTypes_GetList 
                                @userId = @userId,
                                @id = 0,
                                @deleted = @deleted
                    ";
                object[] parameters = {
                    new SqlParameter(parameterName: "@deleted", value: Deleted),
                    new SqlParameter(parameterName: "@userId", value: UserId),
                };

                var s = _aux.urgencyTypes.FromSqlRaw(query, parameters).ToList();

                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public UrgencyType GetById(int Id, int UserId)
        {
            try
            {
                var query = @"execute  sp_UrgencyTypes_GetList 
                                @userId = @userId,
                                @id = @id
                    ";
                object[] parameters = {
                    new SqlParameter(parameterName: "@id", value: Id),
                    new SqlParameter(parameterName: "@userId", value: UserId),

                };

                var s = _aux.urgencyTypes.FromSqlRaw(query, parameters).ToList().FirstOrDefault();

                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UrgencyType Save(UrgencyType UrgencyType, int UserId)
        {
            try
            {
                var query = @"execute  sp_UrgencyTypes_Save 
                              @id = @id
                            , @urgencyType = @urgencyType
                            , @measuresRequired = @measuresRequired
                            , @deleted = @deleted
                            , @userId = @userId 
                                
                    ";
                object[] parameters = {
                    new SqlParameter(parameterName: "@id", value: UrgencyType.id),
                    new SqlParameter(parameterName: "@urgencyType", value: UrgencyType.urgencyType),
                    new SqlParameter(parameterName: "@deleted", value: UrgencyType.deleted),
                    new SqlParameter(parameterName: "@userId", value: UserId),

                };

                var s = _aux.urgencyTypes.FromSqlRaw(query, parameters).ToList().FirstOrDefault();

                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}


