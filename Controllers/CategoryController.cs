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

        [HttpGet]
        public IActionResult Index()
        {
            var Categories = _categoryService.GetAllCategoriesList();
            return View(Categories);
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
        public IActionResult AllCategories()
        {
            var MainCategoriesList = _categoryService.GetAllCategories();
            return Json(MainCategoriesList);
        
        }

        public IActionResult AllCategoriesList()
        {
            var CategoriesList = _categoryService.GetAllCategoriesList();
            return Json(CategoriesList);
        }

    }
}
