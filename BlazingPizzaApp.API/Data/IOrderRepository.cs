using BlazingPizzaApp.API.Models;

namespace BlazingPizzaApp.API.Data
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrdersAsync();
        Task AddOrderAsync(Order order);
        Task RemoveOrderAsync(int orderId);
    }
}