using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models.EntityModels;

namespace BookCave.Repositories
{
    public class WishListRepo
    {
        private DataContext _db;

        public WishListRepo()
        {
            _db = new DataContext();
        }
    }
}