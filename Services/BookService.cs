using System.Collections.Generic;
using BookCave.Models.EntityModels;
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

        public List<BookViewModel> GetAllBooks(string search)
        {  
            var Book = _bookRepo.GetAllBooks(search);
            return Book;
            
        }
        public List<BookViewModel> GetAllBooks()
        {  
            var Book = _bookRepo.GetAllBooks();
            return Book;   
        }
        public List<BookViewModel> FilterByName()
        {
            return _bookRepo.FilterByName();
        }
        public void UpdateRating(List<RateViewModel> ratings)
        {
            _bookRepo.UpdateRating(ratings);
        }
        public void AddToWishList(WishListItem Model)
        {
            _bookRepo.AddToWishList(Model);
        }
        public bool CheckIfInWishList(int UserId, int BookId)
        {
            return _bookRepo.CheckIfInWishList(UserId, BookId);
        }
    }
}