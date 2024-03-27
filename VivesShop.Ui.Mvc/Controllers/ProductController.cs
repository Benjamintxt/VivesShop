using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using VivesShop.Ui.Mvc.Core;
using VivesShop.Ui.Mvc.Models;

namespace VivesShop.Ui.Mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductManagerDbContext _productManagerDbContext;
        public ProductController(ProductManagerDbContext productManagerDbContext)
        {
            _productManagerDbContext = productManagerDbContext;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var products = _productManagerDbContext.Product.ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _productManagerDbContext.Product.Add(product);
            _productManagerDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _productManagerDbContext.Product
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return RedirectToAction("Index");
            }

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id, [FromForm] Product product)
        {
            var dbProduct = _productManagerDbContext.Product
                .FirstOrDefault(p => p.Id == id);

            if (dbProduct == null)
            {
                return RedirectToAction("Index");
            }

            //Mapping
            dbProduct.Name = product.Name;
            dbProduct.Price = product.Price;

            _productManagerDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _productManagerDbContext.Product
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return RedirectToAction("Index");
            }

            return View(product);
        }

        [HttpPost("[controller]/Delete/{id:int}")]
        public IActionResult DeleteConfirmed([FromRoute] int id)
        {
            var dbProduct = _productManagerDbContext.Product
                .FirstOrDefault(p => p.Id == id);

            if (dbProduct == null)
            {
                return RedirectToAction("Index");
            }

            _productManagerDbContext.Product.Remove(dbProduct);

            _productManagerDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}