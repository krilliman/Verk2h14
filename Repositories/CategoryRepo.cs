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

        public List<CategoryViewModel> AllCategories()
        {
            var Categories = (from cg in _db.CategoryTable
                            select new CategoryViewModel
                            {
                                Id = cg.Id,
                                Name = cg.Name
                            }).ToList();
            return Categories;
        }

        public List<SubCategoryViewModel> GetAllSubCategories(int id)
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

        public List<AllCategoriesViewModel> GetAllCategoriesList(){

            var allCategoriesList = (from c in _db.CategoryTable
                                    join sc in _db.SubCategoryTable on c.Id equals sc.Id
                                    select new AllCategoriesViewModel{
                                        Id = c.Id,
                                        Name = c.Name,
                                        SubCategories = (from x in _db.SubCategoryTable
                                            where x.CategoryId == c.Id
                                            select new SubCategoryViewModel{
                                            Id = x.Id,
                                            Name = x.Name,
                                        }).ToList(),
                                    }).ToList();
            return allCategoriesList;


        }

    }
}