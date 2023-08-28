using Microsoft.EntityFrameworkCore;
using order_api.Models;
using order_api.Models.Exceptions;
using order_api.Models.Wrapper;
using order_api.requests.invoice;

namespace order_api.Services.Invoices
{
    public class InvoiceService : IInvoiceService
    {
        private readonly PlotroomOrdersContext _db; 

        public InvoiceService(PlotroomOrdersContext db)
        {
            _db = db;
        }

        public async Task<Result<Invoice>> CreateInvoice(CreateInvoiceRequest createInvoiceRequest)
        {
            var invoice = new Invoice
            {
                InvoiceDate = createInvoiceRequest.InvoiceDate,
                ProjectNumber = createInvoiceRequest.ProjectNumber,
                SubmittedBy = createInvoiceRequest.SubmittedBy,
                TotalCost = createInvoiceRequest.TotalCost,
                OrderId = createInvoiceRequest.OrderId,
                Id = Guid.NewGuid().ToString(),
            };

            var order = await _db.Orders.FirstOrDefaultAsync(x => x.OrderId == createInvoiceRequest.OrderId);
            if (order == null) throw new EntityNotFoundException("Order not found");
            order.InvoiceDate = createInvoiceRequest.InvoiceDate;
            _db.Update(order);


            await _db.Invoices.AddAsync(invoice);
            await _db.SaveChangesAsync();

            return new Result<Invoice>(invoice);
        }

        public async Task<Result<List<Invoice>>> GetAllInvoices()
        {
            var invoices = await _db.Invoices
                .OrderByDescending(x => x.InvoiceDate)
                .ToListAsync();

            return new Result<List<Invoice>>(invoices);
        }

        public async Task<Result<Invoice>> GetInvoice(string id)
        {
            var invoice = await _db.Invoices
                .FirstOrDefaultAsync(x => x.Id == id);

            if (invoice == null)
            {
                throw new EntityNotFoundException("Invoice not found");
            }

            return new Result<Invoice>(invoice);
        }
    }

}
