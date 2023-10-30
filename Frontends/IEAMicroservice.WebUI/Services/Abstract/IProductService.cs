using IEAMicroService.Shared.Dtos;
using IEAMicroService.WebUI.Dtos.ProductDto;

namespace IEAMicroservice.WebUI.Services.Abstract
{
    public interface IProductService
    {
        Task<ResultProductDto> GetAllProducts();
        Task<UpdateProductDto.Data> GetProductById(string id);
        Task CreateProduct(CreateProductDto createProductDto);
        Task UpdateProduct(UpdateProductDto.Data updateProductDto);
        Task DeleteProduct(string id);
    }
}
