using System.Collections.Generic;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class CartService
    {

        private CartRepo _cartRepo;

        public CartService()
        {
            _cartRepo = new CartRepo();
        }

        public string AddToCart(int BookId, int Quantity)
        {
            return _cartRepo.AddToCart(BookId, Quantity);
             
        }
        public string CreateString(List<string> Cart)
        {
            return _cartRepo.CreateString(Cart);
        }
        public CheckOutViewModel CheckOut(CartViewModel Model)
        {
            return _cartRepo.CheckOut(Model);
        }
        public AddressViewModel GetAddressById(int AddressId)
        {
            return _cartRepo.GetAddressById(AddressId);
        }
        public PaymentInfoViewModel GetPaymentById(int PaymentId)
        {
            return _cartRepo.GetPaymentById(PaymentId);
        }
        
    }
}