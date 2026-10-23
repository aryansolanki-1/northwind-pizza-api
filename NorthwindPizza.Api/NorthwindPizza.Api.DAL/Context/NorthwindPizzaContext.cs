using Microsoft.EntityFrameworkCore;
using NorthwindPizza.Api.DAL.Models;

namespace NorthwindPizza.Api.DAL.Context;

public partial class NorthwindPizzaContext(DbContextOptions<NorthwindPizzaContext> options) : DbContext(options)
{
    public virtual DbSet<AppSetting> AppSettings => Set<AppSetting>();

    public virtual DbSet<Customer> Customers => Set<Customer>();

    public virtual DbSet<Employee> Employees => Set<Employee>();

    public virtual DbSet<OrderItem> OrderItems => Set<OrderItem>();

    public virtual DbSet<OrderStatus> OrderStatuses => Set<OrderStatus>();

    public virtual DbSet<Order> Orders => Set<Order>();

    public virtual DbSet<Pizza> Pizzas => Set<Pizza>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppSetting>(entity =>
        {
            entity.HasKey(e => e.SettingId);
        });
    }
}
