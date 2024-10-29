using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderMyFood.Business.Service.Order;
using OrderMyFood.DataModels;
using static OrderMyFood.DataModels.Helper.Helper;

namespace OrderMyFood.Service.Controllers
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

        #region Place Order
        [HttpPost("PlaceOrder")]
        [ProducesResponseType(typeof(ResponseContext<OrderItemMasterModel>), StatusCodes.Status201Created)]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderItemMasterModel order)
        {
            var response = await _orderService.PlaceOrderAsync(order);
         
            return Ok(response);
        }
        #endregion

        #region Get Order
        [HttpGet("GetOrder/{orderId}")]
        [ProducesResponseType(typeof(IEnumerable<OrderMasterModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOrder(int orderId)
        {
            var order = await _orderService.GetOrderAsync(orderId);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
        #endregion

        #region Update Order
        [HttpPut("UpdateOrder")]
        [ProducesResponseType(typeof(ResponseContext<OrderItemMasterModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateOrder([FromBody] OrderItemMasterModel order)
        {
            var response = await _orderService.UpdateOrderAsync(order);
          
            return Ok(response);
        }
        #endregion

        #region Cancel Order
        [HttpDelete("CancelOrder/{orderId}")]
        [ProducesResponseType(typeof(ResponseContext<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CancelOrder(int orderId)
        {
            var response = await _orderService.CancelOrderAsync(orderId);
        
            return Ok(response);
          
        }
        #endregion
    }
}
