using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class MainCategoryTop10List
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<SubCategoryViewModel> MyProperty { get; set; }
    }
}