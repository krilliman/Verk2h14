using System.Collections.Generic;
using System.Linq;
using BookCave.Data;

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