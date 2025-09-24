using System.ComponentModel.DataAnnotations;
using MyMvcNetCore.Entities.Base;
using MyMvcNetCore.Entities.Identity;

namespace MyMvcNetCore.Entities
{
    public class Company:BaseEntity
    {
      

        [Required]
        public string Name { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? PhoneNumber { get; set; }


        public ICollection<ApplicationUser> ApplicationUsers { get; set; } = new List<ApplicationUser>();
    }
}
