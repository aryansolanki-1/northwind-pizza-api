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
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AppSetting>(entity =>
        {
            entity.ToTable("AppSettings");

            entity.HasKey(e => e.SettingId);

            entity.Property(e => e.SettingKey).IsRequired();

            entity.Property(e => e.SettingValue).IsRequired(false);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customers");

            entity.HasKey(e => e.CustomerId);

            entity.Property(e => e.FirstName)
                .IsRequired();

            entity.Property(e => e.LastName)
                .IsRequired();

            entity.Property(e => e.Email)
                .IsRequired();

            entity.Property(e => e.Phone)
                .IsRequired(false);

            entity.Property(e => e.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        });


        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId);
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId);
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.ToTable("OrderStatuses", table =>
            {
                table.HasCheckConstraint(
                    "CK_OrderStatuses_IsActive",
                    "IsActive IN (0, 1)");
            });

            entity.HasKey(e => e.OrderStatusId);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId);
        });

        modelBuilder.Entity<Pizza>(entity =>
        {
            entity.ToTable("Pizzas", table =>
            {
                table.HasCheckConstraint(
                    "CK_Pizzas_BasePrice",
                    "BasePrice >= 0");

                table.HasCheckConstraint(
                    "CK_Pizzas_IsActive",
                    "IsActive IN (0,1)");
            });

            entity.HasKey(e => e.PizzaId);

            entity.Property(e => e.Name).IsRequired();

            entity.Property(e => e.Description).IsRequired(false);

            entity.Property(e => e.BasePrice).IsRequired();

            entity.Property(e => e.ImageUrl).IsRequired();

            entity.Property(e => e.IsActive).IsRequired().HasDefaultValue(1);
        });
    }
}
