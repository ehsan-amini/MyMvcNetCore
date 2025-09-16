using System.ComponentModel.DataAnnotations;
using MyMvcNetCore.Entities.Base;

namespace MyMvcNetCore.Entities;

public class ProductImage : BaseEntity
{
    #region Fields

    [Required]
    [MaxLength(50)]
    public string Title { get; set; }
    [Required]
    public string ImageUrl { get; set; }

    public int ProductId { get; set; }

    #endregion

    #region Relations

    public virtual Product Product { get; set; }

    #endregion
}
