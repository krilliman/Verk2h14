namespace BookCave.Models.EntityModels
{
    public class CardInformation
    {
        public int Id { get; set; }
        public int CardInformationListId { get; set; }
        public string CardNumber { get; set; }
        public string CardHolder { get; set; }
        public int ExpireMonth { get; set; }
        public int ExpireYear { get; set; }
    }
}