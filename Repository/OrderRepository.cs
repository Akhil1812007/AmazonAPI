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
            var od = _context.OrderDetails.Find(orderDetailId);
            return od;
        }

        public async  Task<OrderMaster> GetOrderMasterById(int orderMasterId)
        {

            var od = _context.OrderMasters.Find(orderMasterId);
            return od;
        }
       
        public async  Task<OrderMaster> UpdateOrderMaster(int orderMasterId, OrderMaster orderMaster)
        {
            _context.Update(orderMaster);
            _context.SaveChanges();
            return orderMaster;
        }
    }
}
