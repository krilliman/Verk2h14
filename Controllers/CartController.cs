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
            var Test = Request.Cookies["Cart"];
            var ListOfWords = new List<string>();
            var Cart = new CartViewModel();
            var CartList = new List<CartItemViewModel>();
            double CartTotal = 0.0;

            ListOfWords.AddRange(Test.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries));
            foreach (var item in ListOfWords)
            {   
                Console.WriteLine(item);
            }
            foreach(var item in ListOfWords)
            {
                var ListOfVars = new List<string>();
                ListOfVars.AddRange(item.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
                var CartItem = new CartItemViewModel()
                {
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
            var Test = Request.Cookies["Cart"];
            Test += CartItem;
            Response.Cookies.Append("Cart", Test, _options);
            _options.Expires = DateTime.Now.AddDays(3);
            /* 
            var GetLength = Request.Cookies["Cart"].Count();
            if(GetLength == 0)
            {

            }
            */
            return RedirectToAction("Index", "Cart");
        }
    }
} 
