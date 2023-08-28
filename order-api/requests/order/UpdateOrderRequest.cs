using System.ComponentModel.DataAnnotations;

namespace order_api.requests.order
{
    public class UpdateOrderRequest
    {
        [Required]
        public string OrderId { get; set; } = null!;
        public string? ProjectNumber { get; set; }
        public string? PrintingFor { get; set; }
        public DateTime? DateRequired { get; set; }
        public string? SpecialInstructions { get; set; }
        public string? OrderType { get; set; }
        public string? OrderLink { get; set; }
        public string? NotifyEmployee { get; set; }
        public string? NotifyEmployee2 { get; set; }
        public string? Extras { get; set; }
    }
}
