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

        public void UpdateRating(List<RateViewModel> ratings)
        {
            _bookRepo.UpdateRating(ratings);
        }
        public void AddToWishList(int BookId, int WishListId)
        {
            _bookRepo.AddToWishList(BookId, WishListId);
        }
        public bool CheckIfInWishList(int UserId, int BookId)
        {
            return _bookRepo.CheckIfInWishList(UserId, BookId);
        }
    }
}