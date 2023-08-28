using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace order_api.Models
{
    public partial class Order
    {
       
        public Order()
        {
        }
        [Key]
        public string OrderId { get; set; } = null!;
        public string ProjectNumber { get; set; } = null!;
        public string? PrintingFor { get; set; }
        public DateTime? DateSubmitted { get; set; }
        public DateTime? DateRequired { get; set; }
        public string? SpecialInstructions { get; set; }
        public string? OrderType { get; set; }
        public string? OrderLink { get; set; }
        public string? SubmittedBy { get; set; }
        public bool? OrderComplete { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public DateTime? VisionExportDate { get; set; }
        public string? NotifyEmployee { get; set; }
        public string? NotifyEmployee2 { get; set; }
        public string? Extras { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        [NotMapped]
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        [NotMapped]
        public OrderSignAndSeal? OrderSignAndSeal { get; set; }
    }

    public enum OrderStatus
    {
        Pending,
        Completed,
        Canceled
    }
}
