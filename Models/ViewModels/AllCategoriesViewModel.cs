using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class AllCategoriesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SubCategoryViewModel> SubCategories { get; set; }
    }
}