using Microsoft.EntityFrameworkCore;
using order_api.Models;
using order_api.Models.PR;
using order_api.Models.Wrapper;
using System.Text.Json;

namespace order_api.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly PlotroomOrdersContext _db;
        private readonly VisionContext _db2;
        private readonly IHttpContextAccessor _context;

        public OrderService(PlotroomOrdersContext db, VisionContext db2, IHttpContextAccessor context)
        {
            _db = db;
            _db2 = db2;
            _context = context;
        }
        public async Task<Result<Order>> AddOrder(CreateOrderRequest createOrderRequest)
        {
            List<OrderDetail> orderDetails = new();
            string orderID = DateTime.Now.ToString("ddMMyyHHmmssfff");
            foreach (var OrderDetail in createOrderRequest.OrderDetails)
            {
                orderDetails.Add(new OrderDetail
                {
                    
                    Name = OrderDetail.Name,
                    Quantity = OrderDetail.Quantity.ToString(),
                    Description = OrderDetail.Description,
                    Pages = OrderDetail.Pages,
                    BindInSet = OrderDetail.BindInSet,
                    Notes = OrderDetail.Notes,
                    FileStaged = OrderDetail.FileStaged,
                    FileArchived = OrderDetail.FileArchived,
                    FileQc = OrderDetail.FileQc,
                    OrderId = orderID
                
                }
                  );
            }
            // create a new instance of the OrderSignAndSeal entity
            var orderSignAndSeal = createOrderRequest.OrderSignAndSeal == null ? null : new OrderSignAndSeal
            {
                OrderId = orderID,
                Electronic = createOrderRequest.OrderSignAndSeal.Electronic,
                ArchSignee = createOrderRequest.OrderSignAndSeal.ArchSignee,
                ArchCompletedDate = createOrderRequest.OrderSignAndSeal.ArchCompletedDate,
                MechSignee = createOrderRequest.OrderSignAndSeal.MechSignee,
                MechCompletedDate = createOrderRequest.OrderSignAndSeal.MechCompletedDate,
                ElectSignee = createOrderRequest.OrderSignAndSeal.ElectSignee,
                ElectCompletedDate = createOrderRequest.OrderSignAndSeal.ElectCompletedDate,
                PlumbSignee = createOrderRequest.OrderSignAndSeal.PlumbSignee,
                PlumbCompletedDate = createOrderRequest.OrderSignAndSeal.PlumbCompletedDate,
                CivilSignee = createOrderRequest.OrderSignAndSeal.CivilSignee,
                CivilCompletedDate = createOrderRequest.OrderSignAndSeal.CivilCompletedDate,
                StructSignee = createOrderRequest.OrderSignAndSeal.StructSignee,
                StructCompletedDate = createOrderRequest.OrderSignAndSeal.StructCompletedDate,
                LeadPermit = createOrderRequest.OrderSignAndSeal.LeadPermit,
                LeadPermitCompletedDate = createOrderRequest.OrderSignAndSeal.LeadPermitCompletedDate,
                Completed = createOrderRequest.OrderSignAndSeal.Completed,
                DateCompleted = createOrderRequest.OrderSignAndSeal.DateCompleted,
                State = createOrderRequest.OrderSignAndSeal.State,
                Notes = createOrderRequest.OrderSignAndSeal.Notes,
                ArchSigner = createOrderRequest.OrderSignAndSeal.ArchSigner,
                MechSigner = createOrderRequest.OrderSignAndSeal.MechSigner,
                ElectSigner = createOrderRequest.OrderSignAndSeal.ElectSigner,
                PlumbSigner = createOrderRequest.OrderSignAndSeal.PlumbSigner,
                CivilSigner = createOrderRequest.OrderSignAndSeal.CivilSigner,
                StructSigner = createOrderRequest.OrderSignAndSeal.StructSigner,
            };
            var order = new Order
            {
                OrderId = orderID,
                ProjectNumber = createOrderRequest.ProjectNumber,
                PrintingFor = createOrderRequest.PrintingFor,
                DateRequired = createOrderRequest.DateRequired,
                SpecialInstructions = createOrderRequest.SpecialInstructions,
                OrderType = createOrderRequest.OrderType,
                OrderLink = createOrderRequest.OrderLink,
                NotifyEmployee = createOrderRequest.NotifyEmployee,
                NotifyEmployee2 = createOrderRequest.NotifyEmployee2,
                OrderDetails = orderDetails,
                OrderSignAndSeal = orderSignAndSeal,
                DateSubmitted = DateTime.Now,
                SubmittedBy = _context.HttpContext?.User.Identity?.Name,
                Extras = createOrderRequest.Extras == null? null : JsonSerializer.Serialize(createOrderRequest.Extras),
            };
            await _db.AddAsync(order);
            await _db.AddRangeAsync(orderDetails);
            if (orderSignAndSeal != null) await _db.AddAsync(orderSignAndSeal);
            await _db.SaveChangesAsync();
            return new Result<Order>(order);
        }

        public async Task<Result<List<Order>>> GetAllOrders()
        {
            var orders = await _db.Orders.AsQueryable().Where(x => true).ToListAsync();
            List<Order> ordersList = new();
            foreach (var order in orders)
            {
                order.OrderDetails = await _db.OrderDetails.AsQueryable().Where(e=> e.OrderId == order.OrderId).ToListAsync();
                order.OrderSignAndSeal = await _db.OrderSignAndSeals.AsQueryable().Where(e => e.OrderId == order.OrderId).FirstOrDefaultAsync();
                ordersList.Add(order);
            }
            return new Result<List<Order>>(ordersList);
        }

        public async Task<Result<Order>> GetOrder(string id)
        {
            var order = await _db.Orders.FirstAsync(x => x.OrderId == id);
            order.OrderDetails = await _db.OrderDetails.AsQueryable().Where(e => e.OrderId == order.OrderId).ToListAsync();
            order.OrderSignAndSeal = await _db.OrderSignAndSeals.AsQueryable().Where(e => e.OrderId == order.OrderId).FirstOrDefaultAsync();
            return new Result<Order>(order);
        }

        public async Task<Result<bool>> DeleteOrder(string id)
        {
            var order =  await _db.Orders.FirstAsync(x => x.OrderId == id);
            List<OrderDetail> orderDetails = await _db.OrderDetails.AsQueryable().Where(e => e.OrderId == order.OrderId).ToListAsync();
            var orderSignAndSeal = await _db.OrderSignAndSeals.AsQueryable().Where(e => e.OrderId == order.OrderId).FirstOrDefaultAsync();
            _db.Orders.Remove(order);
            _db.OrderDetails.RemoveRange(orderDetails);
            if(orderSignAndSeal != null) _db.OrderSignAndSeals.Remove(orderSignAndSeal);
            await _db.SaveChangesAsync();
            return new Result<bool>(true);
        }

        public async Task<Result<List<ActiveJob>>> GetProjectNumbers()
        {
            var query = @"
        SELECT WBS1 as ActiveJobNumbers, Name
        FROM PR 
        WHERE (((WBS1 = '000050.0000.00') OR (WBS1 = '000010.0000.00')) 
            OR (((WBS1 not like '%.9999%') AND (WBS1 <> '000095.0000.00')) 
            AND (Status = 'A') AND (ChargeType = 'R'))) 
            AND (WBS2 = '') AND (WBS3 = '')
        ORDER BY WBS1";

            var results = await _db2.ActiveJobs.FromSqlRaw(query).ToListAsync();

         return new Result<List<ActiveJob>>(results);
        }

        public async Task<Result<List<PaperSize>>> GetPaperSizes()
        {
            var result = await _db.OrderItemPricings
                .Where(oip => oip.Size != "")
                .GroupBy(oip => oip.Size)
                .Select(g => new PaperSize
                {
                    PaperSizes = g.Key,
                    Cost = g.Min(oip => oip.Cost)??"0"
                })
                .OrderBy(g => g.Cost)
                .ThenByDescending(g => g.PaperSizes)
                .ToListAsync();
            return new Result<List<PaperSize>>(result);
        }

        public async Task<Result<object>> GetOrderSignees()
        {
            var result = await _db.OrderSignees
                .Select(os => new
                {
                    os.DisplayName,
                    os.Discipline,
                    os.Email
                })
                .ToListAsync();
            return new Result<object>(result);
        }

        public async Task<Result<object>> GetEmployees()
        {
            var result = await _db2.Ems
                .Where(em => em.Status == "A")
                .OrderBy(em => em.FirstName)
                .Select(em => new
                {
                    FullName = em.FirstName + " " + em.LastName,
                    Employee = em.Employee,
                    Discipline = _db2.CfgorgCodes
                        .Where(coc => coc.OrgLevel == 3 && coc.Code == em.Org.Substring(6, 2))
                        .Select(coc => coc.Label)
                        .FirstOrDefault(),
                    Office = _db2.CfgorgCodes
                        .Where(coc => coc.OrgLevel == 2 && coc.Code == em.Org.Substring(3, 2))
                        .Select(coc => coc.Label)
                        .FirstOrDefault()
                })
                .ToListAsync();
            return new Result<object>(result);
        }

    }
}
