using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.ApplicationCore.DTOs;
using Sales.ApplicationCore.Interfaces;

namespace Sales.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleRepository _saleRepository;
        public SaleController(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var listado = _saleRepository.GetSales();
            return Ok(listado);
        }

        [HttpPost]
        public IActionResult Post(SaleDto sale)
        {
            bool rpta = _saleRepository.PostSale(sale);
            return Ok(rpta);
        }
    }
}
