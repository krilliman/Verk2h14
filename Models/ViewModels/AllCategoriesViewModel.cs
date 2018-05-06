using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class AllCategoriesViewModel
    {
        public List<CategoryViewModel> MainCategories { get; set; }
        public List<SubCategoryViewModel> SubCategories { get; set; }
        public List<BookViewModel> Books { get; set; }
    }
}