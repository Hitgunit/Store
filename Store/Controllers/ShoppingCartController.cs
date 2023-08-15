using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.Models;
using Store.ViewModel;

namespace Store.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartController(IShoppingCart shoppingCart, ApplicationDbContext applicationDbContext)
        {
            _shoppingCart = shoppingCart;
            _applicationDbContext = applicationDbContext;
        }

        public ViewResult Index()
        {
           var items = _shoppingCart.GetAll();
            _shoppingCart.shoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart,
                _shoppingCart.GetCartPrice());
            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToCart(int id)
        {
            var productoSeleccionado = _applicationDbContext.ProductDetails.FirstOrDefault(p => p.Id == id);
            if(productoSeleccionado != null)
            {
                _shoppingCart.AddToCart(productoSeleccionado);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromCart(int id)
        {
            var productoSeleccionado = _applicationDbContext.ProductDetails.FirstOrDefault(p => p.Id == id);
            if (productoSeleccionado != null)
            {
                _shoppingCart.RemoveFromCart(productoSeleccionado);
            }
            return RedirectToAction("Index");
        }
    }
}
