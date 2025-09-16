
using System.ComponentModel.DataAnnotations;
using MyMvcNetCore.Entities;
using MyMvcNetCore.Entities.Base;

namespace MyMvcNetCore.Entities;

public class ProductTag : BaseEntity
{
    #region Fields

    [Required]
    [MaxLength(100)]
    public string Title { get; set; }

    #endregion

    #region Relations

    //public ICollection<Product> Products { get; set; }
    public ICollection<ProductProductTag> ProductProductTags { get; set; }

    #endregion
}
