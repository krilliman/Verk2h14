using System.Collections.Generic;
using BookCave.Models.InputModels;

namespace BookCave.Models.ViewModels
{
    public class PaymentListViewModel
    {
        public List<PaymentInfoViewModel> Payments {get; set;}
        public PaymentInfoInputModel NewPayment { get; set; }        
    }
}