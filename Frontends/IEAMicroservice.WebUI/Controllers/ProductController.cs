using IEAMicroservice.WebUI.Services.Abstract;
using IEAMicroService.WebUI.Dtos.ProductDto;
using Microsoft.AspNetCore.Mvc;

namespace IEAMicroservice.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IProductService productService, IHttpClientFactory httpClientFactory)
        {
            _productService = productService;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _productService.GetAllProducts();
            return View(values.data.ToList());
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProduct(createProductDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProduct(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            var values = await _productService.GetProductById(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto.Data updateProductDto)
        {
            await _productService.UpdateProduct(updateProductDto);
            return RedirectToAction("Index");
        }
    }
}
