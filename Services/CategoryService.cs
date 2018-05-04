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

        public List<CategoryViewModel> GetAllCategories()
        {
            var Categories = _categoryRepo.AllCategorys();
            return Categories;
        }

        public List<SubCategoryViewModel> GetAllSubCategoires(int id)
        {
            var SubCategories = _categoryRepo.GetAllSubCategory(id);
            return SubCategories;
        }

        public List<BookViewModel> GetAllBooks(int id)
        {
            var books = _categoryRepo.GetAllBooks(id);
            return books;
        }

      
    }
}