using Microsoft.EntityFrameworkCore;
using System;
using VivesShop.Ui.Mvc.Models;

namespace VivesShop.Ui.Mvc.Core
{
    public class ProductManagerDbContext : DbContext
    {
        public ProductManagerDbContext(DbContextOptions<ProductManagerDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Product => Set<Product>();
        public DbSet<CartProduct> CartProduct => Set<CartProduct>();

        public void Seed()
        {

            Product.AddRange(new List<Product>
            {
                new Product {Name = "Medium friet", Price = 3},
                new Product {Name = "Frikandel", Price = 2},
                new Product {Name = "Cola Zero", Price = 2},
                
            });

            SaveChanges();
        }
    }
}
