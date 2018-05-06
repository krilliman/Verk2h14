using System.Collections.Generic;
using BookCave.Models.InputModels;

namespace BookCave.Models.ViewModels
{
    public class PaymentListViewModel
    {
        public List<PaymentInfoViewModel> Addresses {get; set;}
        public PaymentInfoInputModel NewPayment { get; set; }        
    }
}