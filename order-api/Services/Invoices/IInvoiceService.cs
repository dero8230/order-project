using order_api.Models;
using order_api.Models.Wrapper;
using order_api.requests.invoice;

namespace order_api.Services.Invoices
{
    public interface IInvoiceService : IServerService
    {
        Task<Result<Invoice>> CreateInvoice(CreateInvoiceRequest createInvoiceRequest);
        Task<Result<List<Invoice>>> GetAllInvoices();
        Task<Result<Invoice>> GetInvoice(string id);
    }
}
