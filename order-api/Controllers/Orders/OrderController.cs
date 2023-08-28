using Microsoft.AspNetCore.Mvc;
using order_api.Models;
using order_api.Models.Attributes;
using order_api.requests.order;
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
        
        [HttpPut]
        [MustBeAdmin]
        public async Task<IActionResult> UpdateOrder(UpdateOrderRequest request)
        {
            return Ok(await _orderService.UpdateOrder(request));
        } 
        
        [HttpPut("cancel/{id}")]
        [MustBeAdmin]
        public async Task<IActionResult> CancelOrder(string id)
        {
            return Ok(await _orderService.CancelOrder(id));
        }

        [HttpPut("complete/{id}")]
        [MustBeAdmin]
        public async Task<IActionResult> MarkAsComplete(string id)
        {
            return Ok(await _orderService.MarkAsComplete(id));
        }

        [HttpDelete("{id}")]
        [MustBeAdmin]
        public async Task<IActionResult> DeleteOrder(string id)
        {
            return Ok(await _orderService.DeleteOrder(id));
        }

        [HttpGet]
        [MustBeAdmin]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok(await _orderService.GetAllOrders());
        }

        [HttpGet("{id}")]
        [MustBeAdmin]
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
