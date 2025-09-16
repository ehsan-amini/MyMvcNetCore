using MyMvcNetCore.Commen.Enums;
using MyMvcNetCore.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MyMvcNetCore.Entities
{
    public class Order : BaseEntity
    {
        #region Fields
        
        public DateTime OrderDate { get; set; }
        public DateTime? ShippingDate { get; set; }
        public decimal OrderTotal { get; set; }     

        public OrderStatus OrderStatus { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        public string? TrackingNumber { get; set; }
        public string? Carrier { get; set; }

        public DateTime? PaymentDate { get; set; }
        public DateTime PaymentDueDate { get; set; }

        public string? SessionId { get; set; }
        public string? PaymentIntentId { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [NotMapped] 
        public string FullName => $"{FirstName} {LastName}";
        #endregion

        #region Relations
    public ICollection<OrderDetail> OrderDetails { get; set; }
            = new List<OrderDetail>();
        #endregion
    }
}