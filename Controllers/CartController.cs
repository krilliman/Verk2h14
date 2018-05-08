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

        public CartController()
        {
            _cartService = new CartService();
            _options = new CookieOptions();
        }
        public IActionResult Index()
        {
            var ListOfWords = SplitItems();
            var Cart = CreateView(ListOfWords);
            return View(Cart);
        }

        [Authorize]
        public IActionResult CheckOut(CartViewModel Model)
        {
            var ListOfWords = SplitItems();
            var Cart = CreateView(ListOfWords);
            Model.Cart = Cart.Cart;
            var CheckoutModel = _cartService.CheckOut(Model);
            return View(CheckoutModel);
        }
        [Authorize]
        public IActionResult CompletePayment(CheckOutViewModel Model, int AddressId, int PaymentId)
        {
            var CompleteOrder = new CompleteOrderViewModel();
            if(PaymentId != 0 && AddressId != 0)
            {
                var Payment = _cartService.GetPaymentById(PaymentId);
                var Address = _cartService.GetAddressById(AddressId);
                CompleteOrder.UserAddress = Address;
                CompleteOrder.UserPayment = Payment;
            }
            else if(PaymentId != 0 && AddressId == 0)
            {
                var Payment = _cartService.GetPaymentById(PaymentId);
                var Address = new AddressViewModel()
                {
                    StreetLine = Model.UserAddresses.NewAddress.StreetLine,
                    PostalCode = Model.UserAddresses.NewAddress.PostalCode,
                    Country = Model.UserAddresses.NewAddress.Country
                };

                CompleteOrder.UserAddress = Address;
                CompleteOrder.UserPayment = Payment;
            }
            else if(PaymentId == 0 && AddressId != 0)
            {
                var Address = _cartService.GetAddressById(AddressId);
                var Payment = new PaymentInfoViewModel()
                {
                    CardHolder = Model.UserPayments.NewPayment.CardHolder,
                    CardNumber = Model.UserPayments.NewPayment.CardNumber,
                    ExpireMonth = Model.UserPayments.NewPayment.ExpireMonth,
                    ExpireYear = Model.UserPayments.NewPayment.ExpireYear
                };
                CompleteOrder.UserAddress = Address;
                CompleteOrder.UserPayment = Payment;
            }
            else
            {
                var Address = new AddressViewModel()
                {
                    StreetLine = Model.UserAddresses.NewAddress.StreetLine,
                    PostalCode = Model.UserAddresses.NewAddress.PostalCode,
                    Country = Model.UserAddresses.NewAddress.Country
                };
                var Payment = new PaymentInfoViewModel()
                {
                    CardHolder = Model.UserPayments.NewPayment.CardHolder,
                    CardNumber = Model.UserPayments.NewPayment.CardNumber,
                    ExpireMonth = Model.UserPayments.NewPayment.ExpireMonth,
                    ExpireYear = Model.UserPayments.NewPayment.ExpireYear
                };
                CompleteOrder.UserAddress = Address;
                CompleteOrder.UserPayment = Payment;
            }
            var ListOfWords = SplitItems();
            var Cart = CreateView(ListOfWords);
            CompleteOrder.Cart = Cart;
            return View(CompleteOrder);
        }
        public IActionResult OrderComfirmed(CompleteOrderViewModel Model)
        {
            
            var ListOfWords = SplitItems();
            Model.Cart = CreateView(ListOfWords);
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
            var Cart = SplitItems();
            Cart.RemoveAt(CartItemId);
            var UpdatedCart = _cartService.CreateString(Cart);
            Response.Cookies.Append("Cart", UpdatedCart, _options);
            return RedirectToAction("Index", "Cart");
        }

        public List<string> SplitItems()
        {
            var Cart = Request.Cookies["Cart"];
            Console.WriteLine("Cart: "+ Cart);
            var ListOfWords = new List<string>();
            if(Cart != null )
            {
                ListOfWords.AddRange(Cart.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries));
            }
            return ListOfWords;
        }
        public CartViewModel CreateView(List<string> ItemList)
        {
            var Cart = new CartViewModel();
            var CartList = new List<CartItemViewModel>();
            double CartTotal = 0.0;
            for(var i = 0; i < ItemList.Count();i++)
            {
                var ListOfVars = new List<string>();
                ListOfVars.AddRange(ItemList[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
                var CartItem = new CartItemViewModel()
                {
                    Id = i+1,
                    BookId = Int32.Parse(ListOfVars[0]),
                    Price = Double.Parse(ListOfVars[1]),
                    Quantity = Int32.Parse(ListOfVars[2]),
                    TotalPrice = Double.Parse(ListOfVars[3])
                };
                CartList.Add(CartItem);
                CartTotal += CartItem.TotalPrice;
            }
            Cart.Cart = CartList;
            Cart.CartTotalPrice = CartTotal;
            return Cart;
        }
    }
} 
