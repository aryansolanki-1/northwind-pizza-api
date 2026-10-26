using Microsoft.EntityFrameworkCore;
using NorthwindPizza.Api.DAL.Context;
using NorthwindPizza.Api.DAL.Repository;
using NorthwindPizza.Api.DAL.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetValue<string>("ConnectionString");
builder.Services.AddDbContext<NorthwindPizzaContext>(options =>
{
    options.UseSqlite(connectionString);
});

builder.Services.AddScoped<IAppSettingRepository, AppSettingRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IPizzaRepository, PizzaRepository>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
