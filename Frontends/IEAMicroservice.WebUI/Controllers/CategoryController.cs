using IEAMicroservice.WebUI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace IEAMicroservice.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _categoryService.GetAllCategories();
            return View(values.data.ToList());
        }
    }
}
