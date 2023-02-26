using FindoctorData.DAL;
using FindoctorData.UnitOfWorks;
using FindoctorEntity.Entities;
using FindoctorViewModel.Entities.CategoryVM;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace FindoctorService.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IWebHostEnvironment environment;
        private readonly AppDbContext appDbContext;

        public CategoryService(IUnitOfWork unitOfWork, IWebHostEnvironment environment, AppDbContext appDbContext)
        {
            this.unitOfWork = unitOfWork;
            this.environment = environment;
            this.appDbContext = appDbContext;
        }

        public async Task AddCategoryAsync(CreateCategoryVM categoryVM)
        {
            IFormFile? file = categoryVM.Image;
            string fileName = Guid.NewGuid()+ file.FileName;
            using var stream = new FileStream(Path.Combine(environment.WebRootPath, "assets", "img", "category", fileName), FileMode.Create);
            await file.CopyToAsync(stream);
            await stream.FlushAsync();

            Category category = new Category { Name = categoryVM.Name, ImageUrl = fileName };

            await unitOfWork.GetRepository<Category>().AddAsync(category);
            await unitOfWork.SaveChangeAsync();
        }

        public async Task DeleteCategoryAsync(int? id)
        {
            var category = await unitOfWork.GetRepository<Category>().GetByIdAsync(id);
            await unitOfWork.GetRepository<Category>().DeleteAsync(category);

            string filePath = Path.Combine(environment.WebRootPath,"assets","img","category",category.ImageUrl);
            File.Delete(filePath);
            await unitOfWork.SaveChangeAsync();
        }

        public async Task<ICollection<Category>> GetAllCategoryAsync()
        {
            return await unitOfWork.GetRepository<Category>().GetAllAsync();
        }

        public async Task<ICollection<Category>> GetAllIncludeAsync()
        {
            return await appDbContext.Categories.Include(c => c.Doctors).Include(c => c.Clinics).ToListAsync();
        }

        public async Task<UpdateCategoryVM> UpdateCategoryAsync(int? id)
        {
            var categoryOne = await unitOfWork.GetRepository<Category>().GetByIdAsync(id);
            UpdateCategoryVM categoryTwo = new UpdateCategoryVM { Name = categoryOne.Name };
            return categoryTwo;
        }

        public async Task UpdateCategoryPostAsync(int? id, UpdateCategoryVM categoryVM)
        {
            var category = await unitOfWork.GetRepository<Category>().GetByIdAsync(id);

            IFormFile file = categoryVM.Image;
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            using var stream = new FileStream(Path.Combine(environment.WebRootPath,"assets","img","category",fileName),FileMode.Create);
            await file.CopyToAsync(stream);
            await stream.FlushAsync();

            category.Name = categoryVM.Name;
            category.ImageUrl = fileName;
            
            await unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await unitOfWork.SaveChangeAsync();

        }
    }
}
