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
    }
}