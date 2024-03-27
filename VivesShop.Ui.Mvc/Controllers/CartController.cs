using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VivesShop.Ui.Mvc.Core;
using VivesShop.Ui.Mvc.Models;

namespace VivesShop.Ui.Mvc.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductManagerDbContext _productManagerDbContext;
        public CartController(ProductManagerDbContext productManagerDbContext)
        {
            _productManagerDbContext = productManagerDbContext;
        }
        
        [HttpPost]
        public IActionResult Create(int productId)
        {
            var product = _productManagerDbContext.Product.FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                return NotFound();
            }

            var cartProduct = new CartProduct
            {
                Name = product.Name,
                Price = product.Price,
            };

            _productManagerDbContext.CartProduct.Add(cartProduct);
            _productManagerDbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public IActionResult DeleteConfirmed(int productId)
        {
            var dbCartProduct = _productManagerDbContext.CartProduct
                .FirstOrDefault(p => p.Id == productId);

            if (dbCartProduct == null)
            {
                return RedirectToAction("Index", "Home");
            }

            _productManagerDbContext.CartProduct.Remove(dbCartProduct);

            _productManagerDbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
