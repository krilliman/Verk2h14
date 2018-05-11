namespace BookCave.Models.ViewModels
{
    public class WishListItemViewModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int UserId { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
    }
}