using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.ApplicationCore.DTOs;
using Sales.ApplicationCore.Interfaces;
using Sales.Infrastructure.Repositories;

namespace Sales.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessController : ControllerBase
    {
        private readonly IAccessRepository _accessRepository;
        public AccessController(IAccessRepository accessRepository)
        {
            _accessRepository = accessRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var listado = _accessRepository.GetUsers();
            return Ok(listado);
        }

        //[HttpPost("login")]
        [HttpGet]
        [Route("{nombre}/{contrasenia}")]
        public IActionResult GetUser(string nombre, string contrasenia)
        {
            UsuarioDto usuario = _accessRepository.GetUser(nombre, contrasenia);

            return Ok(usuario);
        }
    }
}
