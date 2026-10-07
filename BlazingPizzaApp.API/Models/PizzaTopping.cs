using System.ComponentModel.DataAnnotations;

namespace BlazingPizzaApp.API.Models
{
    public class PizzaTopping
    {
        [Key]
        public int ToppingId { get; set; }
        public int PizzaId { get; set; }
    }
}
