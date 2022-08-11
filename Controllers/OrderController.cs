using Amazon.Models;
using Amazon.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Amazon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;

        public OrderController(IOrderRepository repository,ICartRepository cartRepository)
        {
            _orderRepository = repository;
            _cartRepository = cartRepository;
            
        }
        //public OrderController(ICartRepository cartRepository)
        //{
        //    _cartRepository = cartRepository;
        //}

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
        [HttpGet("order")]
        public async Task<ActionResult<OrderDetail>> GetOrderDetail(int id)
        {
            return await _orderRepository.GetOrderDetailById(id);
        }



        [HttpPost("Buy")]
       
        public async Task Buy(int customerId)
        {


            List<Cart> c =  await _cartRepository.GetAllCart(customerId);


           // List<OrderDetail> orderItems = new List<OrderDetail>();

            OrderMaster om = new OrderMaster();
            om.OrderDate = DateTime.Today;
            om.CustomerId = customerId;
            om.total = 0;
            if (c != null)
            {
                foreach (var cart in c)
                {
                    int price = (int)cart.Product.UnitPrice;


                    om.total +=  (cart.ProductQuantity *price);
                }
            }
            await _orderRepository.AddOrderMaster(om);
            foreach (var item in c)
            {
                OrderDetail detail = new OrderDetail();
                detail.ProductId = item.ProductId;
                detail.ProductQuantity = item.ProductQuantity;
                detail.ProductRate = item.Product.UnitPrice;
                detail.OrderMasterId = om.OrderMasterId;
                await _orderRepository.AddOrderDetail(detail);
                await _cartRepository.DeleteFromCart(item.CartId);
            }
        }

    }
}
