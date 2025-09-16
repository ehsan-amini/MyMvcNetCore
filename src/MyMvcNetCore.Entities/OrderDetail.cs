using MyMvcNetCore.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMvcNetCore.Entities
{
    public class OrderDetail
    {



        #region Fields

        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }

        #endregion

        #region Relations

        public Product Product { get; set; }
        public Order Order { get; set; }

        #endregion
   }
}


