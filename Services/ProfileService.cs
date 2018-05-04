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

        /*
        public UserViewModel GetUser(string Email)
        {
            var User = _profileRepo.GetUser(Email);
            return User;
        } 
        */
    }
}