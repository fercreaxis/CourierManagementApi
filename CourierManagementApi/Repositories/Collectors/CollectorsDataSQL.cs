using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using CourierManagementAPI.Models.Collector;
using CourierManagementAPI.Models.Users;
using CourierManagementAPI.Repositories.DB;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;


namespace CourierManagementAPI.Repositories.Collectors
{
    public class CollectorDataSql : ICollectorsData
    {
        private readonly CourierManagementContext _aux;
        private readonly IConfiguration _config;

        public CollectorDataSql(CourierManagementContext ParamContext, IConfiguration Param)
        {
            _aux = ParamContext;
            _config = Param;
        }


        public List<Collector> GetList(int UserId, bool Deleted)
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

                var s = _aux.collectors.FromSqlRaw(query, parameters).ToList();

                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public Collector GetById(int Id, int UserId)
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

                var s = _aux.collectors.FromSqlRaw(query, parameters).ToList().FirstOrDefault();

                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Collector Save(Collector Collector, int UserId)
        {
            try
            {
                var query = @"execute  sp_Collectors_Save 
                              @id = @id
                            , @collectorName = @collectorName
                            , @deleted = @deleted
                            , @collectorCode = @collectorCode
                            , @ciudad = @ciudad
                            , @municipio = @municipio
                            , @departamento = @departamento
                            , @address = @address
                            , @locationReference = @locationReference
                            , @cityId = @cityId
                            , @stateId = @stateId
                            , @phone1 = @phone1
                            , @phone2 = @phone2
                            , @email = @email
                            , @brandId = @brandId
                            , @userId = @userId 
                                
                    ";
                object[] parameters = {
                    new SqlParameter(parameterName: "@id", value: Collector.id),
                    new SqlParameter(parameterName: "@collectorName", value: Collector.collectorName),
                    new SqlParameter(parameterName: "@deleted", value: Collector.deleted),
                    new SqlParameter(parameterName: "@collectorCode", value: Collector.collectorCode),
                    new SqlParameter(parameterName: "@ciudad", value: Collector.ciudad),
                    new SqlParameter(parameterName: "@municipio", value: Collector.municipio),
                    new SqlParameter(parameterName: "@departamento", value: Collector.departamento),
                    new SqlParameter(parameterName: "@address", value: Collector.address),
                    new SqlParameter(parameterName: "@locationReference", value: Collector.locationReference),
                    new SqlParameter(parameterName: "@cityId", value: Collector.cityId),
                    new SqlParameter(parameterName: "@stateId", value: Collector.stateId),
                    new SqlParameter(parameterName: "@phone1", value: Collector.phone1),
                    new SqlParameter(parameterName: "@phone2", value: Collector.phone2),
                    new SqlParameter(parameterName: "@email", value: Collector.email),
                    new SqlParameter(parameterName: "@brandId", value: Collector.brandId),
                    new SqlParameter(parameterName: "@userId", value: UserId),

                };

                var s = _aux.collectors.FromSqlRaw(query, parameters).ToList().FirstOrDefault();

                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}


