using System.ComponentModel.DataAnnotations;

namespace ApproveX_API.Models.Devices
{
    public class Device
    {
        [Key]
        public int id { get; set; }
        public string token { get; set; }
        public string deviceName { get; set; }
        public int userId { get; set; }
        public bool active { get; set; }

    }
}
