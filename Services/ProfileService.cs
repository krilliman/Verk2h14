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
        public PaymentListViewModel GetMyPaymentList(int Id)
        {
            var MyPaymentList = _profileRepo.GetMyPaymentList(Id);
            return MyPaymentList;
        }
        public int AddPayment(PaymentListViewModel Model)
        {
            var UserId =_profileRepo.AddPayment(Model);
            return UserId;
        }
        public void DeletePayment(int PaymentId)
        {
            _profileRepo.DeletePayment(PaymentId);
        }
    }
}