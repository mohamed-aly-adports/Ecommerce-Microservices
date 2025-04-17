using Ecommerce.ProductService.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.ProductService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(ProductDbContext dbContext) : ControllerBase
    {
        [HttpGet]
        public async Task<List<Model.ProductModel>>  GetProducts()
        {
            return await dbContext.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Model.ProductModel> GetProduct(int id)
        {
            return await dbContext.Products.FindAsync(id);
        }
    }
}
