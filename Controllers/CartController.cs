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
            var Cart = new CartViewModel();
            var CartList = new List<CartItemViewModel>();
            double CartTotal = 0.0;

            var ListOfWords = SplitItems();
            for(var i = 0; i < ListOfWords.Count();i++)
            {
                var ListOfVars = new List<string>();
                ListOfVars.AddRange(ListOfWords[0].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
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
            return View(Cart);
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
            var ListOfWords = new List<string>();
            ListOfWords.AddRange(Cart.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries));
            return ListOfWords;
        }
    }
} 
