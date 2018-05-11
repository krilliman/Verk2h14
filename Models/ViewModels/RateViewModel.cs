namespace BookCave.Models.ViewModels
{
    public class RateViewModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Comment { get; set; }
        public double Rate { get; set; }
        public int UserId {get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}