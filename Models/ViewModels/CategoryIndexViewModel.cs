using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class CategoryIndexViewModel
    {
        public BookViewModel BOTW { get; set; }
        public BookViewModel UserFav { get; set; }
        public BookViewModel NewestRelease { get; set; }
        public BookViewModel CheapestBook { get; set; }
        public List<MainCategoryTop10ListViewModel> Top10AllCategories { get; set; } 
        public List<SubCategoryViewModel> Top10SubCategories { get; set; }
    }
}