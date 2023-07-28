using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class ShoppingCartItem
    {

        [Key]
        public int IdItem { get; set; }

        public Product Product { get; set; }

        public int Price { get; set; }

        public string? CartId { get; set; }

    }
}
