using System.ComponentModel.DataAnnotations;

namespace ApproveX_API.Models.Notifications
{
    public class Notification
    {
        [Key]
        public Guid id { get; set; }

        public int fromUserId { get; set; }

        public string fromName { get; set; }

        public DateTime date { get; set; }

        public string subject { get; set; }

        public int toUserId { get; set; }

        public int transactionId { get; set; }

        public int statusId { get; set; }

        public string data { get; set; }

        public string resultComments { get; set; }

        public int? resultId { get; set; }

        public DateTime? lastUpdateDate { get; set; }
        
        public string payload { get; set; }

    }
}
