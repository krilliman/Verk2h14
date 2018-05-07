namespace BookCave.Models.ViewModels
{
    public class CartItemViewModel
    {
        public int BookId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
    }
}