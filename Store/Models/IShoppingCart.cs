namespace Store.Models
{
    public interface IShoppingCart
    {
        void AddToCart(Product product);

        int RemoveFromCart(Product product);

        List<Product> GetAll();

        void ClearCart();

        decimal GetCartPrice();

        List<ShoppingCartItem> shoppingCartItems { get; set; }
    }
}
