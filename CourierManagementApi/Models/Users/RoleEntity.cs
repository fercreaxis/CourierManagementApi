using System.ComponentModel.DataAnnotations;

namespace CourierManagementAPI.Models.Users
{
    public class RoleEntity
    {
        [Key]
        public int id { get; set; }    
        public string name { get; set; }   
        public int roleId { get; set; }    

    }
}
