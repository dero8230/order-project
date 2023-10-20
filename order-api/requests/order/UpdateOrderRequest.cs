using System.ComponentModel.DataAnnotations;

namespace order_api.requests.order;
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
        public List<UpdateOrderDetailRequest> OrderDetails { get; set; } = null!;
    }

    public class UpdateOrderDetailRequest
    {
        public int DetailsId { get; set; }
        public int Quantity { get; set; } = 1;
        public bool? BindInSet { get; set; }
        public int Pages { get; set; } = 1;
        public bool? Completed { get; set; }
        public string? Notes { get; set; }
        public string? Data { get; set; }
        public string? PricingId { get; set; }
        public bool Deleted { get; set; } = false;
        public bool New { get; set; } = false;
}
