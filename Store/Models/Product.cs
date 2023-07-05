using Store.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? Brand { get; set; }
        public ProductType ProductType { get; set; }
        public Gender Gender { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }

    }
}
