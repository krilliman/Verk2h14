using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class PaymentInfoInputModel
    {
        [Required(ErrorMessage="CarNumber Is Required")]
        [CreditCard(ErrorMessage = "Please enter a valid credit card number")]
        //[DataType(DataType.CreditCard, ErrorMessage="Enter a valid Credit card")] 
        //[CreditCard]
        public string CardNumber { get; set; }
        [Required(ErrorMessage="CardHolder Is Required")]
        [RegularExpression("[a-zA-Z ]+",ErrorMessage="Only Char Allowed")]
        public string CardHolder { get; set; }
        [Required(ErrorMessage="ExpireMonth Is Required")]
        public int ExpireMonth { get; set; }
        [Required(ErrorMessage="ExpireYear Is Required")]
        public int ExpireYear { get; set; }
        public int UserId { get; set; }
    }
}