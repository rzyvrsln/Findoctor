using FindoctorData.DAL;
using FindoctorEntity.Entities;
using FindoctorViewModel.Entities.DoctorReviewCombined;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FindoctorWeb.Controllers
{
    public class ReviewController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment environment;

        public ReviewController(AppDbContext appDbContext, IWebHostEnvironment environment)
        {
            _appDbContext = appDbContext;
            this.environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Review(int? id)
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);
            if (userName is null) return RedirectToAction("UserLogin", "Account");
            var doctor = await _appDbContext.Doctors.FirstOrDefaultAsync(d => d.Id == id);
            if (doctor is not null)
            {
                DoctorReviewVM doctorReview = new DoctorReviewVM
                {
                    Doctor = doctor
                };
                return View(doctorReview);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Review(int? id, DoctorReviewVM doctorReview)
        {
            var doctor = await _appDbContext.Doctors.FirstOrDefaultAsync(d => d.Id == id);
            if(doctor is not null)
            {
                IFormFile file = doctorReview.CreateReviewVM.Image;
                string fileName = Guid.NewGuid().ToString() + file.FileName;
                using var stream = new FileStream(Path.Combine(environment.WebRootPath, "assets", "img", "reviewForUser", fileName), FileMode.Create);
                await file.CopyToAsync(stream);
                await stream.FlushAsync();

                Review review = new Review
                {
                    Name = doctorReview.CreateReviewVM.Name,
                    Description = doctorReview.CreateReviewVM.Description,
                    Accept = doctorReview.CreateReviewVM.Access,
                    DoctorId = doctor.Id,
                    ImageUrl = fileName
                };
                await _appDbContext.Reviews.AddAsync(review);
                await _appDbContext.SaveChangesAsync();

                return RedirectToAction("Review", "Detail");

            }
            return View();
        }
    }
}
