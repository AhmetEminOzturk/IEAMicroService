using IEAMicroService.Shared.Dtos;
using IEAMicroService.WebUI.DiscountDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace IEAMicroservice.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DiscountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5012/api/DiscountCoupons");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultDiscountCouponDtos>(jsonData);
            return View(values.data.ToList());
        }

        [HttpGet]
        public IActionResult CreateDiscount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscount(CreateDiscountCouponDtos createDiscountCouponDtos)
        {
            createDiscountCouponDtos.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            createDiscountCouponDtos.UserId = Guid.NewGuid().ToString();
            var client = _httpClientFactory.CreateClient();
            var jsonData= JsonConvert.SerializeObject(createDiscountCouponDtos);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("http://localhost:5012/api/DiscountCoupons",content);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteDiscount(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("http://localhost:5012/api/DiscountCoupons?id=" + id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDiscount(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5012/api/DiscountCoupons/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateDiscountCouponDtos>(jsonData);
            return View(values.data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDiscount(UpdateDiscountCouponDtos updateDiscountCouponDtos)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateDiscountCouponDtos);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5012/api/DiscountCoupons", content);
            return RedirectToAction("Index");
        }
    }
}
