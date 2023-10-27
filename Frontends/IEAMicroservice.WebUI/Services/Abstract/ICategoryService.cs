using IEAMicroService.Shared.Dtos;
using IEAMicroService.WebUI.Dtos.CategoryDto;

namespace IEAMicroservice.WebUI.Services.Abstract
{
    public interface ICategoryService
    {
        Task<ResultCategoryDto> GetAllCategories();
        Task<UpdateCategoryDto.Data> GetCategoryById(string id);
        Task CreateCategory(CreateCategoryDto createCategoryDto);
        Task UpdateCategory(UpdateCategoryDto.Data updateCategoryDto);
        Task DeleteCategory(string id);
        
    }
}
