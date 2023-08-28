using System.ComponentModel.DataAnnotations;

namespace order_api.Models
{
    public class Invoice
    {
        [Key]
        public string Id { get; set; } = null!;
        public string OrderId { get; set; } = null!;
        public DateTime InvoiceDate { get; set; }
        public string ProjectNumber { get; set; } = null!;
        public string SubmittedBy { get; set; } = null!;
        public decimal TotalCost { get; set; }
    }
}
