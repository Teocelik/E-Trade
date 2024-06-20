using E_Trade.Extensions;
using E_Trade.Models;
using E_Trade.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace E_Trade.Services.Concrete
{
    public class CartService : ICartService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;

        public CartService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _session = httpContextAccessor.HttpContext.Session;
        }

        public void AddToCart(Product product, int quantity)
        {
            var cart = GetCart();

            cart.AddItem(product, quantity);

            _session.SetObjectAsJson("Cart", cart);
        }

        public void ClearCart()
        {
            throw new System.NotImplementedException();
        }

        public Cart GetCart()
        {
            var cart = _session.GetObjectFromJson<Cart>("Cart") ?? new Cart();
            return cart;
        }

        public void RemoveFromCart(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
