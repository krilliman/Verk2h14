using System.Collections.Generic;
using BookCave.Models.EntityModels;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class WishListService
    {

        private WishListRepo _wishListRepo;

        public WishListService()
        {
            _wishListRepo = new WishListRepo();
        }
        public void AddToWishList(WishListItem Model)
        {
            _wishListRepo.AddToWishList(Model);
        }
    }
}