namespace CourierManagementAPI.Models.Brand
{
    public class Brand
    {
        public int id { get; set; }

        public string brandName { get; set; }

        public bool? deleted { get; set; }

        public DateTime? dateAdded { get; set; }

        public int? userAdded { get; set; }

        public DateTime? dateModified { get; set; }

        public int? userModified { get; set; }

        public DateTime? dateDeleted { get; set; }

        public int? userDeleted { get; set; }

    }
}
