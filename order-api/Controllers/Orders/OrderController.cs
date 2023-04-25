using Microsoft.AspNetCore.Mvc;
using order_api.Models;
using order_api.Services.Orders;

namespace order_api.Controllers.Orders
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(CreateOrderRequest createOrderRequest)
        {
            return Ok(await _orderService.AddOrder(createOrderRequest));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(string id)
        {
            return Ok(await _orderService.DeleteOrder(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok(await _orderService.GetAllOrders());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(string id)
        {
            return Ok(await _orderService.GetOrder(id));
        }

        [HttpGet("projectnumbers")]
        public async Task<IActionResult> GetActiveJobNumbers()
        {
            return Ok(await _orderService.GetProjectNumbers());
        }

        [HttpGet("papersizes")]
        public async Task<IActionResult> GetPaperSizes()
        {
            return Ok(await _orderService.GetPaperSizes());
        }

        [HttpGet("ordersignees")]
        public async Task<IActionResult> GetOrderSignees()
        {
            return Ok(await _orderService.GetOrderSignees());
        }

        [HttpGet("employees")]
        public async Task<IActionResult> GetEmployees()
        {
            return Ok(await _orderService.GetEmployees());
        }

    }

}
