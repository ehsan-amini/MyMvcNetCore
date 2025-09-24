using System.ComponentModel.DataAnnotations;

namespace MyMvcNetCore.ViewModels.Categories;

public class ShowCategory
{
    public int Id { get; set; }

    [Display(Name = "Title")]
    public string Title { get; set; }

    public bool CanRemove { get; set; }
}
