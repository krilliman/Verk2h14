using System.Collections.Generic;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class ProfileService
    {

        private ProfileRepo _profileRepo;

        public ProfileService()
        {
            _profileRepo = new ProfileRepo();
        }

        public WishListViewModel GetMyWishList(int Id)
        {
            var MyWishList = _profileRepo.GetMyWishList(Id);
            return MyWishList;
        }
    }
}