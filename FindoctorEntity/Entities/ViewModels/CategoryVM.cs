

using Microsoft.AspNetCore.Http;

namespace FindoctorEntity.Entities.ViewModels
{
    public class CategoryVM
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
    }
}
