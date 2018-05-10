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
        public IActionResult Index(string search)
        {
            if(search == null)
            {
                var Books = _categoryService.GetCategoryViewModel(null);
                return View(Books);
            }
            else
            {
                //var Books = _bookService.GetAllBooks(search);
                var Books = _categoryService.GetBookSearch(search);
                return View(Books);    
            }
        }
    }
}
