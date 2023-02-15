using Microsoft.AspNetCore.Http;

namespace FindoctorViewModel.Entities.CategoryVM
{
    public class CreateCategoryVM
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
    }
}
