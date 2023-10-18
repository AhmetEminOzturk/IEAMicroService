using IEAMicroservice.WebUI.Services.Abstract;
using IEAMicroService.Shared.Dtos;
using IEAMicroService.WebUI.Dtos.CategoryDto;
using Newtonsoft.Json;
using System.Net.Http;

namespace IEAMicroservice.WebUI.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IHttpClientFactory _httpClient;

        public CategoryService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<Response<NoContent>> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoContent>> DeleteCategory(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultCategoryDto> GetAllCategories()
        {
            var client = _httpClient.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5011/api/Categories");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultCategoryDto>(jsonData);
            return values;
        }

        public Task<Response<ResultCategoryDto>> GetCategoryById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoContent>> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            throw new NotImplementedException();
        }
    }
}
