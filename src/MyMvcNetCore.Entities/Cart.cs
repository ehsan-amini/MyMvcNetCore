using MyMvcNetCore.Entities.Base;
using MyMvcNetCore.Entities.Identity;
namespace MyMvcNetCore.Entities
{
    public class Cart
    {
        #region Fields
      
       public int ProductId { get; set; }
       public int UserId { get; set; }
        public int Quantity { get; set; }

        

        #endregion

        #region Relations

        public ApplicationUser User { get; set; }
        public Product Product { get; set; }
     

        #endregion
    }
}
