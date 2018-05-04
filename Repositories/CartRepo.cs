using System.Collections.Generic;
using System.Linq;
using BookCave.Data;

namespace BookCave.Repositories
{
    public class CartRepo
    {
        private DataContext _db;

        public CartRepo()
        {
            _db = new DataContext();
        }
    }
}