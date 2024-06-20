using E_Trade.Models;

namespace E_Trade.Services.Interfaces
{
    public interface ICartService
    {
        //Tüm Sepeti getir
        Cart GetCart();
        //Sepete ürün ekle
        void AddToCart(Product product, int quantity);
        //sepetten ürün sil
        void RemoveFromCart(int productId);
        //Tüm sepeti temizle
        void ClearCart();
    }
}
