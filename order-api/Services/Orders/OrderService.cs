using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using order_api.Models;
using order_api.Models.Exceptions;
using order_api.Models.PR;
using order_api.Models.Wrapper;
using order_api.requests.order;
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

        public async Task<Result<Order>> UpdateOrder(UpdateOrderRequest request)
        {
            var order = await _db.Orders.FirstOrDefaultAsync(x => x.OrderId == request.OrderId);

            if (order == null)
            {
                throw new EntityNotFoundException("Order not found");
            }

            order.ProjectNumber = request.ProjectNumber ?? order.ProjectNumber;
            order.PrintingFor = request.PrintingFor ?? order.PrintingFor;
            order.DateRequired = request.DateRequired ?? order.DateRequired;
            order.SpecialInstructions = request.SpecialInstructions ?? order.SpecialInstructions;
            order.OrderType = request.OrderType ?? order.OrderType;
            order.OrderLink = request.OrderLink ?? order.OrderLink;
            order.NotifyEmployee = request.NotifyEmployee ?? order.NotifyEmployee;
            order.NotifyEmployee2 = request.NotifyEmployee2 ?? order.NotifyEmployee2;
            order.Extras = request.Extras ?? order.Extras;

            _db.Orders.Update(order);
            await _db.SaveChangesAsync();

            return new Result<Order>(order);
        }

        public async Task<Result<Order>> CancelOrder(string id)
        {
            var order = await _db.Orders.FirstOrDefaultAsync(x => x.OrderId == id);
            if (order == null || order.Status == OrderStatus.Canceled) throw new EntityNotFoundException("Order doesn't exist or Order has already been canceled");
            order.Status = OrderStatus.Canceled;
            _db.Update(order);
            await _db.SaveChangesAsync();
            return Result.GetResult(order);
        }
        public async Task<Result<Order>> MarkAsComplete(string id)
        {
            var order = await _db.Orders.FirstOrDefaultAsync(x => x.OrderId == id);
            if (order == null || order.Status == OrderStatus.Completed) throw new EntityNotFoundException("Order doesn't exist or Order has already been Completed");
            order.Status = OrderStatus.Completed;
            _db.Update(order);
            await _db.SaveChangesAsync();
            return Result.GetResult(order);
        }

        public async Task<Result<List<Order>>> GetAllOrders()
        {
            var orders = await _db.Orders.AsQueryable().Where(x => true).OrderByDescending(x => x.DateSubmitted).ToListAsync();
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
            var order =  await _db.Orders.FirstOrDefaultAsync(x => x.OrderId == id);
            if (order == null) throw new EntityNotFoundException("Order not found");
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
