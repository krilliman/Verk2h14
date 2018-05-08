using System;
using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models.ViewModels;
using BookCave.Models.EntityModels;

namespace BookCave.Repositories
{
    public class RatingRepo
    {
        private DataContext _db;

        public RatingRepo()
        {
            _db = new DataContext();
        }

        //Saves the rating Model into the DB.
        public void SaveRate(Rating Model)
        {
            _db.RatingTable.Add(Model);
            _db.SaveChanges();
        }
        //Selects all the ratings from the DB with the bookid ID. and then returns them to RatingService.
        public List<RateViewModel> GetRatingsById(int Id)
        {
            var Rating = (from rt in _db.RatingTable
                         where rt.BookId == Id
                         select new RateViewModel
                         {
                             Id = rt.Id,
                             BookId = rt.BookId,
                             Comment = rt.Comment,
                             Rate = rt.Rate,
                             UserId = rt.UserId
                         }).ToList();
            return Rating;
        }
    }
}

