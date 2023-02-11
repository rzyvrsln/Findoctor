using FindoctorEntity.Entities;
using Microsoft.EntityFrameworkCore;

namespace FindoctorData.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Clinic> Clinics { get; set; }

    }
}
