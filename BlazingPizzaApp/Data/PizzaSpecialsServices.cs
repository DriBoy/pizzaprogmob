using BlazingPizzaApp.Model;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace BlazingPizzaApp.Data
{
    public class PizzaSpecialsServices : IPizzaSpecials
    {
        private readonly HttpClient _httpClient;

        public PizzaSpecialsServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<PizzaSpecial>> GetPizzaSpecialsAsync()
        {
            try
            {
                var specials = await _httpClient.GetFromJsonAsync<List<PizzaSpecial>>("api/Specials");
                return specials ?? new List<PizzaSpecial>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving pizza specials: {ex.Message}");
                throw;
            }
        }
    }
}
