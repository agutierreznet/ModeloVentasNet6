using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.ApplicationCore.DTOs;
using Sales.ApplicationCore.Interfaces;
using Sales.Infrastructure.Repositories;

namespace Sales.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var listado = _customerRepository.GetCustomers();
            return Ok(listado);
        }

        [HttpPost]
        public IActionResult Post(CustomerDto customer)
        {
            bool rpta = _customerRepository.PostCustomer(customer);
            return Ok(rpta);
        }
    }
}
