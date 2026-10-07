using BlazingPizzaApp.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IPizzaSpecials, PizzaSpecialsDAL>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddSqlite<PizzaStoreContext>("Data Source=pizza.db");
// BARU: izinkan BlazingPizzaApp memanggil API ini
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowApp", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors("AllowApp"); // BARU — taruh sebelum UseAuthorization/MapControllers

app.UseAuthorization();

app.MapControllers();

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PizzaStoreContext>();
    db.Database.Migrate();

    if (!db.PizzaSpecials.Any())
    {
        SeedData.Initialize(db);
    }
}
app.Run();
