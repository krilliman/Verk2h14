namespace BookCave.Models.EntityModels
{
    public class CardInformation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CardNumber { get; set; }
        public string CardHolder { get; set; }
        public int ExpireMonth { get; set; }
        public int ExpireYear { get; set; }
        public int Cvc { get; set; }
    }
}