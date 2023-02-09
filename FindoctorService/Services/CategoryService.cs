using FindoctorData.UnitOfWorks;
using FindoctorEntity.Entities;
using FindoctorEntity.Entities.ViewModels;

namespace FindoctorService.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddCategoryAsync(CategoryVM categoryVM)
        {
            Category category = new Category();
            category.Name = categoryVM.Name;
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
    }
}
