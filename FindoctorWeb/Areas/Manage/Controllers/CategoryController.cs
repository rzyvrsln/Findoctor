using FindoctorService.Services;
using FindoctorViewModel.Entities.CategoryVM;
using Microsoft.AspNetCore.Mvc;

namespace FindoctorWeb.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService) => _categoryService = categoryService;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoryAsync();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryVM categoryVM)
        {
            await _categoryService.AddCategoryAsync(categoryVM);
            return RedirectToAction(nameof(Index), "Category");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction(nameof(Index), "Category");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            var categories = await _categoryService.UpdateCategoryAsync(id);
            return View(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryVM categoryVM)
        {
            await _categoryService.UpdateCategoryPostAsync(categoryVM);
            return RedirectToAction(nameof(Index), "Category");
        }
    }
}
