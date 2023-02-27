using FindoctorData.DAL;
using FindoctorEntity.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FindoctorWeb.Controllers
{
    public class SearchBarController : Controller
    {
        private readonly AppDbContext dbContext;

        public SearchBarController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> Search(string search)
        {
            if (string.IsNullOrEmpty(search) || string.IsNullOrWhiteSpace(search))
            {
                return View(await dbContext.Doctors.Include(d => d.Category).ToListAsync());
            }

            var doctors = await dbContext.Doctors.Where(d => d.Name.Contains(search) || d.Surname.Contains(search)).Include(d => d.Category).ToListAsync();

            if (doctors.Any()) return View(doctors);

            else return View(await dbContext.Doctors.Include(d => d.Category).ToListAsync());

            return View();
        }

        public async Task<IActionResult> SearchClinic(string search)
        {
            if (string.IsNullOrEmpty(search) || string.IsNullOrWhiteSpace(search))
            {
                return View(await dbContext.Clinics.Include(d => d.Category).ToListAsync());
            }

            var clinics = await dbContext.Clinics.Where(d => d.Name.Contains(search) || d.Description.Contains(search) || d.Location.Contains(search)).Include(d => d.Category).ToListAsync();

            if (clinics.Any()) return View(clinics);

            else return View(await dbContext.Clinics.Include(d => d.Category).ToListAsync());

            return View();
        }

    }
}
