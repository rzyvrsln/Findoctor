using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FindoctorEntity.Entities
{
    public class User: IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ComfirmPassword { get; set; }
        public string Phone { get; set; }
        public bool IsParsistance { get; set; }
    }
}
