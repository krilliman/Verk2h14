using System.Collections.Generic;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class CartService
    {

        private CartRepo _bookRepo;

        public CartService()
        {
            _bookRepo = new CartRepo();
        }

        public string AddToCart(int BookId, int Quantity)
        {
            return _bookRepo.AddToCart(BookId, Quantity);
             
        }
        public string CreateString(List<string> Cart)
        {
            return _bookRepo.CreateString(Cart);
        }
        
    }
}