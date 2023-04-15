namespace CourierManagementAPI.Models.Shared
{
    public class ExportPdf
    {
        public string filename { get; set; }
        public byte[] file { get; set; }
        public string filetype { get; set; }
    }
}
