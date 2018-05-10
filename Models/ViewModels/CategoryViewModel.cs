using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class CategoryViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public BookViewModel BOTW { get; set; }
        public BookViewModel UserFav { get; set; }
        public BookViewModel NewestRelease { get; set; }
        public BookViewModel CheapestBook { get; set; }
        public List<MainCategoryTop10ListViewModel> Top10AllCategories { get; set; } 
        public List<SubCategoryViewModel> SubCategories { get; set; }
    }
}