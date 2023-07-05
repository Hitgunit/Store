using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Store.Models
{
    public class Stock
    {
        [Key]
        public int? Id { get; set; }
        [ForeignKey("ProductDetail")]
        public int? ProductDetailId { get; set; }
        public ProductDetail? ProductDetail { get; set; }
        public string? Size { get; set; }
        public int? Quantity { get; set; }
    }
}
