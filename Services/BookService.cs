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


        
        /*
        public List<BookViewModel> GetAllBooks()
        {
           
            Þetta er dæmi um hvernig við tölum við sambærlegt repo sem nær i bækunar fyrir okkur
             
            var books = _bookRepo.GetAllBooks();
            return books;
            
        }
        */
    }
}