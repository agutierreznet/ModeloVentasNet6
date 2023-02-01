using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Sales.ApplicationCore.DTOs;
using System.Net.Http.Headers;
using System.Text;

namespace Sales.WebRazor.Controllers
{
    public class SaleController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5041/");

            IEnumerable<SaleDto> ObjResponse = null;

            var token = HttpContext.User.Claims.First(c => c.Type == "token").Value;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var request = client.GetAsync("api/Sale").Result;
            if (request.IsSuccessStatusCode)
            {
                var JsonResponse = request.Content.ReadAsStringAsync().Result;
                ObjResponse = JsonConvert.DeserializeObject<IEnumerable<SaleDto>>(JsonResponse);
            }

            var listado = ObjResponse;
            return View(listado);
        }

        public IActionResult Create()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5041/");

            IEnumerable<ProductDto> ObjResponseP = null;
            IEnumerable<CustomerDto> ObjResponseC = null;

            var token = HttpContext.User.Claims.First(c => c.Type == "token").Value;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var request1 = client.GetAsync("api/Product").Result;
            if (request1.IsSuccessStatusCode)
            {
                var JsonResponse = request1.Content.ReadAsStringAsync().Result;
                ObjResponseP = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(JsonResponse);
            }

            var request2 = client.GetAsync("api/Customer").Result;
            if (request2.IsSuccessStatusCode)
            {
                var JsonResponse = request2.Content.ReadAsStringAsync().Result;
                ObjResponseC = JsonConvert.DeserializeObject<IEnumerable<CustomerDto>>(JsonResponse);
            }


            

            List<SelectListItem> clientes = new List<SelectListItem>();
            foreach (var item in ObjResponseC)
            {
                clientes.Add(new SelectListItem { Value = item.CustomerId.ToString(), Text = item.CustomerName });
            }
            ViewBag.clientes = clientes;

            List<SelectListItem> productos = new List<SelectListItem>();
            foreach (var item in ObjResponseP)
            {
                productos.Add(new SelectListItem { Value = item.ProductId.ToString(), Text = item.ProductName });
            }
            ViewBag.productos = productos;
            return View();
        }
        public async Task<IActionResult> SaveNew(SaleDto sale)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5041/");

            var jsonObj = JsonConvert.SerializeObject(sale);

            var content = new StringContent(jsonObj, Encoding.UTF8, "application/json");

            var token = HttpContext.User.Claims.First(c => c.Type == "token").Value;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.PostAsync("api/Sale", content);

            return RedirectToAction("Index");
        }
    }
}
