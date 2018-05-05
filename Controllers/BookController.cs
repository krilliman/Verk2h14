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
       public IActionResult Details(int id)
       {
           var Book = _bookService.GetBook(id);
           var ratings = _ratingService.GetRatings(id);
           Book.Ratings = ratings;
           return View(Book);
       }

        [HttpPost]
        public IActionResult AddToWishList(int BookId, int WishListId)
        {
            var WishListItem = new WishListItem()
            {
                BookId = BookId,
                WishListId = WishListId
            };
            _wishListService.AddToWishList(WishListItem);
            return RedirectToAction("Details", "Book", new { id = BookId });
        }



       [HttpPost]
        //This is called when somebody submits a rating for a book.
       public IActionResult SaveRate(RateViewModel Model)
       {
           var NewRate = new Rating
           {
               BookId = Model.BookId,
               Comment = Model.Comment,
               Rate = Model.Rate,
               UserId = 0
           };
           var Book = _bookService.GetBook(Model.BookId);
           //Sends the request to the RatingService
           _ratingService.SaveRate(NewRate);
           return RedirectToAction("Details", "Book", new { id = Book.Id });
       }
    }
}
