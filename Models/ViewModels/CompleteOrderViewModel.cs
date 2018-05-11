using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.ViewModels
{
    public class CompleteOrderViewModel
    {
        public CartViewModel Cart { get; set; }
        public AddressViewModel UserAddress { get; set; }
        public PaymentInfoViewModel UserPayment { get; set; }
        [Required]
        [RegularExpression("[0-9]{3,4}",ErrorMessage="Digit only of length 3-4")]
        public int Cvc { get; set; }
        public double TotalPrice { get; set; }
        public int UserId { get; set; }
    }
}