namespace ApproveX_API.Models.Users
{
    public class LoginRequest
    {
        public string userName { get; set; }    
        public string password { get; set; }
        public string sessionId { get; set; }
    }
}
