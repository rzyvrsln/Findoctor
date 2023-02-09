using FindoctorEntity.Entities;
using FindoctorEntity.Entities.ViewModels;

namespace FindoctorService.Services
{
    public interface ICategoryService
    {
        Task<ICollection<Category>> GetCategoryAsync();
        Task AddCategoryAsync(CategoryVM categoryVM);
        Task GetCategoryGuiId(Guid id);
    }
}
