namespace ApproveX_API.Models.Users
{
    public class UserActivity
    {
        public int userId { get; set; }
        public string url { get; set; }
        public string ipAddress { get; set; }
        public string action { get; set; }
        public string parameters { get; set; }
    }
}
