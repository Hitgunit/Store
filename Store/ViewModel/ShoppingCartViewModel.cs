using Store.Models;

namespace Store.ViewModel
{
    public class ShoppingCartViewModel
    {
        public ShoppingCartViewModel(IShoppingCart shoppingCart, decimal cartTotal) 
        {
            ShoppingCart = shoppingCart;
            CartTotal = cartTotal;
        }
        public IShoppingCart ShoppingCart { get; set; }
        public decimal CartTotal { get; set;}

    }
}
