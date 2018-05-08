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

        public List<MainCategoryViewModel> GetMainCategoryList(int? id)
        {
            List<MainCategoryViewModel> Categories;
            if(id != null){
                 Categories = (from c in _db.CategoryTable
                    where c.ID == id
                    select new MainCategoryViewModel
                    {
                        ID = c.ID,
                        Name = c.Name
                    }).ToList();
            }else{
                Categories = (from c in _db.CategoryTable
                    select new MainCategoryViewModel
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
                    where s.CategoryID == id
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