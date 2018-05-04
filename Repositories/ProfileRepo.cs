using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class ProfileRepo
    {
        private DataContext _db;

        public ProfileRepo()
        {
            _db = new DataContext();
        }

        /*
        public UserViewModel GetUser(string email)
        {
            var user = (from user in _db.)
        }
        */
    }
}