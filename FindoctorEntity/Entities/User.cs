using Microsoft.AspNetCore.Identity;

namespace FindoctorEntity.Entities
{
    public class User: IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsParsistance { get; set; }
    }
}
