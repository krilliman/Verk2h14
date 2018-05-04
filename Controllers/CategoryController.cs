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
    public class CategoryController : Controller
    {
        private CategoryService _categoryService;

        public CategoryController()
        {
            _categoryService = new CategoryService();
        }
        public IActionResult Index()
        {
            var Categorys = _categoryService.GetAllCategories();
            return View(Categorys);
        }
        
        public IActionResult SubCategories(int id)
        {
            var subCategory = _categoryService.GetAllSubCategories(id);
            return View(subCategory);
        }
        
        public IActionResult AllInSubCategory(int id)
        {
            var books = _categoryService.GetAllBooks(id);
            return View(books);  
        }
        
    }
}
