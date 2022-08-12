using Amazon.Models;

namespace Amazon.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AmazonContext _context;
        public OrderRepository(AmazonContext context)
        {
            _context = context;
        }

        public async  Task<OrderDetail> AddOrderDetail(OrderDetail orderDetail)
        {
            
            _context.Add(orderDetail);
            await _context.SaveChangesAsync();
            return orderDetail;
        }

        public async Task<OrderMaster> AddOrderMaster(OrderMaster orderMaster)
        {
            _context.Add(orderMaster);
            await _context.SaveChangesAsync();
            return orderMaster;
        }

        public async Task<OrderDetail> GetOrderDetailById(int orderDetailId)
        {
            var od = await _context.OrderDetails.FindAsync(orderDetailId);
            return od;
        }

        public async  Task<OrderMaster> GetOrderMasterById(int orderMasterId)
        {

            var od = await _context.OrderMasters.FindAsync(orderMasterId);
            return od;
        }
       
        public async  Task<OrderMaster> UpdateOrderMaster(int orderMasterId, OrderMaster orderMaster)
        {
            if (orderMaster.AmountPaid == orderMaster.total)
            {
                _context.Update(orderMaster);
                await _context.SaveChangesAsync();
                List<Cart> c=(from i in _context.carts where i.CustomerId==orderMaster.CustomerId select i).ToList();
                foreach (Cart cart in c)
                {
                    _context.Remove(cart);
                }
                return orderMaster;                       
            }
            else
            {
               List<OrderDetail> od = (from i in _context.OrderDetails where i.OrderMasterId==orderMasterId select i).ToList();
                foreach (OrderDetail item in od)
                {
                    _context.Remove(item);
                }


                _context.Remove(orderMaster);
                await _context.SaveChangesAsync();
                return null;
            }
        }
    }
}
