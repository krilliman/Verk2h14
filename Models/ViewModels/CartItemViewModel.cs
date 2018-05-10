namespace BookCave.Models.ViewModels
{
    public class CartItemViewModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
    }
}