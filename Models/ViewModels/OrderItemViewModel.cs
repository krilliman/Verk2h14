namespace BookCave.Models.ViewModels
{
    public class OrderItemViewModel
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}