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
        public IActionResult SubCategory(int id)
        {
            var SubCategories = _categoryService.GetSubCategoryIndex(id);
            return View(SubCategories); ///etta er json utaf testi
        }
        
        public IActionResult SingleCat(int id)
        {
            var SingleSubCategory = _categoryService.GetSubCategoryViewModel(id).FirstOrDefault();
            return View(SingleSubCategory);
        }

        public IActionResult Books(int? id)
        {
            var books = _categoryService.GetBookList(id);
            return View(books);
        }

        public IActionResult SearchResults(string Search)
        {
            if (Search != null)
            {
                var Books = _categoryService.SearchBooks(Search);
                return View(Books);
            }
            else
            {
                var Books = _categoryService.GetBookList(null).OrderBy(x => x.Name).ToList();
                return View(Books);
            }
        }


        //Hér fyrir neðan eru föll til að sækja lista í Service

        public JsonResult GetMainCategoryListJson()
        {
            var MainCategories = _categoryService.GetMainCategoryList(null);
            return Json(MainCategories);
        }

    }
}
