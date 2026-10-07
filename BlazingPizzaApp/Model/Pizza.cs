namespace BlazingPizzaApp.Model
{
    public class Pizza
    {
        public const int DefaultSize = 12;
        public const int MinimumSize = 9;
        public const int MaximumSize = 12;

        public int Id { get; set; }
        public int OrderId { get; set; }
        public PizzaSpecial? Special { get; set; }
        public int SpecialId { get; set; }
        public int Size { get; set; } = DefaultSize;
        public List<PizzaTopping> Toppings { get; set; } = new();

        public decimal GetBasePrice() =>
            Special != null ? ((decimal)Size / DefaultSize) * Special.BasePrice : 0;

        public decimal GetTotalPrice() => GetBasePrice();
        public string GetFormattedTotalPrice() => GetTotalPrice().ToString("0.00");
    }
}