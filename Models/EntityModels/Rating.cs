namespace BookCave.Models.EntityModels
{
    public class Rating
    {
        public int Id { get; set; }
        public double Rate { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public int BookId { get; set; }
    }
}