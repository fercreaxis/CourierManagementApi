namespace CourierManagementAPI.Models.UrgencyType
{
    public class UrgencyType
    {
        public int id { get; set; }

        public string urgencyType { get; set; }

        public bool? deleted { get; set; }

        public DateTime? dateAdded { get; set; }

        public int? userAdded { get; set; }

        public DateTime? dateModified { get; set; }

        public int? userModified { get; set; }

        public DateTime? dateDeleted { get; set; }

        public int? userDeleted { get; set; }

    }
}
