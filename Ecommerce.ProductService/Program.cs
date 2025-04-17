using Ecommerce.ProductService.Data;
using Ecommerce.ProductService.Kafka;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddHostedService<KafkaConsumer>();

builder.Services.AddDbContext<ProductDbContext>(
    options => options.UseSqlServer(
        $"data source=(localdb)\\MSSQLLocalDB;initial catalog = EcommerceProduct;integrated security = true;trustservercertificate=true;")
    );
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
