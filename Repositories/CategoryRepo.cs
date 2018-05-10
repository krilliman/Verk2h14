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

        public List<BookViewModel> GetBookSearch(string search)
        {
            var Books = (from Cg in _db.BookTable
                        where Cg.Name.Contains(search)
                        select new BookViewModel
                        {
                            ID = Cg.ID,
                            Name = Cg.Name,
                            Description = Cg.Description,
                            Rating = Cg.Rating 
                        }).ToList();
            Console.WriteLine(Books.Count);
            return Books;
        }  


        public List<CategoryViewModel> GetMainCategoryList(int? id)
        {
            List<CategoryViewModel> Categories;
            if(id != null){
                 Categories = (from c in _db.CategoryTable
                    where c.ID == id
                    select new CategoryViewModel
                    {
                        ID = c.ID,
                        Name = c.Name
                    }).ToList();
            }else{
                Categories = (from c in _db.CategoryTable
                    select new CategoryViewModel
                    {
                        ID = c.ID,
                        Name = c.Name
                    }).ToList();
            }
                return Categories;
        }

        public List<SubCategoryViewModel> GetSubCategoryList(int? id)
        {
            List<SubCategoryViewModel> SubCategoryList;
            if(id != null){
                SubCategoryList = (from s in _db.SubCategoryTable
                    where s.ID == id
                    select new SubCategoryViewModel
                    {
                        ID = s.ID,
                        Name = s.Name,
                        CategoryID = s.CategoryID,
                    }).ToList();
            }else{
                SubCategoryList = (from s in _db.SubCategoryTable
                    select new SubCategoryViewModel
                    {
                        ID = s.ID,
                        Name = s.Name,
                        CategoryID = s.CategoryID,
                    }).ToList();
            }
                return SubCategoryList;
        }


        public List<BookViewModel> GetAllBooks(int? id)
        {
            List<BookViewModel> books;
            if(id != null){
                books = (from b in _db.BookTable
                        where b.SubCategoryID == id
                        select new BookViewModel
                        {
                            ID = b.ID,
                            MainCategoryID = b.MainCategoryID,
                            SubCategoryID = b.SubCategoryID,
                            Name = b.Name,
                            Author = (from a in _db.AuthorTable
                                        where a.Id == b.AuthorId
                                        select a.Name).FirstOrDefault(),
                            Description = b.Description,
                            Image = b.Image,
                            TotalPrice = b.TotalPrice,
                            Rating = b.Rating,
                            Views = b.Views,
                            PublishDate = b.PublishDate,
                            Stock = b.Stock,
                            Isbn = b.Isbn,
                        }).ToList();
            }else{
                books = (from b in _db.BookTable
                        select new BookViewModel
                        {
                            ID = b.ID,
                            MainCategoryID = b.MainCategoryID,
                            SubCategoryID = b.SubCategoryID,
                            Name = b.Name,
                            Author = (from a in _db.AuthorTable
                                        where a.Id == b.AuthorId
                                        select a.Name).FirstOrDefault(),
                            Description = b.Description,
                            Image = b.Image,
                            TotalPrice = b.TotalPrice,
                            Rating = b.Rating,
                            Views = b.Views,
                            PublishDate = b.PublishDate,
                            Stock = b.Stock,
                            Isbn = b.Isbn,
                        }).ToList();
            }
            return books;
        }
    }
}