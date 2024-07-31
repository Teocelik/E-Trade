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

        //Id'ye göre ürün silen method.
        public void RemoveId(int productId)
        {
            Items.RemoveAll(i => i.ProductId == productId);
        }

        //Sepetteki toplam tutarı hesaplayan property
        public decimal TotalPrice => Items.Sum(i => i.Product.Price * i.Quantity);

        //Sepetteki toplam ürün miktarını tutar.
        public int TotalItemCount => Items.Sum(i => i.Quantity);
    }
}
