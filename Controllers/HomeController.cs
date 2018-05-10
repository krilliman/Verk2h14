using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Services;

namespace BookCave.Controllers
{
    public class HomeController : Controller
    {
        //private BookService _bookService;
        private CategoryService _categoryService;
        private BookService _bookService;

        public HomeController()
        {
            _bookService = new BookService();
            _categoryService = new CategoryService();

        }
        public IActionResult Index(string Search, string FilterByName)
        {
            var IndexView = _categoryService.GetCategoryViewModel(null);
            return View(IndexView);
            //            if(Search != null)
            //            {
            //                var Books = _bookService.GetAllBooks(Search);
            //                return View(Books);
            //            }
            //            else if(FilterByName != null)
            //            {
            //                var Books = _bookService.FilterByName();
            //                return View(Books);  
            //            }
            //            else
            //            {
            //                var Books = _bookService.GetAllBooks();
            //                return View(Books);
        }

        public IActionResult SearchResults(string Search, string FilterByName)
        {
            if (Search != null)
            {
                var Books = _bookService.GetAllBooks(Search);
                return View(Books);
            }
            else if (FilterByName != null)
            {
                var Books = _bookService.FilterByName();
                return View(Books);
            }
            else
            {
                var Books = _bookService.GetAllBooks();
                return View(Books);
            }

            /* 
            public IActionResult FilterByName()
            {
                var Books = _bookService.FilterByName();
                return Json(Books);
            }
            */
        }
    }
}
