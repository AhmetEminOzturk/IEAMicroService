using IEAMicroService.Catalog.Dtos.ProductDtos;
using IEAMicroService.Shared.Dtos;

namespace IEAMicroService.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<Response<List<ResultProductDto>>> GetAllProducts();
        Task<Response<ResultProductDto>> GetProductById(string id);
        Task<Response<NoContent>> CreateProduct(CreateProductDto createProductDto);
        Task<Response<NoContent>> UpdateProduct(UpdateProductDto updateProductDto);
        Task<Response<NoContent>> DeleteProduct(string id);
    }
}
