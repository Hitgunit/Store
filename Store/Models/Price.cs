using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Models
{
    public class Price
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
        public double? Prices { get; set; }
        public DateTime? StartDate { get; set; }
        public  DateTime? FinishDate { get; set; }

    }
}
