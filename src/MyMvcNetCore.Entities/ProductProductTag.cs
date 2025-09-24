using System.ComponentModel.DataAnnotations.Schema;
using MyMvcNetCore.Entities.Base;

namespace MyMvcNetCore.Entities;

[Table("ProductsProductTags")]
public class ProductProductTag
{
    #region Fields

    public int ProductId { get; set; }
    public int ProductTagId { get; set; }

    #endregion

    #region Relations

    public Product Product { get; set; }
    public ProductTag ProductTag { get; set; }

    #endregion
}
