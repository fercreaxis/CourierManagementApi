using System;
using System.ComponentModel.DataAnnotations;

namespace ApproveX_API.Models.UserSessions
{
    public class UserSession
    {
        [Key]
        public int id { get; set; }
        public int userId { get; set; }
        public string sessionId { get; set; }
        public string token { get; set; }
        public DateTime lastActivityDate { get; set; }

    }
}
