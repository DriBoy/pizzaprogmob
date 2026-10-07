using BlazingPizzaApp.Model;

namespace BlazingPizzaApp.Data
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrdersAsync();
        Task AddOrderAsync(Order order);
        Task RemoveOrderAsync(int orderId);
    }
}