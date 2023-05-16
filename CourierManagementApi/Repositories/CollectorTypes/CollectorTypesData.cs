using CourierManagementAPI.Models.Collector;
using CourierManagementAPI.Models.CollectorType;
using CourierManagementAPI.Repositories.DB;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CourierManagementAPI.Repositories.CollectorTypes
{
    public class CollectorTypesData : ICollectorTypesDataSQL
    {
        private readonly CourierManagementContext _aux;
        private readonly IConfiguration _config;

        public CollectorTypesData(CourierManagementContext ParamContext, IConfiguration Param)
        {
            _aux = ParamContext;
            _config = Param;
        }

        public CollectorType GetById(int Id, int UserId)
        {
            try
            {
                var query = @"execute  sp_Collectors_GetList 
                                @userId = @userId,
                                @id = @id
                    ";
                object[] parameters = {
                    new SqlParameter(parameterName: "@id", value: Id),
                    new SqlParameter(parameterName: "@userId", value: UserId),

                };

                var s = _aux.collectorTypes.FromSqlRaw(query, parameters).ToList().FirstOrDefault();

                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<CollectorType> GetList(int UserId, bool Deleted = false)
        {
            try
            {
                var query = @"execute  sp_Collectors_GetList 
                                @userId = @userId,
                                @id = 0,
                                @deleted = @deleted
                    ";
                object[] parameters = {
                    new SqlParameter(parameterName: "@deleted", value: Deleted),
                    new SqlParameter(parameterName: "@userId", value: UserId),
                };

                var s = _aux.collectorTypes.FromSqlRaw(query, parameters).ToList();

                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CollectorType Save(CollectorType CollectorType, int UserId)
        {
            try
            {
                var query = @"execute  sp_Collectors_Save 
                              @id = @id
                            , @collectorType = @collectorType
                            , @deleted = @deleted
                            , @userId  = @userId
                    ";

                object[] parameters = {
                    new SqlParameter(parameterName: "@id", value: CollectorType.id),
                    new SqlParameter(parameterName: "@collectorType", value: CollectorType.collectorType),
                    new SqlParameter(parameterName: "@deleted", value: CollectorType.deleted),
                    new SqlParameter(parameterName: "@userId", value: UserId),

                };


                var s = _aux.collectorTypes.FromSqlRaw(query, parameters).ToList().FirstOrDefault();

                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
