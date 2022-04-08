using AwsDeveloper2022Q1RU.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AwsDeveloper2022Q1RU.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IList<Product> Products;

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            Products = new List<Product>();
            _logger = logger;
        }

        [HttpPut]
        [Route("/{id}/add")]
        public bool Put(string id, Product product)
        {
            Products.Add(product);
            return true;
        }

        [HttpGet]
        [Route("/{id}")]
        public Product Get(string id)
        {
            return Products.First(x => x.Id?.Equals(id, StringComparison.OrdinalIgnoreCase) ?? false);
        }
    }
}
