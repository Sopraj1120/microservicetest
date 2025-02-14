using Order.Database;
using Order.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Order.IRepository;

namespace Order.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _orderDb;

        public OrderRepository(OrderDbContext orderDb)
        {
            _orderDb = orderDb;
        }

        public async Task<Order.Entity.Order> AddOrder(Order.Entity.Order order)  
        {
            var data = await _orderDb.Orders.AddAsync(order).ConfigureAwait(false);
            await _orderDb.SaveChangesAsync().ConfigureAwait(false);
            return data.Entity;
        }

        public async Task<Order.Entity.Order> GetOrderById(Guid id)  
        {
            var data = await _orderDb.Orders.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false)
                ?? throw new KeyNotFoundException("Order Not Found!");
            return data;
        }

        public async Task<IEnumerable<Order.Entity.Order>> GetAllOrders()  
        {
            var data = await _orderDb.Orders.ToListAsync().ConfigureAwait(false);
            return data;
        }
    }
}
