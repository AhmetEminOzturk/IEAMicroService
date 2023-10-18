using IEAMicroService.Shared.Dtos;
using IEAMicroService.WebUI.Dtos.CategoryDto;

namespace IEAMicroservice.WebUI.Services.Abstract
{
    public interface ICategoryService
    {
        Task<ResultCategoryDto> GetAllCategories();
        Task<Response<ResultCategoryDto>> GetCategoryById(string id);
        Task<Response<NoContent>> CreateCategory(CreateCategoryDto createCategoryDto);
        Task<Response<NoContent>> UpdateCategory(UpdateCategoryDto updateCategoryDto);
        Task<Response<NoContent>> DeleteCategory(string id);
    }
}
