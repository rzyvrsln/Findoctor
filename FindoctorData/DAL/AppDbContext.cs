using FindoctorEntity.Entities;
using Microsoft.EntityFrameworkCore;

namespace FindoctorData.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Doctor> Doctors { get; set; }
    }
}
