using System.ComponentModel.DataAnnotations;
using MyMvcNetCore.Entities.Base;
using MyMvcNetCore.Entities.Identity;

namespace MyMvcNetCore.Entities;

public class UserInformation 
{
    #region Fields
    [Key]
    public int UserId { get; set; }
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public string NationalCode { get; set; }
    //
    //Other fields if necessary
    //
    #endregion

    #region Relations

    public ApplicationUser User { get; set; }
 
    #endregion
}


