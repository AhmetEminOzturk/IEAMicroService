using IEAMicroservice.WebUI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using IEAMicroService.WebUI.Dtos.CategoryDto;

namespace IEAMicroservice.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(ICategoryService categoryService, IHttpClientFactory httpClientFactory)
        {
            _categoryService = categoryService;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _categoryService.GetAllCategories();
            return View(values.data.ToList());
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategory(createCategoryDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategory(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            var values = await _categoryService.GetCategoryById(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto.Data updateCategoryDto)
        {
            await _categoryService.UpdateCategory(updateCategoryDto);
            return RedirectToAction("Index");
        }
    }
}
