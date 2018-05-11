namespace BookCave.Models.ViewModels
{
    public class WishListItemViewModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Image { get; set; }
    }
}