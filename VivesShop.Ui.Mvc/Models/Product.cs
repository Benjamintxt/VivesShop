using System.ComponentModel;

namespace VivesShop.Ui.Mvc.Models
{
    public class Product
    {
        public int Id { get; set; }
        [DisplayName("Product name")]
        public required string Name { get; set; }
        [DisplayName("Price")]
        public required decimal Price { get; set; }

    }

}
