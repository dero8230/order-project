using order_api.Models;
using order_api.Models.PR;
using order_api.Models.Wrapper;

namespace order_api.Services.Orders
{
    public interface IOrderService : IServerService
    {
        Task<Result<Order>> AddOrder(CreateOrderRequest createOrderRequest);
        Task<Result<bool>> DeleteOrder(string id);
        Task<Result<List<Order>>> GetAllOrders();
        Task<Result<object>> GetEmployees();
        Task<Result<Order>> GetOrder(string id);
        Task<Result<object>> GetOrderSignees();
        Task<Result<List<PaperSize>>> GetPaperSizes();
        Task<Result<List<ActiveJob>>> GetProjectNumbers();
    }
}
