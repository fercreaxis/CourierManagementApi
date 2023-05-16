namespace CourierManagementAPI.Models.PackageType
{
    public class PackageType
    {
        public int id { get; set; }

        public string packageType { get; set; }

        public bool? measuresRequired { get; set; }

        public bool? deleted { get; set; }

        public DateTime? dateAdded { get; set; }

        public int? userAdded { get; set; }

        public DateTime? dateModified { get; set; }

        public int? userModified { get; set; }

        public DateTime? dateDeleted { get; set; }

        public int? userDeleted { get; set; }

    }
}
