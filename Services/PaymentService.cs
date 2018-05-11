using System;
using BookCave.Models.InputModels;
using BookCave.Services;

namespace BookCave.Services
{
    public class PaymentSerivce : IPaymentService
    {
        public void ProccessPayment(PaymentInfoInputModel Payment)
        {
            if(string.IsNullOrEmpty(Payment.CardNumber)){throw new Exception("CardNumber Is missing");}
            if(string.IsNullOrEmpty(Payment.CardHolder)){throw new Exception("CardHolder Is missing");}
            if(string.IsNullOrEmpty(Payment.ExpireMonth.ToString())){throw new Exception("ExpireMonth Is missing");}
            if(string.IsNullOrEmpty(Payment.ExpireYear.ToString())){throw new Exception("ExpireYear Is missing");}
        }

    }
}