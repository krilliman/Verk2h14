using System.Collections.Generic;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class WishListService
    {

        private WishListRepo _bookRepo;

        public WishListService()
        {
            _bookRepo = new WishListRepo();
        }
    }
}