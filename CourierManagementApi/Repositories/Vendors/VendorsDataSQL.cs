using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using CourierManagementAPI.Models.Vendor;
using CourierManagementAPI.Models.Users;
using CourierManagementAPI.Repositories.DB;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;


namespace CourierManagementAPI.Repositories.Vendors
{
    public class VendorDataSql : IVendorsData
    {
        private readonly CourierManagementContext _aux;
        private readonly IConfiguration _config;

        public VendorDataSql(CourierManagementContext ParamContext, IConfiguration Param)
        {
            _aux = ParamContext;
            _config = Param;
        }


        public List<Vendor> GetList(int UserId, bool Deleted)
        {
            try
            {
                var query = @"execute  sp_Vendors_GetList 
                                @userId = @userId,
                                @id = 0,
                                @deleted = @deleted
                    ";
                object[] parameters = {
                    new SqlParameter(parameterName: "@deleted", value: Deleted),
                    new SqlParameter(parameterName: "@userId", value: UserId),
                };

                var s = _aux.vendors.FromSqlRaw(query, parameters).ToList();

                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public Vendor GetById(int Id, int UserId)
        {
            try
            {
                var query = @"execute  sp_Vendors_GetList 
                                @userId = @userId,
                                @id = @id
                    ";
                object[] parameters = {
                    new SqlParameter(parameterName: "@id", value: Id),
                    new SqlParameter(parameterName: "@userId", value: UserId),

                };

                var s = _aux.vendors.FromSqlRaw(query, parameters).ToList().FirstOrDefault();

                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Vendor Save(Vendor Vendor, int UserId)
        {
            try
            {
                var query = @"execute  sp_Vendors_Save 
                              @id = @id
                            , @vendorName = @vendorName
                            , @deleted = @deleted
                                
                    ";
                object[] parameters = {
                    new SqlParameter(parameterName: "@id", value: Vendor.id),
                    new SqlParameter(parameterName: "@vendorName", value: Vendor.vendorName),
                    new SqlParameter(parameterName: "@deleted", value: Vendor.deleted),
                    new SqlParameter(parameterName: "@userId", value: UserId),

                };

                var s = _aux.vendors.FromSqlRaw(query, parameters).ToList().FirstOrDefault();

                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}


