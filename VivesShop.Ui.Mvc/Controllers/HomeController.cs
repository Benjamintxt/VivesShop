using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VivesShop.Ui.Mvc.Core;
using VivesShop.Ui.Mvc.Models;

namespace VivesShop.Ui.Mvc.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ProductManagerDbContext _productManagerDbContext;
        public HomeController(ProductManagerDbContext productManagerDbContext)
        {
            _productManagerDbContext = productManagerDbContext;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var products = _productManagerDbContext.Product.ToList();
            var cartProducts = _productManagerDbContext.CartProduct.ToList();
            var combinedModel = new Tuple<List<Product>, List<CartProduct>>(products, cartProducts);
            return View(combinedModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Checkout()
        {
            var cartProducts = _productManagerDbContext.CartProduct.ToList();
            return View(cartProducts);
        }

        public IActionResult SuccessfulPayment()
        {
            var cartProducts = _productManagerDbContext.CartProduct.ToList();
            return View(cartProducts);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
