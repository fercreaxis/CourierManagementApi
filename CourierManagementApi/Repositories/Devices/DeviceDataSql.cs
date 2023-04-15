using ApproveX_API.Controllers.ActionFilters;
using ApproveX_API.Models.Devices;
using ApproveX_API.Repositories.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace ApproveX_API.Repositories.Devices
{
    public class DeviceDataSql : IDeviceData   
    {
        private readonly ApproveXContext _aux;
        private readonly IConfiguration _config;

        public DeviceDataSql(ApproveXContext ParamContext, IConfiguration Param)
        {
            _aux = ParamContext;
            _config = Param;
        }

        public Device GetById(int id, int userId)
        {
            try
            {
                var query = "execute sp_devices_GetList @id = @id ";
                object[] parameters = { 
                    new SqlParameter(parameterName: "@id", value: id),
                };


                var result = _aux.Devices.FromSqlRaw(query, parameters).ToList().FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Device GetByToken(Guid token, int userId)
        {
            try
            {
                var query = "execute sp_devices_GetList @token = @token ";
                object[] parameters = {
                    new SqlParameter(parameterName: "@token", value: token),
                };
                var result = _aux.Devices.FromSqlRaw(query, parameters).ToList().FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Device> GetDevices(int userId)
        {
            try
            {
                var query = "execute sp_devices_GetList ";
                var result = _aux.Devices.FromSqlRaw(query).ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Device> GetDevicesByUser(int userId)
        {
            try
            {
                var query = "execute sp_devices_GetList @userId = @userId";
                object[] parameters = {
                    new SqlParameter(parameterName: "@userId", value: userId),

                };
                var result = _aux.Devices.FromSqlRaw(query, parameters).ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Device SaveDevice(Device device, int userId)
        {
            try
            {
                var query = "execute sp_devices_Save @userId = @userId,  @token = @token, @deviceName = @deviceName, @id = @id, @active = @active ";
                object[] parameters = {
                    new SqlParameter(parameterName: "@userId", value: userId),
                    new SqlParameter(parameterName: "@token", value: device.token),
                    new SqlParameter(parameterName: "@deviceName", value: device.deviceName),
                    new SqlParameter(parameterName: "@id", value: device.id),
                    new SqlParameter(parameterName: "@active", value: device.active)
                };
                var result = _aux.Devices.FromSqlRaw(query, parameters).ToList().FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
