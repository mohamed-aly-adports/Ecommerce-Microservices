using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.OrderService.Data;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Model;
using Ecommerce.OrderService.Kafka;
using Confluent.Kafka;
using Newtonsoft.Json;

namespace Ecommerce.OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController(OrderDbContext _db,IKafkaProducer producer) : ControllerBase
    { 
        [HttpGet]
        public async Task<List<Model.OrderModel>>  GetProducts()
        {
            return await _db.Orders.ToListAsync();
        }

        [HttpPost]
        public async Task<OrderModel> CreateOrder(OrderModel order)
        {
            try
            {
                order.OrderDate = DateTime.UtcNow;
                _db.Orders.Add(order);
                await _db.SaveChangesAsync();

                //await producer.ProduceAsync("order-topic", new Message<string, string>
                //{
                //    Key = order.Id.ToString(),
                //    Value = JsonConvert.SerializeObject(order)
                //});

                await producer.ProduceAsync("order-topic", new Message<string, string>
                {
                    Key = order.Id.ToString(),
                    Value = JsonConvert.SerializeObject(order)
                }).ConfigureAwait(false);

                return order;
            }
            catch (Exception ex)
            {
                return null;
            } 
        }
    }
}
