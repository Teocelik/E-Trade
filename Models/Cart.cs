using System.Collections.Generic;
using System.Linq;

namespace E_Trade.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddItem(Product product, int quantity)
        {
            var existingItem = Items.FirstOrDefault(i => i.ProductId == product.Id);

            if(existingItem != null)
            {
                existingItem.Quantity += quantity;
            }

            else
            {
                Items.Add(new CartItem
                {
                    Product = product,
                    ProductId = product.Id,
                    Quantity = quantity
                });
            }
        }
    }
}
