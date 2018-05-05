using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.ViewModels
{
    public class PaymentInfoViewModel
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string CardHolder { get; set; }
        public int ExpireMonth { get; set; }
        public int ExpireYear { get; set; }
    }
}