using BlazingPizzaApp.Data;
using BlazingPizzaApp.Services;
using Microsoft.Extensions.Logging;

namespace BlazingPizzaApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            // Semua data (specials & orders) diambil dari API, bukan lokal
            builder.Services.AddHttpClient<IPizzaSpecials, PizzaSpecialsServices>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7219/");
            });
            builder.Services.AddHttpClient<IOrderRepository, OrderRepository>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7219/");
            });

            builder.Services.AddScoped<OrderState>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
