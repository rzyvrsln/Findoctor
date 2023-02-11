using FindoctorEntity.Entities;
using FindoctorService.Extensions;
using FindoctorService.Services;
using FindoctorViewModel.Entities.CategoryVM;
using FluentValidation;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace FindoctorWeb.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IValidator<Category> categoryValidator;

        public CategoryController(ICategoryService categoryService, IValidator<Category> categoryValidator)
        {
            this.categoryService = categoryService;
            this.categoryValidator = categoryValidator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await categoryService.GetCategoryAsync();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryVM categoryVM)
        {

            //Category category = new Category { Name = categoryVM.Name };
            //var result = await categoryValidator.ValidateAsync(category);
            //if (!result.IsValid) { result.AddToModelState(this.ModelState); return View(); }
            if (!ModelState.IsValid) return View();
            await categoryService.AddCategoryAsync(categoryVM); 

            return RedirectToAction(nameof(Index), "Category");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Category guid)
        {
            Guid guiid = guid.Id;
            if (guiid != null) await categoryService.GetCategoryGuiId(guiid);
            return RedirectToAction(nameof(Index), "Category");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Category guid)
        {
            var category = await categoryService.UpdateCategoryIdAsync(guid.Id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryVM categoryVM)
        {
            await categoryService.UpdateCategoryAsync(categoryVM);
            return RedirectToAction(nameof(Index), "Category");
        }

    }
}
