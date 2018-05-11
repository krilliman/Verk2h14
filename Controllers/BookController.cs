using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Models.ViewModels;
using BookCave.Services;
using BookCave.Models.EntityModels;

namespace BookCave.Controllers
{
    public class BookController : Controller
    {
        private BookService _bookService;
        private RatingService _ratingService;
        private WishListService _wishListService;

        public BookController()
        {
            _bookService = new BookService();
            _ratingService = new RatingService();
            _wishListService = new WishListService();
        }
       public IActionResult Details(int id, int userid)
       {
           var Book = _bookService.GetBook(id);
           var ratings = _ratingService.GetRatings(id);
           if(ratings == null)
           {

           }
           else
           {
               Book.Ratings = ratings; 
           }
           Book.WishListToggle = _bookService.CheckIfInWishList(userid,id);
           return View(Book);
       }

        public IActionResult AddToWishList(int BookId, int WishListId)
        {
            var WishListItem = new WishListItem()
            {
                BookId = BookId,
                UserId = WishListId
            };
            _bookService.AddToWishList(WishListItem);

            return RedirectToAction("Details", "Book", new { id = BookId, userid = WishListId});
        }

       [HttpPost]
        //This is called when somebody submits a rating for a book.
       public IActionResult SaveRate(RateViewModel Model)
       {
           Console.WriteLine("This is the userId: " + Model.UserId);
           var NewRate = new Rating
           {
               BookId = Model.BookId,
               Comment = Model.Comment,
               Rate = Model.Rate,
               UserId = Model.UserId
           };
           var Book = _bookService.GetBook(Model.BookId);
           //Sends the request to the RatingService
           _ratingService.SaveRate(NewRate);
           var ratings = _ratingService.GetRatings(Model.BookId);
           _bookService.UpdateRating(ratings);
           return RedirectToAction("Details", "Book", new { id = Book.ID });
       }
    }
}