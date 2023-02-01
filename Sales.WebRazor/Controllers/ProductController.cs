using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sales.ApplicationCore.DTOs;
using System.Net.Http.Headers;
using System.Text;

namespace Sales.WebRazor.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5041/");

            IEnumerable<ProductDto> ObjResponse = null;

            var token = HttpContext.User.Claims.First(c => c.Type == "token").Value;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var request = client.GetAsync("api/Product").Result;
            if (request.IsSuccessStatusCode)
            {
                var JsonResponse = request.Content.ReadAsStringAsync().Result;
                ObjResponse = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(JsonResponse);
            }

            var listado = ObjResponse;
            return View(listado);
        }

        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> SaveNew(ProductDto product)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5041/");

            var jsonObj = JsonConvert.SerializeObject(product);

            var content = new StringContent(jsonObj, Encoding.UTF8, "application/json");

            var token = HttpContext.User.Claims.First(c => c.Type == "token").Value;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.PostAsync("api/Product", content);

            return RedirectToAction("Index");
        }
    }
}
