using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using CourierManagementAPI.Models.Collector;
using CourierManagementAPI.Models.Geo;
using CourierManagementAPI.Models.Users;
using CourierManagementAPI.Repositories.DB;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;


namespace CourierManagementAPI.Repositories.Geo
{
    public class GeoDataSql : IGeoData
    {
        private readonly CourierManagementContext _aux;
        private readonly IConfiguration _config;

        public GeoDataSql(CourierManagementContext ParamContext, IConfiguration Param)
        {
            _aux = ParamContext;
            _config = Param;
        }


        public GeoCity GeoCityGetById(int Id, int UserId)
        {
            try
            {
                var query = @"execute  sp_geoCities_GetList 
                                @userId = @userId,
                                @id = @id
                    ";
                object[] parameters = {
                    new SqlParameter(parameterName: "@id", value: Id),
                    new SqlParameter(parameterName: "@userId", value: UserId),

                };

                var s = _aux.geoCities.FromSqlRaw(query, parameters).ToList().FirstOrDefault();

                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GeoCity> GeoCitiesGetList(int UserId)
        {
            try
            {
                var query = @"execute  sp_geoCities_GetList 
                                @userId = @userId,
                                @id = 0,
                    ";
                object[] parameters = {
                    new SqlParameter(parameterName: "@userId", value: UserId),
                };

                var s = _aux.geoCities.FromSqlRaw(query, parameters).ToList();

                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GeoState GeoStateGetById(int Id, int UserId)
        {
            try
            {
                var query = @"execute  sp_geoStates_GetList 
                                @userId = @userId,
                                @id = @id
                    ";
                object[] parameters = {
                    new SqlParameter(parameterName: "@id", value: Id),
                    new SqlParameter(parameterName: "@userId", value: UserId),

                };

                var s = _aux.geoStates.FromSqlRaw(query, parameters).ToList().FirstOrDefault();

                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GeoState> GeoStatesGetList(int UserId)
        {
            try
            {
                var query = @"execute  sp_geoStates_GetList 
                                @userId = @userId,
                                @id = 0,
                    ";
                object[] parameters = {
                    new SqlParameter(parameterName: "@userId", value: UserId),
                };

                var s = _aux.geoStates.FromSqlRaw(query, parameters).ToList();

                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GeoCountry GeoCountryGetById(int Id, int UserId)
        {
            try
            {
                var query = @"execute  sp_geoCountries_GetList 
                                @userId = @userId,
                                @id = @id
                    ";
                object[] parameters = {
                    new SqlParameter(parameterName: "@id", value: Id),
                    new SqlParameter(parameterName: "@userId", value: UserId),

                };

                var s = _aux.geoCountries.FromSqlRaw(query, parameters).ToList().FirstOrDefault();

                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GeoCountry> GeoCountriesGetList(int UserId)
        {
            try
            {
                var query = @"execute  sp_geoCountries_GetList 
                                @userId = @userId,
                                @id = 0,
                    ";
                object[] parameters = {
                    new SqlParameter(parameterName: "@userId", value: UserId),
                };

                var s = _aux.geoCountries.FromSqlRaw(query, parameters).ToList();

                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}


