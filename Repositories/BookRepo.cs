using System;
using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models.ViewModels;
using BookCave.Models.EntityModels;

namespace BookCave.Repositories
{
    public class BookRepo
    {
        private DataContext _db;

        public BookRepo()
        {
            _db = new DataContext();
        }

        public BookViewModel GetBook(int id)
        {
            var Book = (from Bk in _db.BookTable
                        where Bk.ID == id
                        select new BookViewModel
                        {
                            ID = Bk.ID,
                            Name = Bk.Name,
                            Description = Bk.Description,
                            Rating = Bk.Rating
                        }).FirstOrDefault();
            return Book;
        }

        
        public List<BookViewModel> GetAllBooks()
        {
            var Books = (from Cg in _db.BookTable
                        select new BookViewModel
                        {
                            ID = Cg.ID,
                            Name = Cg.Name,
                            Description = Cg.Description,
                            Rating = Cg.Rating 
                        }).ToList();
            return Books;
        }  
        public void UpdateRating(List<RateViewModel> ratings)
        {
            var book = ratings[0].BookId;
            var totalrating = ratings.Average(i=>i.Rate);
            Book TheBook = (from B in _db.BookTable
                                     where B.ID == book
                                     select B).FirstOrDefault();
            TheBook.Rating = totalrating;
            _db.SaveChanges();
        }
    }
}