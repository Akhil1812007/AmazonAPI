using Amazon.Models;
using Amazon.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository repository)
        {
            _orderRepository = repository;
        }
        

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderMaster>> GetOrderMaster(int id)
        {
            return await _orderRepository.GetOrderMasterById(id);
        }
        [HttpPut("id")]
        public async Task<ActionResult<OrderMaster>> PutOrMaster(int id, OrderMaster om)
        {
            return await _orderRepository.UpdateOrderMaster(id, om);

        }
        [HttpPost("orderMaster")]
        public async Task<ActionResult<OrderMaster>> PostOrMaster(OrderMaster om)
        {
            return await _orderRepository.AddOrderMaster(om);


        }
        [HttpPost("orderDetail")]
        public async Task<ActionResult<OrderDetail>> PostOrDetail(OrderDetail od)
        {
            return await _orderRepository.AddOrderDetail(od);


        }
        [HttpGet("orderDetail")]
        public async Task<ActionResult<OrderDetail>> GetOrderDetail(int id)
        {
            return await _orderRepository.GetOrderDetailById(id);
        }

    }
}
