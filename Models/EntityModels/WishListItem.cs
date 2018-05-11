namespace BookCave.Models.EntityModels
{
    public class WishListItem
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
    }
}