namespace BookCave.Models.EntityModels
{
    public class Address
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string StreetLine { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }
    }
}