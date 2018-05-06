using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class BookViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public int BookId { get; set; }
        public string Comment { get; set; }
        public double Rate { get; set; }
        public int UserId {get; set; }
        public List<RateViewModel> Ratings {get; set; }
        public int SubCategoryID { get; set; }
    }
}