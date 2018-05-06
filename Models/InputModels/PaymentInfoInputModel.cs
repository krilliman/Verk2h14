namespace BookCave.Models.InputModels
{
    public class PaymentInfoInputModel
    {
        public string CardNumber { get; set; }
        public string CardHolder { get; set; }
        public int ExpireMonth { get; set; }
        public int ExpireYear { get; set; }
        public int UserId { get; set; }
    }
}