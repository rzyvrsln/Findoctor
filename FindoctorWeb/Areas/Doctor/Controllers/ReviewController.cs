using FindoctorData.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FindoctorWeb.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    [Authorize(Roles = "Doctor")]
    public class ReviewController : Controller
    {
        private readonly AppDbContext dbContext;

        public ReviewController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var doctor = await dbContext.Doctors.FirstOrDefaultAsync(d => d.UserId == userid);
            var doctorReviews = await dbContext.Reviews.Where(r => r.DoctorId == doctor.Id).ToListAsync();
            return View(doctorReviews);
        }
    }
}
