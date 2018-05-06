namespace BookCave.Models.InputModels
{
    public class AddressInputModel
    {
        public int UserId { get; set; }
        public string StreetLine { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }
    }
}