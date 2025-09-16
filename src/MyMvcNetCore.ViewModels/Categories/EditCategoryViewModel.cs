using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using MyMvcNetCore.Commen.Constants;

namespace MyMvcNetCore.ViewModels.Categories;

public class EditCategoryViewModel
{
    [HiddenInput]
    public int Id { get; set; }

    [Display(Name = "Title")]
    [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
    [MaxLength(100, ErrorMessage = AttributesErrorMessages.MaxLengthMessage)]
    public string Title { get; set; }

    [Display(Name = "Maincategoriy")]
    public int? ParentId { get; set; }
}
