namespace order_api.requests.mail
{
    public class SendEmailRequest
    {
        public string Email { get; set; } = null!;
        public EmailTemplateType EmailTemplateType { get; set; }
        public string Subject { get; set; } = string.Empty;
        public Dictionary<string, string> BodyParams { get; set; } = null!;
        
    }


    public enum EmailTemplateType
    {
        OrderSubmitted = 0,
        OrderStatusChanged= 1,
        InvioceGenerated = 2
    }
}