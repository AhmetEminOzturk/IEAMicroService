using IEAMicroservice.WebUI.Services.Abstract;
using IEAMicroService.Shared.Dtos;
using IEAMicroService.WebUI.Dtos.CategoryDto;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;

namespace IEAMicroservice.WebUI.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IHttpClientFactory _httpClient;

        public CategoryService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var client = _httpClient.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCategoryDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5011/api/Categories", content);
        }

        public async Task DeleteCategory(string id)
        {
            var client = _httpClient.CreateClient();
            var responseMessage = await client.DeleteAsync("http://localhost:5011/api/Categories?id=" + id);
        }

        public async Task<ResultCategoryDto> GetAllCategories()
        {
            var client = _httpClient.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5011/api/Categories");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultCategoryDto>(jsonData);
            return values;
        }

        public async Task<UpdateCategoryDto.Data> GetCategoryById(string id)
        {
            var client = _httpClient.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5011/api/Categories/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(jsonData);
            var data = jsonObject["data"].ToString();
            var values = JsonConvert.DeserializeObject<UpdateCategoryDto.Data>(data);
            return values;
        }

        public async Task UpdateCategory(UpdateCategoryDto.Data updateCategoryDto)
        {
            var client = _httpClient.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5011/api/Categories", content);
        }
    }
}
