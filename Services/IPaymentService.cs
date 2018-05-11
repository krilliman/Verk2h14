using BookCave.Models.InputModels;

namespace BookCave.Services
{
    public interface IPaymentService
    {
        void ProccessPayment(PaymentInfoInputModel Payment);
    }
}