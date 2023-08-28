using order_api.Models;
using order_api.Models.PR;
using order_api.Models.Wrapper;
using order_api.requests.order;

namespace order_api.Services.Orders
{
    public interface IOrderService : IServerService
    {
        Task<Result<Order>> AddOrder(CreateOrderRequest createOrderRequest);
        Task<Result<Order>> CancelOrder(string id);
        Task<Result<bool>> DeleteOrder(string id);
        Task<Result<List<Order>>> GetAllOrders();
        Task<Result<object>> GetEmployees();
        Task<Result<Order>> GetOrder(string id);
        Task<Result<object>> GetOrderSignees();
        Task<Result<List<PaperSize>>> GetPaperSizes();
        Task<Result<List<ActiveJob>>> GetProjectNumbers();
        Task<Result<Order>> MarkAsComplete(string id);
        Task<Result<Order>> UpdateOrder(UpdateOrderRequest request);
    }
}
