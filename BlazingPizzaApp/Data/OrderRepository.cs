using BlazingPizzaApp.Model;
using System.Net.Http.Json;

namespace BlazingPizzaApp.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly HttpClient _httpClient;

        public OrderRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            var orders = await _httpClient.GetFromJsonAsync<List<Order>>("api/orders");
            return orders ?? new List<Order>();
        }

        public async Task AddOrderAsync(Order order)
        {
            await _httpClient.PostAsJsonAsync("api/orders", order);
        }

        public async Task RemoveOrderAsync(int orderId)
        {
            await _httpClient.DeleteAsync($"api/orders/{orderId}");
        }
    }
}