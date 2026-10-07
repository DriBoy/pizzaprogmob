using BlazingPizzaApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizzaApp.API.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PizzaStoreContext _context;
        public OrderRepository(PizzaStoreContext context)
        {
            _context = context;
        }
        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.Pizzas).ThenInclude(p => p.Special)
                .Include(o => o.Pizzas).ThenInclude(p => p.Toppings)
                .OrderByDescending(o => o.OrderId)
                .ToListAsync();
        }
        public async Task AddOrderAsync(Order order)
        {
            order.CreatedTime = DateTime.Now;
            // Supaya EF Core tidak insert ulang PizzaSpecial yang sudah ada
            foreach (var pizza in order.Pizzas)
            {
                if (pizza.Special != null)
                {
                    _context.Attach(pizza.Special);
                }
            }
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveOrderAsync(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}