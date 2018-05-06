using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models.EntityModels;
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
                            join Bk in _db.BookTable on Wl.BookId equals Bk.Id
                            where Wl.UserId == Id
                            select new WishListItemViewModel
                            {
                                Id = Wl.Id,
                                BookId = Bk.Id,
                                BookName = Bk.Name
                            }).ToList();
            var MyWishList = new WishListViewModel(){Id = Id, Items = ListItems};
            return MyWishList;
        }
        public PaymentListViewModel GetMyPaymentList(int Id)
        {
            /*
            Here i find all Payment details that the user has and return it
            all the way back to the controller
             */
            var ListItems = (from Pl in _db.CardInformationTable
                            where Pl.UserId == Id
                            select new PaymentInfoViewModel
                            {
                                Id = Pl.Id,
                                CardNumber = Pl.CardNumber,
                                CardHolder = Pl.CardHolder,
                                ExpireMonth = Pl.ExpireMonth,
                                ExpireYear = Pl.ExpireYear
                            }).ToList();
            var List = new PaymentListViewModel()
            {
                Addresses = ListItems
            };
            return List;
        }
        public int AddPayment(PaymentListViewModel Model)
        {
            /*
            Here im createing a new CardInformation from the model i get from the user
            and add it to the CardInformationTable
             */
            var Payment = new CardInformation()
            {
                CardHolder = Model.NewPayment.CardHolder,
                CardNumber = Model.NewPayment.CardNumber,
                UserId = Model.NewPayment.UserId,
                ExpireMonth = Model.NewPayment.ExpireMonth,
                ExpireYear = Model.NewPayment.ExpireYear
            };
            _db.Add(Payment);
            _db.SaveChanges();
            return Model.NewPayment.UserId;
        }
        public void DeletePayment(int PaymentId)
        {
            /*
            Here i find the payment to that the user wants to delete with PaymentId
             */
            var Payment = (from Pm in _db.CardInformationTable
                        where Pm.Id == PaymentId
                        select new CardInformation
                        {
                            Id = Pm.Id,
                            CardNumber = Pm.CardNumber,
                            CardHolder = Pm.CardHolder,
                            ExpireMonth = Pm.ExpireMonth,
                            ExpireYear = Pm.ExpireYear
                        }).FirstOrDefault();
            _db.Remove(Payment);
            _db.SaveChanges();
        }
    }
}