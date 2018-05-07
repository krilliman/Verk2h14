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
            var AllCategories = GetMainCategoryAndChildLists(id);
            return View(AllCategories);
        }

        public IActionResult SubCategory(int? id)
        {
            var SubCategories = GetSubCategoryList(id);
            return View(SubCategories); ///etta er json utaf testi
        }

        public IActionResult Books(int? id)
        {
            var books = _categoryService.GetBookList(id);
            return View(books);  
        }

// Þessi föll sækja hina og þessa lista
        public List<MainCategoryViewModel> GetMainCategoryAndChildLists(int? id) //
        {
            var MainAndSubCategories = (from m in GetMainCategoryList(id)
                                        select new MainCategoryViewModel
                                        {
                                            ID = m.ID,
                                            Name = m.Name,
                                            SubCategories = GetSubCategoryAndChildList(m.ID),
                                        }).ToList();
            return MainAndSubCategories;
        }

        public  List<SubCategoryViewModel> GetSubCategoryAndChildList(int? id)
        {
            var SubCategoriesAndBooks = (from s in GetSubCategoryList(id)
                                                    select new SubCategoryViewModel
                                                    {
                                                        ID = s.ID,
                                                        Name = s.Name,
                                                        BookList = (GetBookList(s.ID)),
                                                    }).ToList();
            return SubCategoriesAndBooks;
        }

//Hér fyrir neðan eru föll til að sækja lista í Service
        public List<MainCategoryViewModel> GetMainCategoryList(int? id){
            var MainCategories = _categoryService.GetMainCategoryList(id);
            return MainCategories;
        }

        public List<SubCategoryViewModel> GetSubCategoryList(int? id){
            var SubCategories = _categoryService.GetSubCategoryList(id);
            return SubCategories;
        }

        public List<BookViewModel> GetBookList(int? id){
            var BookList = _categoryService.GetBookList(id);
            return BookList;
        }

    }
}
