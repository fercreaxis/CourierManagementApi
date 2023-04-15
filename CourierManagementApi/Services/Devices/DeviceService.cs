using ApproveX_API.Models.Devices;
using ApproveX_API.Repositories.DB;
using ApproveX_API.Repositories.Devices;

namespace ApproveX_API.Services.Devices
{
    public class DeviceService : IDeviceService
    {

        private readonly IDeviceData _data;

        public DeviceService(IDeviceData paramContext)
        {
            _data = paramContext;
        }


        public Device GetById(int id, int userId)
        {
            return _data.GetById(id, userId);
        }

        public Device GetByToken(Guid token, int userId)
        {
            return _data.GetByToken(token, userId);
        }

        public List<Device> GetDevices(int userId)
        {
            return _data.GetDevices(userId);
        }

        public Device SaveDevice(Device device, int userId)
        {
            return _data.SaveDevice(device, userId);
        }
    }
}
