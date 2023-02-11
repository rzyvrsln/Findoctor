using FindoctorData.UnitOfWorks;
using FindoctorEntity.Entities;
using FindoctorViewModel.Entities.CategoryVM;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace FindoctorService.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment environment;

        public CategoryService(IUnitOfWork unitOfWork, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            this.environment = environment;
        }

        public async Task AddCategoryAsync(CreateCategoryVM categoryVM)
        {
            IFormFile file = categoryVM.Image;

            string fileName = Guid.NewGuid().ToString() + file.FileName;
            using var stream = new FileStream(Path.Combine(environment.WebRootPath,"assets","img","category",fileName),FileMode.Create);
            await file.CopyToAsync(stream);
            await stream.FlushAsync();

            Category category = new Category();
            category.Name = categoryVM.Name;
            category.ImageUrl = fileName;
            await _unitOfWork.GetRepository<Category>().AddAsync(category);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task DeleteCategoryAsync(Category category)
        {
            await _unitOfWork.GetRepository<Category>().DeleteAsync(category);
        }

        public async Task<ICollection<Category>> GetCategoryAsync()
        {
            return await _unitOfWork.GetRepository<Category>().GetAllAsync();
        }

        public async Task GetCategoryGuiId(Guid id)
        {
            if (id != null)
            {
                var category = await _unitOfWork.GetRepository<Category>().GetByGuidAsync(id);
                if (category is not null)
                {
                    await _unitOfWork.GetRepository<Category>().DeleteAsync(category);
                }
                await _unitOfWork.SaveChangeAsync();
            }

        }

        public async Task UpdateCategoryAsync(UpdateCategoryVM categoryVM)
        {
            IFormFile file = categoryVM.Image;
            string fileName = Guid.NewGuid().ToString() + file.FileName;

            using var stream = new FileStream(Path.Combine(environment.WebRootPath,"assets","img","category",fileName),FileMode.Create);
            await file.CopyToAsync(stream);
            await stream.FlushAsync();

            Category category = new Category() { Name = categoryVM.Name, ImageUrl = fileName };

            await _unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<UpdateCategoryVM> UpdateCategoryIdAsync(Guid id)
        {
            var category = await _unitOfWork.GetRepository<Category>().GetByGuidAsync(id);

            UpdateCategoryVM categoryVM = new UpdateCategoryVM { Name = category.Name };
            return categoryVM;

        }
    }
}
