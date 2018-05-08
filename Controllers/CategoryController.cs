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
        public IActionResult Index(int? id)
        {
            var AllCategories = _categoryService.GetMainCategoryAndChildLists(null);
            return View(AllCategories);
        }

        public IActionResult SubCategory(int? id)
        {
            var SubCategories = _categoryService.GetSubCategoryAndChildList(id);
            return View(SubCategories); ///etta er json utaf testi
        }

        public IActionResult Books(int? id)
        {
            var books = _categoryService.GetBookList(id);
            return View(books);  
        }


//Hér fyrir neðan eru föll til að sækja lista í Service

        public JsonResult GetMainCategoryListJson(){
            var MainCategories = _categoryService.GetMainCategoryList(null);
            return Json(MainCategories);
        }

    }
}
