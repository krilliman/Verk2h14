using System.Collections.Generic;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class CategoryService
    {

        private CategoryRepo _categoryRepo;

        public CategoryService()
        {
            _categoryRepo = new CategoryRepo();
        }

        public List<MainCategoryViewModel> GetMainCategoryList(int? id)
        {
            var MainCategories = _categoryRepo.GetMainCategoryList(id);
            return MainCategories;
        }

        public List<SubCategoryViewModel> GetSubCategoryList(int? id)
        {
            var SubCategories = _categoryRepo.GetSubCategoryList(id);
            return SubCategories;
        }

        public List<BookViewModel> GetBookList(int? id)
        {
            var books = _categoryRepo.GetAllBooks(id);
            return books;
        }
    }
}