using E_Trade.Models;
using E_Trade.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Trade.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;

        public CartController(IProductService productService, ICartService cartService)
        {
            _productService = productService;
            _cartService = cartService;
        }


        public IActionResult Index()
        {
            var cart = _cartService.GetCart();
            return View(cart);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            var product = _productService.Details(productId);

            if(product != null)
            {
                _cartService.AddToCart(product, quantity);
            }
            return RedirectToAction("Index");
        }
    }
}
