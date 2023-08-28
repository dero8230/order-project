namespace order_api.requests.invoice
{
    public class CreateInvoiceRequest
    {
        public DateTime InvoiceDate { get; set; }
        public string ProjectNumber { get; set; } = null!; 
        public string OrderId{ get; set; } = null!;
        public string SubmittedBy { get; set; } = null!;
        public decimal TotalCost { get; set; }
    }
}
