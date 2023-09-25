using AutoMapper;
using IEAMicroService.Catalog.Dtos.ProductDtos;
using IEAMicroService.Catalog.Models;
using IEAMicroService.Catalog.Settings;
using IEAMicroService.Shared.Dtos;
using MongoDB.Driver;

namespace IEAMicroService.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper , IDataBaseSettings _dataBaseSettings)
        {
            var client = new MongoClient(_dataBaseSettings.ConnectionString);
            var database = client.GetDatabase(_dataBaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_dataBaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_dataBaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<NoContent>> CreateProduct(CreateProductDto createProductDto)
        {
            var values = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(values);
            return Response<NoContent>.Success(204);
        }

    
        public async Task<Response<NoContent>> DeleteProduct(string id)
        {
            await _productCollection.DeleteOneAsync(x=> x.ProductId == id);
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<List<ResultProductDto>>> GetAllProducts()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            return Response<List<ResultProductDto>>.Success(_mapper.Map<List<ResultProductDto>>(values), 200);
        }

        public async Task<Response<ResultProductDto>> GetProductById(string id)
        {
            var values = await _productCollection.Find<Product>(x=> x.ProductId == id).FirstOrDefaultAsync();
            if (values == null)
            {
                return Response<ResultProductDto>.Fail( 404, "Ürün Bulunamadı");
            }
            return Response<ResultProductDto>.Success(_mapper.Map<ResultProductDto>(values),200);
        }

        public async Task<Response<NoContent>> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, values);
            return Response<NoContent>.Success(200);
        }
    }
}
