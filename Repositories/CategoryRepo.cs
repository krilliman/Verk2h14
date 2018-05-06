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
                                where sc.CategoryID == id
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
                        where Bk.SubCategoryID == id
                        select new BookViewModel
                        {
                            Id = Bk.Id,
                            Name = Bk.Name,
                            Description = Bk.Description,
                            Rating = Bk.Rating,
                            SubCategoryID = Bk.SubCategoryID
                        }).ToList();
            return books;
        }


//test below - villi

        public List<SubCategoryViewModel> GetAllSubCategoriesList()
        {
            var SubCategorys = (from sc in _db.SubCategoryTable
                                select new SubCategoryViewModel
                                {
                                    Id = sc.Id,
                                    Name = sc.Name,
                                    CategoryID = sc.CategoryID
                                }).ToList();
            return SubCategorys;
        }

        public List<BookViewModel> GetAllBooksList()
        {
            Console.WriteLine("entering get all books");
            var books = (from Bk in _db.BookTable
                        select new BookViewModel
                        {
                            Id = Bk.Id,
                            Name = Bk.Name,
                            Description = Bk.Description,
                            Rating = Bk.Rating,
                            SubCategoryID = Bk.SubCategoryID
                        }).ToList();
            return books;
        }


        // public List<AllCategoriesViewModel> GetAllCategoriesList(){

        //     var allCategoriesList = (from c in _db.CategoryTable
        //                             join sc in _db.SubCategoryTable on c.Id equals sc.Id
        //                             select new AllCategoriesViewModel{
        //                                 Id = c.Id,
        //                                 Name = c.Name,
        //                                 SubCategories = (from x in _db.SubCategoryTable
        //                                     where x.CategoryId == c.Id
        //                                     select new SubCategoryAndBooksViewModel{
        //                                     Id = x.Id,
        //                                     Name = x.Name,
        //                                     BookList = (from b in _db.BookTable
        //                                             where b.SubcategoryID == x.Id
        //                                             select new BookViewModel{
        //                                                 Id = b.Id,
        //                                                 Name = b.Name,
        //                                                 Description = b.Description,
        //                                                 Rating = b.Rating}).OrderByDescending(b => b.Rating).Take(2).ToList(),
        //                                 }).ToList(),
        //                             }).ToList();
        //     return allCategoriesList;


        // }

    }
}