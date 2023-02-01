using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.ApplicationCore.DTOs;
using Sales.ApplicationCore.Interfaces;

namespace Sales.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var listado = _productRepository.GetProducts();
            return Ok(listado);
        }

        [HttpPost]
        public IActionResult Post(ProductDto product)
        {
            bool rpta = _productRepository.PostProduct(product);
            return Ok(rpta);
        }
    }
}
