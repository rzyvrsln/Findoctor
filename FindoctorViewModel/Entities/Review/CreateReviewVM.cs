using Microsoft.AspNetCore.Http;

namespace FindoctorViewModel.Entities.Review
{
    public class CreateReviewVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Access { get; set; }
        public IFormFile Image { get; set; }
    }
}
