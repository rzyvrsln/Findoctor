using FindoctorEntity.Entities;
using FindoctorViewModel.Entities.CategoryVM;

namespace FindoctorService.Services
{
    public interface ICategoryService
    {
        Task<ICollection<Category>> GetAllCategoryAsync();
        Task<ICollection<Category>> GetAllIncludeAsync();
        Task AddCategoryAsync(CreateCategoryVM categoryVM);
        Task DeleteCategoryAsync(int? id);
        Task<UpdateCategoryVM> UpdateCategoryAsync(int? id);
        Task UpdateCategoryPostAsync(int? id, UpdateCategoryVM categoryVM);
    }
}
