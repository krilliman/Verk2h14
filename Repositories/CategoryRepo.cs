using System;
using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models.ViewModels;
using BookCave.Models.EntityModels;

namespace BookCave.Repositories
{
    public class CategoryRepo
    {
        private DataContext _db;

        public CategoryRepo()
        {
            _db = new DataContext();
        }

        public List<CategoryViewModel> AllCategorys()
        {
            var Categories = (from cg in _db.CategoryTable
                            select new CategoryViewModel
                            {
                                Id = cg.Id,
                                Name = cg.Name
                            }).ToList();
            return Categories;
        }

        public List<SubCategoryViewModel> GetAllSubCategory(int id)
        {
            var SubCategorys = (from sc in _db.SubCategoryTable
                                where sc.CategoryId == id
                                select new SubCategoryViewModel
                                {
                                    Id = sc.Id,
                                    Name = sc.Name
                                }).ToList();
            return SubCategorys;
        }

        public List<BookViewModel> GetAllBooks(int id)
        {
            Console.WriteLine("entering get all books");
            var books = (from Bk in _db.BookTable
                        where Bk.SubcategoryID == id
                        select new BookViewModel
                        {
                            Id = Bk.Id,
                            Name = Bk.Name,
                            Description = Bk.Description,
                            Rating = Bk.Rating
                        }).ToList();
            return books;
        }

    }
}