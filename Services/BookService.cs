using System.Collections.Generic;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class BookService
    {

        private BookRepo _bookRepo;

        public BookService()
        {
            _bookRepo = new BookRepo();
        }

        public BookViewModel GetBook(int id)
        {
            var Book = _bookRepo.GetBook(id);
            return Book;
        }

        public List<BookViewModel> GetAllBooks()
        {  
            var Book = _bookRepo.GetAllBooks();
            return Book;
            
        }
    }
}