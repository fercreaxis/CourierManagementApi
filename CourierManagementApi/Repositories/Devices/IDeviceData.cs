using ApproveX_API.Models.Devices;
namespace ApproveX_API.Repositories.Devices

{
    public interface IDeviceData
    {
        public Device GetById(int id, int userId);
        public Device GetByToken(Guid token, int userId);
        public List<Device> GetDevices(int userId);
        public Device SaveDevice(Device device, int userId);
        public List<Device> GetDevicesByUser(int userId);

    }
}
