using System.ComponentModel.DataAnnotations;
using MyMvcNetCore.Entities;

namespace MyMvcNetCore.ViewModels.Categories;

public class RootCategoryWithProductsViewModel
{
    public int CategoryId { get; set; }
    public string Title { get; set; }
    public List<Product> Products { get; set; }
}
