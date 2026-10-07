namespace BlazingPizzaApp.Services;

using BlazingPizzaApp.Data;
using BlazingPizzaApp.Model;

public class OrderState
{
    private readonly IOrderRepository orderRepository;

    public OrderState(IOrderRepository orderRepository)
    {
        this.orderRepository = orderRepository;
    }

    public bool ShowingConfigureDialog { get; private set; }
    public Pizza? ConfiguringPizza { get; private set; }
    public Order Order { get; private set; } = new Order();

    public void ShowConfigurePizzaDialog(PizzaSpecial special)
    {
        ConfiguringPizza = new Pizza()
        {
            Special = special,
            SpecialId = special.Id,
            Size = Pizza.DefaultSize,
            Toppings = new List<PizzaTopping>(),
        };
        ShowingConfigureDialog = true;
    }

    public void CancelConfigurePizzaDialog()
    {
        ConfiguringPizza = null;
        ShowingConfigureDialog = false;
    }

    public void ConfirmConfigurePizzaDialog()
    {
        if (ConfiguringPizza != null)
        {
            Order.Pizzas.Add(ConfiguringPizza);
            ConfiguringPizza = null;
        }
        ShowingConfigureDialog = false;
    }

    public async Task PlaceOrderAsync()
    {
        await orderRepository.AddOrderAsync(Order);
        Order = new Order();
    }

    public void RemoveConfiguredPizza(Pizza pizza)
    {
        Order.Pizzas.Remove(pizza);
    }
}