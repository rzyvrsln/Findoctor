using FindoctorEntity.Entities;
using FindoctorViewModel.Entities.CategoryVM;

namespace FindoctorService.Services
{
    public interface ICategoryService
    {
        Task<ICollection<Category>> GetCategoryAsync();
        Task AddCategoryAsync(CreateCategoryVM categoryVM);
        Task GetCategoryGuiId(Guid id);
        Task<UpdateCategoryVM> UpdateCategoryIdAsync(Guid id);
        Task UpdateCategoryAsync(UpdateCategoryVM categoryVM);
    }
}
