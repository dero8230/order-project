namespace order_api.Models.Settings
{
    public class SmtpLogin
    {
        public string Host { get; set; } = null!;
        public int Port { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; 
        public bool UseSsl { get; set; } = false;
        public string From { get; set; } = string.Empty ;
    }

}
