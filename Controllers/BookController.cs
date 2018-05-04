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

        public BookController()
        {
            _bookService = new BookService();
            _ratingService = new RatingService();
        }
       public IActionResult Details(int id)
       {
           var Book = _bookService.GetBook(id);
           var ratings = _ratingService.GetRatings(id);
           Book.Ratings = ratings;
           return View(Book);
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
