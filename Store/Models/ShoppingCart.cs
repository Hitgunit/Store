using Microsoft.EntityFrameworkCore;
using Store.Data;

namespace Store.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IProductAppService _productAppService;
        public List<ShoppingCartItem> shoppingCartItems { get; set; } = default!;
        public List<ProductDetail> detallesProducto { get; set; } 
        public string? ShoppingCartId { get; set; }


        public ShoppingCart(ApplicationDbContext applicationDbContext, IProductAppService productAppService)
        {
            _applicationDbContext = applicationDbContext;
            _productAppService = productAppService;
        }
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
            ApplicationDbContext context = services.GetRequiredService<ApplicationDbContext>() ?? throw new Exception("Error Initializing");
            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();
            session?.SetString("CartId", cartId);
            return new ShoppingCart(context) { ShoppingCartId = cartId };

        }


        public async void AddToCart(ProductDetail product)
        {
            var shoppingCartItem =
                 _applicationDbContext.shoppingCartItems.SingleOrDefault(
                     s => s.Product.Id == product.Id && s.CartId == ShoppingCartId);

            var query = (from a in shoppingCartItem
                        join s in _productAppService.GetAll() on a.ProductId equals s.ProductId
                        select new
                        {
                            a.ProductId,
                            a.CartId,
                            a.ShoppingCartId,
                        });

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    CartId = ShoppingCartId,
                    Product = shoppingCartItem.Product,
                    Quantity = 1

                };
            }
            else
            {
                shoppingCartItem.Quantity++;
            }
            _applicationDbContext.shoppingCartItems.Add(shoppingCartItem);
        }

        public void ClearCart()
        {
            var carItems = _applicationDbContext.shoppingCartItems.Where(c =>
                c.CartId == ShoppingCartId);
            _applicationDbContext.shoppingCartItems.RemoveRange(carItems);
            _applicationDbContext.SaveChanges();
        }

        public List<ShoppingCartItem> GetAll()
        {
            return shoppingCartItems ??=
                _applicationDbContext.shoppingCartItems.Where(c =>
                c.CartId == ShoppingCartId).Include(s => s.Product).ToList();
        }

        public decimal GetCartPrice()
        {
            var total = _applicationDbContext.shoppingCartItems.Where(c =>
                c.CartId == ShoppingCartId).Select(c => c.Price * c.Quantity).Sum();
            return total;
        }

        public int RemoveFromCart(ProductDetail product)
        {
            var shoppingCartItem =
              _applicationDbContext.shoppingCartItems.SingleOrDefault(
                  s => s.Product.Id == product.Id && s.CartId == ShoppingCartId);

            var localQuantity = 0;
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Quantity > 1)
                {
                    shoppingCartItem.Quantity--;
                    localQuantity = shoppingCartItem.Quantity;
                }
                else
                {
                    _applicationDbContext.shoppingCartItems.Remove(shoppingCartItem);
                }
            }
            _applicationDbContext.SaveChanges();
            return localQuantity;
        }
    }
}
