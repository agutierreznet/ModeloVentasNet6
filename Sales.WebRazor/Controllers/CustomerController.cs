using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sales.ApplicationCore.DTOs;
using System.Security.Claims;
using System.Text;
using System.Net.Http.Headers;

namespace Sales.WebRazor.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5041/");

            IEnumerable<CustomerDto> ObjResponse = null;

            var token = HttpContext.User.Claims.First(c => c.Type == "token").Value;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var request = client.GetAsync("api/Customer").Result;
            if (request.IsSuccessStatusCode)
            {
                var JsonResponse = request.Content.ReadAsStringAsync().Result;
                ObjResponse = JsonConvert.DeserializeObject<IEnumerable<CustomerDto>>(JsonResponse);
            }

            var listado = ObjResponse;
            return View(listado);
        }

        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> SaveNew(CustomerDto customer)
        {
             var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5041/");

            var jsonObj = JsonConvert.SerializeObject(customer);

            var content = new StringContent(jsonObj, Encoding.UTF8, "application/json");

            var token = HttpContext.User.Claims.First(c => c.Type == "token").Value;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.PostAsync("api/Customer", content);

            return RedirectToAction("Index");
        }
    }
}
