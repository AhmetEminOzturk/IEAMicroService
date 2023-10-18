using IEAMicroservice.WebUI.Services.Abstract;
using IEAMicroService.Shared.Dtos;
using IEAMicroService.WebUI.Dtos.ProductDto;

namespace IEAMicroservice.WebUI.Services.Concrete
{
    public class ProductService : IProductService
    {
        
        public Task<Response<NoContent>> CreateProduct(CreateProductDto createProductDto)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoContent>> DeleteProduct(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<ResultProductDto>>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<Response<ResultProductDto>> GetProductById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoContent>> UpdateProduct(UpdateProductDto updateProductDto)
        {
            throw new NotImplementedException();
        }
    }
}
