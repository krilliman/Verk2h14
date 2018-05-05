namespace BookCave.Models.EntityModels
{
    public class UserInformation
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int CardInformationListId { get; set; }
        public int AddressBookId { get;set; }
        public int WishListId { get; set; }
        public int CartId { get; set; }
    }
}