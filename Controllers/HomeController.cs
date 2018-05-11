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

        public HomeController()
        {
            _categoryService = new CategoryService();
        }
        public IActionResult Index()
        {
            var IndexView = _categoryService.GetCategoryViewModel(null);
            return View(IndexView);
        }
    }
}
