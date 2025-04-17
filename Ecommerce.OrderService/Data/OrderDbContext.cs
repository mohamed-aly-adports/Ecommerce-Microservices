using Ecommerce.Model;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.OrderService.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<OrderDbContext>().HasData(new List<ProductModel>()
        //    //{
        //    //     new OrderModel { Id = 1 , CustomerName = "Shirt" , Quantity = 20 , OrderDate = 20},
        //    //     new OrderModel { Id = 2, CustomerName = "Pant", Quantity = 50, OrderDate = 50 },
        //    //     new OrderModel { Id = 3, CustomerName = "Polo", Quantity = 100, OrderDate = 30 },
        //    //});

        //    base.OnModelCreating(modelBuilder);
        //}

        public  DbSet<OrderModel> Orders  { get; set; }
    }
}
