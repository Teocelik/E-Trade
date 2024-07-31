using E_Trade.Extensions;
using E_Trade.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace E_Trade.Controllers
{
    public class CheckOutController : Controller
    {
        public readonly IOptions<StripeSettings> _stripeSettings;

        public CheckOutController(IOptions<StripeSettings> stripeSettings)
        {
            _stripeSettings = stripeSettings;

            StripeConfiguration.ApiKey = _stripeSettings.Value.SecretKey;
        }



        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CheckOut()
        {
            var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart");

            if(cart == null || !cart.Items.Any())
            {
                ViewBag.ErrorMessage = "Sepetiniz şuan boş!";
                return View("EmptyCart");
            }

            var domain = "https://localhost:44367/";

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },

                LineItems = new List<SessionLineItemOptions>(),

                Mode = "payment",

                SuccessUrl = domain + $"CheckOut/OrderConfirmation",
                CancelUrl = domain + $"CheckOut/Login"
            };


            foreach(var item in cart.Items)
            {
                var sessionLineItems = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(item.Product.Price * 100),
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.Product.Title,
                        },

                    },
                    Quantity = item.Quantity
                };
                options.LineItems.Add(sessionLineItems);
            }


            var service = new SessionService();

            Session session = await service.CreateAsync(options);

            HttpContext.Session.SetString("SessionId", session.Id);

            Response.Headers.Add("Location", session.Url);

            return new StatusCodeResult(303);
        }

        public IActionResult OrderConfirmation()
        {
            var sessionId = HttpContext.Session.GetString("SessionId");

            if (string.IsNullOrEmpty(sessionId))
            {
                return View("Login");
            }

            var service = new SessionService();

            var session = service.Get(sessionId);
            
            if (session.PaymentStatus == "paid")
            {
                return View("Success");
            }
            else
            {
                return View("Login");
            }
        }
    }
}
