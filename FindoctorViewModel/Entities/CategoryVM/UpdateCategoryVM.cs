using Microsoft.AspNetCore.Http;

namespace FindoctorViewModel.Entities.CategoryVM
{
    public class UpdateCategoryVM
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
    }
}
