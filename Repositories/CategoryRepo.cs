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
            if(id != null){
                 var Categories = (from cg in _db.CategoryTable
                    select new MainCategoryViewModel
                    {
                        ID = cg.ID,
                        Name = cg.Name
                    }).ToList();
                return Categories;
            }else{
                var Categories = (from cg in _db.CategoryTable
                    select new MainCategoryViewModel
                    {
                        ID = cg.ID,
                        Name = cg.Name
                    }).ToList();
                return Categories;
            }
        }

        public List<SubCategoryViewModel> GetSubCategoryList(int? id)
        {
            if(id != null){
                            var SubCategorys = (from sc in _db.SubCategoryTable
                                where sc.CategoryID == id
                                select new SubCategoryViewModel
                                {
                                    ID = sc.ID,
                                    Name = sc.Name
                                }).ToList();
            return SubCategorys;
            }else{
                var SubCategorys = (from sc in _db.SubCategoryTable
                    select new SubCategoryViewModel
                    {
                        ID = sc.ID,
                        Name = sc.Name
                    }).ToList();
                return SubCategorys;
            }
        }


        public List<BookViewModel> GetAllBooks(int? id)
        {
            if(id != null){
                var books = (from Bk in _db.BookTable
                        where Bk.SubCategoryID == id
                        select new BookViewModel
                        {
                            ID = Bk.ID,
                            Name = Bk.Name,
                            Description = Bk.Description,
                            Rating = Bk.Rating,
                            SubCategoryID = Bk.SubCategoryID
                        }).ToList();
            return books;
            }else{
                var books = (from Bk in _db.BookTable
                        select new BookViewModel
                        {
                            ID = Bk.ID,
                            Name = Bk.Name,
                            Description = Bk.Description,
                            Rating = Bk.Rating,
                            SubCategoryID = Bk.SubCategoryID
                        }).ToList();
            return books;
            }
        }
    }
}