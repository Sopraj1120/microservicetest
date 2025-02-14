using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Dtos;
using Order.IService;

namespace Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("Add-order/{ProductId}")]
        public async Task<IActionResult> AddOrder(OrderRequestDtos orderRequestDtos, Guid ProductId)
        {
            var data = await _orderService.AddOrder(orderRequestDtos, ProductId).ConfigureAwait(false);
            return Ok(data);
        }

        [HttpGet("Get-all-orders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var data = await _orderService.GetAllOrders().ConfigureAwait(false);
            return Ok(data);
        }

        [HttpGet("Get-order/{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var data = await _orderService.GetOrderById(id).ConfigureAwait(false);
            return Ok(data);
        }
    }
}
