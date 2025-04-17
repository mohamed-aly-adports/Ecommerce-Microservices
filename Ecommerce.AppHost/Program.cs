var builder = DistributedApplication.CreateBuilder(args);
var productApi = builder.AddProject<Projects.Ecommerce_ProductService>("apiserviceproduct");
var orderApi = builder.AddProject<Projects.Ecommerce_OrderService>("apiserviceorder");
builder.AddProject<Projects.Ecommerce_Web>("webfrontend")
    .WithReference(productApi)
    .WithReference(orderApi);
 
builder.Build().Run();
