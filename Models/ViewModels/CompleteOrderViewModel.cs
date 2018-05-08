namespace BookCave.Models.ViewModels
{
    public class CompleteOrderViewModel
    {
        public CartViewModel Cart { get; set; }
        public AddressViewModel UserAddress { get; set; }
        public PaymentInfoViewModel UserPayment { get; set; }
        public int Cvc { get; set; }
        public double TotalPrice { get; set; }
        public int UserId { get; set; }
    }
}