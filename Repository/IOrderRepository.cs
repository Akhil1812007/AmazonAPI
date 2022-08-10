using Amazon.Models;

namespace Amazon.Repository
{
    public interface IOrderRepository
    {
        Task<OrderMaster> AddOrderMaster(OrderMaster orderMaster);
        Task<OrderMaster> UpdateOrderMaster(int orderMasterId, OrderMaster orderMaster);
        Task<OrderMaster> GetOrderMasterById(int orderMasterId);
        Task<OrderDetail> GetOrderDetailById(int orderMasterId);
        Task<OrderDetail> AddOrderDetail(OrderDetail orderDetail);

    }
}
