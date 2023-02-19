using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FindoctorEntity.Entities
{
    public class User: IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public bool IsParsistance { get; set; }
    }
}
