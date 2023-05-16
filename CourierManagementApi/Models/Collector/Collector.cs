namespace CourierManagementAPI.Models.Collector
{
    public class Collector
    {
        public int id { get; set; }

        public string collectorName { get; set; }

        public bool? deleted { get; set; }

        public string collectorCode { get; set; }

        public string ciudad { get; set; }

        public string municipio { get; set; }

        public string departamento { get; set; }

        public string address { get; set; }

        public string locationReference { get; set; }

        public int? cityId { get; set; }

        public int? stateId { get; set; }

        public string phone1 { get; set; }

        public string phone2 { get; set; }

        public string email { get; set; }

        public int? brandId { get; set; }

        public DateTime? dateAdded { get; set; }

        public int? userAdded { get; set; }

        public DateTime? dateModified { get; set; }

        public int? userModified { get; set; }

        public DateTime? dateDeleted { get; set; }

        public int? userDeleted { get; set; }

    }
}
