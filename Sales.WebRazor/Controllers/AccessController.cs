using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sales.ApplicationCore.DTOs;
using System.Security.Claims;

namespace Sales.WebRazor.Controllers
{
    public class AccessController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Ingresar(string nombre, string contrasenia)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5041/");

            UsuarioDto usuario=null;

            var request = client.GetAsync("api/Access/" + nombre + "/" + contrasenia).Result;
            if (request.IsSuccessStatusCode)
            {
                var JsonResponse = request.Content.ReadAsStringAsync().Result;
                usuario = JsonConvert.DeserializeObject<UsuarioDto>(JsonResponse);
            } 

            if (usuario != null)
            {
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, usuario.IdUsuario.ToString()),
                        new Claim("token", usuario.token)
                    };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                Thread.CurrentPrincipal = claimsPrincipal;

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Index"); ;
            }
        }
    }
}
