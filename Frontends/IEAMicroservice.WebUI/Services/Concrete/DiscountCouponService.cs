using IEAMicroservice.WebUI.Services.Abstract;
using IEAMicroService.WebUI.DiscountDtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace IEAMicroservice.WebUI.Services.Concrete
{
    public class DiscountCouponService : IDiscountCouponService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DiscountCouponService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task CreateDiscountCoupons(CreateDiscountCouponDtos createDiscountCouponsDto)
        {
            createDiscountCouponsDto.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            createDiscountCouponsDto.UserId = Guid.NewGuid().ToString();
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createDiscountCouponsDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5012/api/DiscountCoupons", content);
        }

        public async Task DeleteDiscountCoupons(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("http://localhost:5012/api/DiscountCoupons?id=" + id);
        }

        public async Task<ResultDiscountCouponDtos> GetAllCategories()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5012/api/DiscountCoupons");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultDiscountCouponDtos>(jsonData);
            return values;
        }

        public async Task<UpdateDiscountCouponDtos.Data> GetDiscountCouponsById(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5012/api/DiscountCoupons/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(jsonData);
            var data = jsonObject["data"].ToString();
            var values = JsonConvert.DeserializeObject<UpdateDiscountCouponDtos.Data>(data);
            return values;
        }

        public async Task UpdateDiscountCoupons(UpdateDiscountCouponDtos.Data updateDiscountCouponsDto)
        {
            updateDiscountCouponsDto.UserId = "Aa";
            updateDiscountCouponsDto.CreatedDate = DateTime.Now;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateDiscountCouponsDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5012/api/DiscountCoupons", content);
        }
    }
}
