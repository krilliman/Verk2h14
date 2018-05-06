using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Services;
using BookCave.Models.ViewModels;

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
            AllCategoriesViewModel Categories = AllCategoriesList();
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
            var mainCategoriesList = _categoryService.GetAllCategories();
            return Json(mainCategoriesList);
        
        }

        public AllCategoriesViewModel AllCategoriesList()
        {
            AllCategoriesViewModel everything = new AllCategoriesViewModel();
            everything.MainCategories = _categoryService.GetAllCategories();
            everything.SubCategories = _categoryService.GetAllSubCategoriesList();
            everything.Books = _categoryService.GetAllBooksList();
            return everything;
        }

    }
}
