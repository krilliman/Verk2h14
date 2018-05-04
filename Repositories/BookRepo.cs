using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models.ViewModels;

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
                        where Bk.Id == id
                        select new BookViewModel
                        {
                            Id = Bk.Id,
                            Name = Bk.Name,
                            Description = Bk.Description,
                            Rating = Bk.Rating
                        }).FirstOrDefault();
            return Book;
        }

        /*
        public List<BookViewModel> GetAllBooks()
        {
            var Books = (from Cg in _db.BookTable
                        select new BookViewModel
                        {
                            Id = Cg.Id,
                            Name = Cg.Name,
                            Description = Cg.Description,
                            Rating = Cg.Rating 
                        }).ToList();
            return Books;
        }
         */
    }
}