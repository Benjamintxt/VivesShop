
using System.ComponentModel;

namespace VivesShop.Ui.Mvc.Models
{
    public class CartProduct
    {
        public int Id { get; set; }
        [DisplayName("Product name")]
        public required string Name { get; set; }
        [DisplayName("Price")]
        public required float Price { get; set; }

    }
}
