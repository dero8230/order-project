using Microsoft.AspNetCore.Mvc;
using order_api.Models.Attributes;
using order_api.requests.invoice;
using order_api.Services.Invoices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace order_api.Controllers.Invoice
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpPost]
        [MustBeAdmin]
        public async Task<IActionResult> CreateInvoice(CreateInvoiceRequest createInvoiceRequest)
        {
            return Ok(await _invoiceService.CreateInvoice(createInvoiceRequest));
        }

        [HttpGet]
        [MustBeAdmin]
        public async Task<IActionResult> GetAllInvoices()
        {
            return Ok(await _invoiceService.GetAllInvoices());
        }

        [HttpGet("{id}")]
        [MustBeAdmin]
        public async Task<IActionResult> GetInvoice(string id)
        {
            return Ok(await _invoiceService.GetInvoice(id));
        }
    }
}
