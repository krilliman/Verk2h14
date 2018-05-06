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

        public WishListViewModel GetMyWishList(int Id)
        {
            /*
            Here im fetching all WishListItems with wishListId equal to Id, 
            then i create a list out of it and make the List in WishListViewModel
            be equal to that list and return the WishListViewModel up to the controller.
             */
            var ListItems = (from Wl in _db.WishListItemTable
                            join Bk in _db.BookTable on Wl.BookId equals Bk.ID
                            where Wl.WishListId == Id
                            select new WishListItemViewModel
                            {
                                Id = Wl.Id,
                                BookId = Bk.ID,
                                BookName = Bk.Name
                            }).ToList();
            var MyWishList = new WishListViewModel(){Id = Id, Items = ListItems};
            return MyWishList;
        }
    }
}