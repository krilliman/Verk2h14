namespace BookCave.Models.EntityModels
{
    public class WishListItem
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
    }
}