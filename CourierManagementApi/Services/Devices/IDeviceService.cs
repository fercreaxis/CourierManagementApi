using ApproveX_API.Models.Devices;

namespace ApproveX_API.Services.Devices
{
    public interface IDeviceService
    {
        public Device GetById(int id, int userId);
        public Device GetByToken(Guid token, int userId);
        public List<Device> GetDevices(int userId);
        public Device SaveDevice(Device device, int userId);

    }
}
