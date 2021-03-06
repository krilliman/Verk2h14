using System.Collections.Generic;
using BookCave.Models.EntityModels;
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
        public UserViewModel GetInformation(int Id)
        {
            var Information = _profileRepo.GetInformation(Id);

            return Information;
        }
        public List<OrdersViewModel> GetAllOrders(int Id)
        {
            return _profileRepo.GetAllOrders(Id);
        }
        public void EditUserInformation(UserViewModel Model)
        {
            _profileRepo.EditUserInformation(Model);
        }
         public int AddAddress(AddressListViewModel Model)
        {
            var UserId = _profileRepo.AddAddress(Model);
            return UserId;
        }
        public void DeleteAddress(int AddressId)
        {
            _profileRepo.DeleteAddress(AddressId);
        }
        public AddressListViewModel GetMyAddressBook(int Id)
        {
            var MyAddressBook = _profileRepo.GetMyAddressBook(Id);
            return MyAddressBook;
        }
    }
}