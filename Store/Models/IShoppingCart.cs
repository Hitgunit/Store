namespace Store.Models
{
    public interface IShoppingCart
    {
        void AddToCart(ProductDetail product);

        int RemoveFromCart(ProductDetail product);

        List<ShoppingCartItem> GetAll();

        void ClearCart();

        decimal GetCartPrice();

        List<ShoppingCartItem> shoppingCartItems { get; set; }
    }
}
