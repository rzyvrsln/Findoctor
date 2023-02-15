using FindoctorData.UnitOfWorks;
using FindoctorEntity.Entities;
using FindoctorViewModel.Entities.CategoryVM;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindoctorService.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IWebHostEnvironment environment;

        public CategoryService(IUnitOfWork unitOfWork, IWebHostEnvironment environment)
        {
            this.unitOfWork = unitOfWork;
            this.environment = environment;
        }

        public async Task AddCategoryAsync(CreateCategoryVM categoryVM)
        {
            IFormFile file = categoryVM.Image;
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
            await unitOfWork.SaveChangeAsync();
        }

        public async Task<ICollection<Category>> GetAllCategoryAsync()
        {
            return await unitOfWork.GetRepository<Category>().GetAllAsync();
        }

        public async Task<UpdateCategoryVM> UpdateCategoryAsync(int? id)
        {
            var categoryOne = await unitOfWork.GetRepository<Category>().GetByIdAsync(id);
            UpdateCategoryVM categoryTwo = new UpdateCategoryVM { Name = categoryOne.Name };
            return categoryTwo;
        }

        public async Task UpdateCategoryPostAsync(UpdateCategoryVM categoryVM)
        {
            IFormFile file = categoryVM.Image;
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            using var stream = new FileStream(Path.Combine(environment.WebRootPath,"assets","img","category",fileName),FileMode.Create);
            await file.CopyToAsync(stream);
            await stream.FlushAsync();

            Category category = new Category { Name = categoryVM.Name, ImageUrl = fileName };
            await unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await unitOfWork.SaveChangeAsync();

        }
    }
}
