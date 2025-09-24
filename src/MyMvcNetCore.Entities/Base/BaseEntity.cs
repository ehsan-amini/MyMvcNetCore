using System.ComponentModel.DataAnnotations;

namespace MyMvcNetCore.Entities.Base
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
