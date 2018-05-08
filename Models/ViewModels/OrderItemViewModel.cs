namespace BookCave.Models.ViewModels
{
    public class OrderItemViewModel
    {
        public int BookId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}