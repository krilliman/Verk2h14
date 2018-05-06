using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class AllCategoriesViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<SubCategoryWithBooksViewModel> SubCategories { get; set; }
    }
}