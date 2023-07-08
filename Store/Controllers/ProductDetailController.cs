using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductDetailController(ApplicationDbContext context)
        {
           _context = context;
        }
        public IActionResult Index()
        {
            List<ProductDetail> item = _context.ProductDetails.Include(x => x.Product).ToList();
            return View(item);
        }
        public IActionResult Details(int id) 
        { 
            ProductDetail item = _context.ProductDetails.Include(a => a.Product).FirstOrDefault(x => x.Id == id);
            return View(item);
        }
    }
}