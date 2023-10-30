using IEAMicroservice.WebUI.Services.Abstract;
using IEAMicroService.Shared.Dtos;
using IEAMicroService.WebUI.Dtos.ProductDto;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace IEAMicroservice.WebUI.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _httpClient;

        public ProductService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProduct(CreateProductDto createProductDto)
        {
            var client = _httpClient.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5011/api/Products", content);
        }

        public async Task DeleteProduct(string id)
        {
            var client = _httpClient.CreateClient();
            var responseMessage = await client.DeleteAsync("http://localhost:5011/api/Products?id=" + id);
        }

        public async Task<ResultProductDto> GetAllProducts()
        {
            var client = _httpClient.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5011/api/Products");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultProductDto>(jsonData);
            return values;
        }

        public async Task<UpdateProductDto.Data> GetProductById(string id)
        {
            var client = _httpClient.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5011/api/Products/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(jsonData);
            var data = jsonObject["data"].ToString();
            var values = JsonConvert.DeserializeObject<UpdateProductDto.Data>(data);
            return values;
        }

        public async Task UpdateProduct(UpdateProductDto.Data updateProductDto)
        {
            var client = _httpClient.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5011/api/Products", content);
        }
    }
}
