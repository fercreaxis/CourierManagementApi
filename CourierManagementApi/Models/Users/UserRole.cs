using System.ComponentModel.DataAnnotations;

namespace ApproveX_API.Models.Users
{
    public class UserRole
    {
        [Key]
        public int id { get; set; }
        public string description { get; set; }
        public string associatedTable { get; set; }
    }
}
