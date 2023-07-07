using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Models
{
    public class ProductDetail
    {
        [Key]
        public int? Id { get; set; }
        [ForeignKey("Product")]
        public int? ProdcutId { get; set; }
        public Product? Product { get; set; }
        public string? Material { get; set; }
        public string? Color { get; set; }
        public double? Price { get; set; }
    }
}
