using Mapster;
using Order.Dtos;
using Order.IRepository;
using Order.IService;
using Product.Dtos.ResponceDtos;
using Product.IRepository;

namespace Order.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderrepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderrepository = orderRepository;
          
        }

        public async Task<OrderResponceDtos> AddOrder(OrderRequestDtos orderRequestDtos, Guid ProductId)
        {
            var order = orderRequestDtos.Adapt<Order.Entity.Order>();
            var data = await _orderrepository.AddOrder(order).ConfigureAwait(false);
            var res = data.Adapt<OrderResponceDtos>();
            return res;
        }

        public async Task<OrderResponceDtos> GetAllOrders()
        {
            var data = await _orderrepository.GetAllOrders().ConfigureAwait(false);
            var res = data.Adapt<OrderResponceDtos>();
            return res;
        }

        public async Task<OrderResponceDtos> GetOrderById(Guid id)
        {
            var data = await _orderrepository.GetOrderById(id).ConfigureAwait(false)
                ?? throw new KeyNotFoundException("Order Not Found!");
            var res = data.Adapt<OrderResponceDtos>();
            return res;
        }
    }
}
