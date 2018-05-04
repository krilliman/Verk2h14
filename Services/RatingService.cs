using System;
using System.Collections.Generic;
using BookCave.Models.ViewModels;
using BookCave.Models.EntityModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class RatingService
    {

        private RatingRepo _ratingRepo;

        public RatingService()
        {
            _ratingRepo = new RatingRepo();
        }

        //Saves the rating into the ratingrepo.
        public void SaveRate(Rating Model)
        {
            _ratingRepo.SaveRate(Model);
        }
        //Requests all ratings from the repo with the selected bookID.
        public List<RateViewModel> GetRatings(int Id)
        {
            Console.WriteLine("This is the GetRating function");
            var rating = _ratingRepo.GetRatingsById(Id);
            return rating;
        }
    }
}