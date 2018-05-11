using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using BookCave.Services;
using Microsoft.AspNetCore.Authorization;

namespace BookCave.Controllers
{
    public class CartController : Controller
    {
        private CartService _cartService;
        private CookieOptions _options;
        private IPaymentService _paymentService;
        private IAddressService _addressService;

        public CartController(IPaymentService Payment, IAddressService Address)
        {
            _addressService = Address;
            _paymentService = Payment;
            _cartService = new CartService();
            _options = new CookieOptions();
        }
        public IActionResult Index()
        {
            var Cart = Request.Cookies["Cart"];
            var ListOfWords = _cartService.SplitItems(Cart);
            var CartView = _cartService.CreateView(ListOfWords);
            return View(CartView);
        }

        [Authorize]
        public IActionResult CheckOut(CartViewModel Model)
        {
            var Cart = Request.Cookies["Cart"];
            var ListOfWords = _cartService.SplitItems(Cart);
            var CartView = _cartService.CreateView(ListOfWords);
            Model.Cart = CartView.Cart;
            var CheckoutModel = _cartService.CheckOut(Model);
            return View(CheckoutModel);
        }
        [Authorize]
        public IActionResult CompletePayment(CheckOutViewModel Model, int AddressId, int PaymentId)
        {
            var CompleteOrder = _cartService.CompleteOrder(Model, AddressId, PaymentId);
            var Cart = Request.Cookies["Cart"];
            var ListOfWords = _cartService.SplitItems(Cart);
            var CartView = _cartService.CreateView(ListOfWords);
            CompleteOrder.Cart = CartView;
            return View(CompleteOrder);
        }
        public IActionResult OrderComfirmed(CompleteOrderViewModel Model)
        {
            var Cart = Request.Cookies["Cart"];
            var ListOfWords = _cartService.SplitItems(Cart);
            Model.Cart = _cartService.CreateView(ListOfWords);
            _cartService.AddOrder(Model);
            Response.Cookies.Delete("Cart");
            return RedirectToAction("Index", "Cart");
        }

        [HttpPost]
        public IActionResult AddToCart(int BookId, int Quantity)
        {
            var CartItem = _cartService.AddToCart(BookId, Quantity);
            var Cart = Request.Cookies["Cart"];
            Cart += CartItem;
            Response.Cookies.Append("Cart", Cart, _options);
            _options.Expires = DateTime.Now.AddDays(3);
            return RedirectToAction("Details", "Book", new {id = BookId}) ;
        }
        public IActionResult DeleteFromCart(int CartItemId)
        {  
            var Cart = Request.Cookies["Cart"];
            var CartView = _cartService.SplitItems(Cart);
            CartView.RemoveAt(CartItemId);
            var UpdatedCart = _cartService.CreateString(CartView);
            Response.Cookies.Append("Cart", UpdatedCart, _options);
            return RedirectToAction("Index", "Cart");
        }
    }
} 
