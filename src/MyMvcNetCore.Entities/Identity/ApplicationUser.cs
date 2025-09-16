using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MyMvcNetCore.Entities.Identity;

public class ApplicationUser : IdentityUser<int>
{
    #region Fields
    
    public DateTime CreatedDateTime { get; set; }

    [MaxLength(50)]
    public string FirstName { get; set; }

    [MaxLength(50)]
    public string LastName { get; set; }

    [NotMapped]
    public string FullName => $"{FirstName} {LastName}";
    [NotMapped]
    public string Role { get; set; }

    public int? CompanyId { get; set; }

    public string? Country { get; set; }
    public string? Adress { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? PostalCode { get; set; }



    public bool IsActive { get; set; }
    #endregion

    #region Relations
    [ForeignKey("CompanyId")]
    [ValidateNever]public Company? Company { get; set; }
    public UserInformation UserInformation { get; set; }
    public ICollection<Cart> Carts { get; set; } = new List<Cart>();
    //public ICollection<Order> Orders { get; set; } = new List<Order>();



    #endregion
}
