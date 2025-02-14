using Order.Dtos;

namespace Order.IService
{
    public interface IOrderService
    {
        Task<OrderResponceDtos> AddOrder(OrderRequestDtos orderRequestDtos, Guid ProductId);
        Task<OrderResponceDtos> GetAllOrders();
        Task<OrderResponceDtos> GetOrderById(Guid id);
    }
}
