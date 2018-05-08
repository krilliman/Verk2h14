using System.Collections.Generic;
using BookCave.Models.InputModels;

namespace BookCave.Models.ViewModels
{
    public class CheckOutViewModel
    {
        public CartViewModel Cart { get; set; }
        public AddressListViewModel UserAddresses { get; set; }
        public PaymentListViewModel UserPayments { get; set; }
        public CheckOutInputModel ExtraInfo { get; set; }
    }
}