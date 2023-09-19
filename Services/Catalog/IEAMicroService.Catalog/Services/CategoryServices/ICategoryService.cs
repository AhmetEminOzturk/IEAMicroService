using IEAMicroService.Catalog.Dtos.CategoryDtos;
using IEAMicroService.Shared.Dtos;

namespace IEAMicroService.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<Response<List<ResultCategoryDto>>> GetAllCategories();
        Task<Response<ResultCategoryDto>> GetCategoryById(string id);
        Task<Response<NoContent>>CreateCategory(CreateCategoryDto createCategoryDto);
        Task<Response<NoContent>>UpdateCategory(UpdateCategoryDto updateCategoryDto);
        Task<Response<NoContent>>DeleteCategory(string id);
    }
}
