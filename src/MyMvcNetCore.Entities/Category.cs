using System.ComponentModel.DataAnnotations;
using MyMvcNetCore.Entities.Base;

namespace MyMvcNetCore.Entities;

public class Category : BaseEntity
{
    #region Fields

    [Required]
    [MaxLength(100)]
    public string Title { get; set; }
    public int? ParentId { get; set; }

    #endregion

    #region Relations

    public virtual Category Parent { get; set; }

    public virtual ICollection<Category> Children { get; set; }

    public virtual ICollection<Product> Products { get; set; }

    #endregion
}
