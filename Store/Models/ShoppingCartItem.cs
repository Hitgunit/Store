using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class ShoppingCartItem
    {

        [Key]
        public int ItemId { get; set; }

        public Product Product { get; set; }

        public int Price { get; set; }

        public string? CartId { get; set; }
        public int Quantity { get; set; }

        public System.DateTime DateCreated { get; set; }

        public int ProductId { get; set; }

    }
}
